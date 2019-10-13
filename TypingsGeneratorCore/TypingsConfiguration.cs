using Reinforced.Typings;
using Reinforced.Typings.Ast;
using Reinforced.Typings.Ast.TypeNames;
using Reinforced.Typings.Fluent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TypingsGenerator
{
    public class TypingsConfiguration
    {
        public static void Configure(ConfigurationBuilder builder)
        {
            Debugger.Launch();
            builder.Global((config) => config.UseModules());
            builder.Substitute(typeof(DateTime), new RtSimpleTypeName("Date"));
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            //var graphQl = Assembly.UnsafeLoadFrom("C:\\Users\\sveto\\.nuget\\packages\\graphql\\2.4.0");
            var servicesAssemblyPath = Path.GetFullPath("..\\FavourAPI\\bin\\Debug\\netcoreapp2.2\\FavourAPI.dll");
            var servicesAssembly = Assembly.UnsafeLoadFrom(servicesAssemblyPath);
            var types = GetTypesToCopy(servicesAssembly, "FavourAPI.GraphQL.InputTypes.Gosho", "Include");

            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].IsEnum)
                {
                    ExportEnums(builder, types[i]);
                }
                else
                {
                    ExportInterfaces(builder, types[i]);
                }
            }
            //var dynamicAssemblyPath = Path.GetFullPath("..\\..\\Typings\\dynamic.dll");
            //var dynamicAssembly = Assembly.LoadFrom(dynamicAssemblyPath);
            //var dynamicTypes = dynamicAssembly.GetTypes();

            //for (int i = 0; i < dynamicTypes.Length; i++)
            //{
            //    if (dynamicTypes[i].IsEnum)
            //    {
            //        ExportEnums(builder, dynamicTypes[i]);
            //    }
            //}
            // GenerateCustomClass(dynamicTypes, builder);
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Debugger.Launch();

            return Assembly.UnsafeLoadFrom("C:\\Users\\sveto\\.nuget\\packages\\graphql\\2.4.0\\lib\\netstandard2.0\\GraphQL.dll");

        }

        private static void GenerateCustomClass(Type[] dynamicTypes, ConfigurationBuilder builder)
        {
            var customClass = dynamicTypes.FirstOrDefault(dt => dt.Name == "CustomClass");

            var runtimeProperties = customClass.GetRuntimeProperties();
            builder.ExportAsInterfaces(new[] { customClass }, (config) =>
            {
                config.AutoI(false);
            });
        }

        private static Type[] GetTypesToCopy(Assembly assembly, string nameSpace, string includeAttributeName)
        {
            // var ta = assembly.Modules.SelectMany(m => m.Types);
            return
              assembly.ExportedTypes
                      .Where(t => (t.Namespace != null && t.Namespace == (nameSpace)) 
                      )
                      .OrderBy((t) => t.Name).ToArray();
        }

        private static bool IsPropertyNullable(Type classType, string propertyName)
        {
            var prop = classType.GetProperties().FirstOrDefault((p) =>
            {
                return p.Name.ToLowerInvariant() == propertyName.ToLowerInvariant();
            });

            if (prop != null)
            {
                var customAttributes = prop.CustomAttributes;

                foreach (var attr in customAttributes)
                {
                    if (attr.AttributeType.Name == "Optional")
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static string ToCamelCase(string methodName)
        {
            return methodName.First().ToString().ToLower() + methodName.Substring(1);
        }

        private static void ExportEnums(ConfigurationBuilder builder, Type currentType)
        {
            builder.ExportAsEnums(new[] { currentType }, (config) =>
            {
                config.UseString(true);
            });
        }

        private static void ExportInterfaces(ConfigurationBuilder builder, Type currentType)
        {
            builder.ExportAsInterfaces(new[] { currentType }, (config) =>
            {
                config.DontIncludeToNamespace();

                AddProperties(config, currentType);

                var includeAttrubute = currentType.CustomAttributes.FirstOrDefault(a => a.AttributeType.Name == "Include");

                if (includeAttrubute != null)
                {
                    var shouldTakeMethods = includeAttrubute.NamedArguments.FirstOrDefault(arg => arg.MemberName == "WithMethods").TypedValue.Value as bool?;
                    if (shouldTakeMethods.GetValueOrDefault())
                    {
                        AddMethods(config, currentType);
                    }
                }

            });
        }

        private static void AddProperties(InterfaceExportBuilder config, Type currentType)
        {
            config.WithPublicProperties(prop =>
            {
                var oneOfAttribute = prop.Member.CustomAttributes.FirstOrDefault(attr => attr.AttributeType.Name == "OneOf");
                if (oneOfAttribute != null)
                {
                    var possibleValuesProp = oneOfAttribute.NamedArguments.FirstOrDefault(arg => arg.MemberName == "Types");
                    var values = possibleValuesProp.TypedValue.Value as IReadOnlyCollection<CustomAttributeTypedArgument>;
                    var possibleTypes = new List<Type>();

                    foreach (var value in values)
                    {
                        possibleTypes.Add((value.Value as Type));
                    }

                    prop.InferType((mi, tr) =>
                    {
                        var rtTypes = possibleTypes.Select(pt => GetTypeAsRtType(tr, pt)).ToArray();

                        return new RtSimpleTypeName(string.Join("|", rtTypes.Select(rt => rt.TypeName).ToArray()));
                    });
                }
                var enumTypesAttribute = prop.Member.CustomAttributes.FirstOrDefault(attr => attr.AttributeType.Name == "EnumStringTypes");
                if (enumTypesAttribute != null)
                {
                    var possibleValuesProp = enumTypesAttribute.NamedArguments.FirstOrDefault(arg => arg.MemberName == "PossibleValues");
                    var values = possibleValuesProp.TypedValue.Value as IReadOnlyCollection<CustomAttributeTypedArgument>;

                    prop.Type(string.Join("|", values));
                }

                var customAttributes = prop.Member.GetCustomAttributes();
                var ignoreAttribute = customAttributes.FirstOrDefault((attr) => attr.GetType().Name == "Ignore");
                if (ignoreAttribute != null)
                {
                    prop.Ignore();
                    return;
                }

                prop.ForceNullable(IsPropertyNullable(currentType, prop.Member.Name)).CamelCase();

            }).AutoI(false);
        }

        private static void AddMethods(InterfaceExportBuilder config, Type currentType)
        {
            config.WithPublicMethods(mc =>
            {
                mc.OverrideName(ToCamelCase(mc.Member.Name) + "Method")
                .CamelCase();
            });
        }

        private static RtTypeName PromisifyMethodReturnType(MethodInfo methodInfo, TypeResolver typeResolver)
        {
            return new RtSimpleTypeName("Promise", new RtTypeName[] { typeResolver.ResolveTypeName(methodInfo.ReturnType) });
        }

        private static RtSimpleTypeName GetTypeAsRtType(TypeResolver typeResolver, Type type)
        {
            return typeResolver.ResolveTypeName(type) as RtSimpleTypeName;
        }
    }
}

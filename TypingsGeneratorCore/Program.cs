using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TypingsGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rawAssemblyPath = GetArgumentValue("AssemblyPath", args);
            var generatorAssemblyPath = Path.GetFullPath(rawAssemblyPath);

            var rawRtPath = GetArgumentValue("RtPath", args);

            var rawTargetFile = GetArgumentValue("TargetFile", args);

            var rtpath = Path.GetFullPath(rawRtPath);

            var targetFile = Path.GetFullPath(rawTargetFile);

            var configMethod = "TypingsGenerator.TypingsConfiguration.Configure";

            string strCmdText = "";
            strCmdText += $"dotnet {rtpath} SourceAssemblies=\"{generatorAssemblyPath}\"";
            strCmdText += $" TargetFile=\"{targetFile}\" ";
            strCmdText += $"ConfigurationMethod=\"{configMethod}\"";

            var process = System.Diagnostics.Process.Start("PowerShell.exe", strCmdText);

            process.ErrorDataReceived += Process_ErrorDataReceived;
            process.OutputDataReceived += Program_OutputDataReceived;
        }

        private static void Process_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        private static void Program_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        private static string GetArgumentValue(string name, string[] args)
        {
            var arg = args.FirstOrDefault(a => a.Contains(name));

            return arg.Split('=')[1];
        }

       

        //private static void CreateCustomTypes(EnumGenerator enumGenerator, Assembly bridgeAssembly)
        //{
        //    try
        //    {
        //        enumGenerator.GenerateType(bridgeAssembly, "CustomClass");
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.Log(e.Message);
        //        throw;
        //    }

        //}

        private static IEnumerable<string> GetMethodNamesFromClass(Assembly assembly, string className)
        {
            var objectMethods = typeof(Object).GetMethods().ToArray();
            return assembly.GetTypes()
                .FirstOrDefault((t) => t.Name == className)
                .GetMethods().Where((m) => !m.IsSpecialName && !objectMethods.Any(om => om.Name == m.Name))
                .Select(m => m.Name);
        }
    }


}

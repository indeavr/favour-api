﻿using GraphQL.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public static class GraphQLAuthExtensions
    {
        //public static void AddGraphQLAuth(this IServiceCollection services, Action<AuthorizationSettings, IServiceProvider> configure)
        //{
        //    services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //    services.TryAddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
        //    services.AddTransient<IValidationRule, AuthorizationValidationRule>();

        //    services.TryAddTransient(s =>
        //    {
        //        var authSettings = new AuthorizationSettings();
        //        configure(authSettings, s);
        //        return authSettings;
        //    });
        //}

        //public static void AddGraphQLAuth(this IServiceCollection services, Action<AuthorizationSettings> configure)
        //{
        //    services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //    services.TryAddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
        //    services.AddTransient<IValidationRule, AuthorizationValidationRule>();

        //    services.TryAddTransient(s =>
        //    {
        //        var authSettings = new AuthorizationSettings();
        //        configure(authSettings);
        //        return authSettings;
        //    });
        //}
    }
}
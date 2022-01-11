using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extension
{
    public static class ServiceCollectionExtensions //extension yazabilmek için class ın static olması gerekir
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection servicesCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(servicesCollection);

            }

            return ServiceTool.Create(servicesCollection);

            //bu hareket Core katmanı da dahil olmak üzere ekleyeceğimiz bütün injectionları bir arada toplayabileceğimiz bir yapıya dönüşt.
        }
    }
}

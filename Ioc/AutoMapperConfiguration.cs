using System;
using System.Linq;
using AutoMapper;

namespace Pnprpg.IoC
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration GetConfiguration()
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => x.FullName.StartsWith("Pnprpg."))
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(Profile).IsAssignableFrom(p));
            return new MapperConfiguration(cfg =>
            {
                foreach (var type in types)
                    cfg.AddProfile(type);
            });
        }
    }
}

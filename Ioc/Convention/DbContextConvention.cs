using System.Configuration;
using System.Data.Entity;
using System.Linq;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;
using StructureMap.TypeRules;

namespace Pnprpg.Ioc.Convention
{
    public class DbContextConvention : IRegistrationConvention
    {
        private readonly string _nameOrConnectionString;

        public DbContextConvention(string nameOrConnectionString = "Default")
        {
            _nameOrConnectionString = nameOrConnectionString;
        }

        public void ScanTypes(TypeSet types, Registry registry)
        {
            var matches = types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed)
                .Where(type => TypeExtensions.CanBeCastTo<DbContext>(type));
            foreach (var type in matches)
            {
                registry.For(type).Use(type).Ctor<string>()
                    .Is(ConfigurationManager.ConnectionStrings[_nameOrConnectionString].Name);
                registry.For(typeof(DbContext)).Add(x => x.GetInstance(type)).Named(type.Name);
            }
        }

    }
}

using System.Linq;
using Pnprpg.Ioc.Convention;
using StructureMap;

namespace Pnprpg.Ioc
{
    public class DefaultRegistry : Registry
    {
        public static readonly string[] NamespacesToScan = { "Pnprpg." };

        public DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory(a => NamespacesToScan.Any(x => a.FullName.StartsWith(x)));
                scan.WithDefaultConventions();
                scan.With(new ControllerConvention());
                scan.With(new DbContextConvention());
                scan.With(new AutoMapperConvention());
                scan.LookForRegistries();
            });
        }
    }
}

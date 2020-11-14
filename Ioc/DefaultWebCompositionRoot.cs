using System.Collections.Generic;
using LightInject;
using Pnprpg.IoC;

[assembly: CompositionRootType(typeof(DefaultWebCompositionRoot))]
namespace Pnprpg.IoC
{
    public class DefaultWebCompositionRoot : ICompositionRoot
    {
        private readonly List<string> _assembliesToScan = new List<string> { "Pnprpg.*" };
        public void Compose(IServiceRegistry serviceRegistry)
        {
            foreach (var item in _assembliesToScan)
                serviceRegistry.RegisterAssembly($"{item}.dll");
            
            serviceRegistry.Register(c => AutoMapperConfiguration.GetConfiguration().CreateMapper());
        }
    }
}

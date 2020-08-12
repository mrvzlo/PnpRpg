using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonServiceLocator;
using StructureMap;

namespace Pnprpg.Ioc
{
    public class StructureMapDependencyScope : ServiceLocatorImplBase
    {
        private const string NestedContainerKey = "Nested.Container.Key";

        public StructureMapDependencyScope(object container)
        {
            Container = container as IContainer;
            if (Container == null) throw new ArgumentNullException("container");
        }

        public IContainer Container { get; set; }

        public IContainer CurrentNestedContainer
        {
            get => (IContainer)HttpContext?.Items[NestedContainerKey];
            set => HttpContext.Items[NestedContainerKey] = value;
        }

        private HttpContextBase HttpContext
        {
            get
            {
                var ctx = Container.TryGetInstance<HttpContextBase>();
                return ctx ?? (System.Web.HttpContext.Current != null
                           ? new HttpContextWrapper(System.Web.HttpContext.Current)
                           : null);
            }
        }

        public void CreateNestedContainer()
        {
            if (CurrentNestedContainer != null) return;
            CurrentNestedContainer = Container.GetNestedContainer();
        }

        public void Dispose()
        {
            DisposeNestedContainer();
            Container.Dispose();
        }

        public void DisposeNestedContainer()
        {
            if (CurrentNestedContainer == null) return;
            CurrentNestedContainer.Dispose();
            CurrentNestedContainer = null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return DoGetAllInstances(serviceType);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return (CurrentNestedContainer ?? Container).GetAllInstances(serviceType).Cast<object>();
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            var container = CurrentNestedContainer ?? Container;

            container.WhatDoIHave();
            if (string.IsNullOrWhiteSpace(key))
                return serviceType.IsAbstract || serviceType.IsInterface
                    ? container.TryGetInstance(serviceType)
                    : container.GetInstance(serviceType);
            return container.GetInstance(serviceType, key);
        }
    }
}

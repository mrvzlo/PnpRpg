using System.Web.Mvc;
using CommonServiceLocator;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Pnprpg.Ioc;
using Pnprpg.Web;
using WebActivatorEx;

[assembly: System.Web.PreApplicationStartMethod(typeof(StructureMapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructureMapMvc), "End")]

namespace Pnprpg.Web
{
    public static class StructureMapMvc
    {
        public static void End()
        {
            StructureMapScopeModule.CurrentDependencyScope.Dispose();
        }

        public static void Start()
        {
            var container = IoCWeb.Initialize();
            var scope = new StructureMapDependencyScope(container);
            ServiceLocator.SetLocatorProvider(() => scope);
            DependencyResolver.SetResolver(ServiceLocator.Current);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));

            //var wdih = container.WhatDoIHave();
        }
    }
}
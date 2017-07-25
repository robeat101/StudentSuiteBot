using Autofac;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis;
using System.Configuration;
using Zummer.Dialogs;
using Zummer.Handlers;
using Zummer.Services;

namespace Zummer.Modules
{
    internal sealed class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c => new LuisModelAttribute(ConfigurationManager.AppSettings["LuisModelID"], ConfigurationManager.AppSettings["LuisSubscriptionKey"])).AsSelf().AsImplementedInterfaces().SingleInstance();

            // Top Level Dialog
            builder.RegisterType<MainDialog>().As<IDialog<object>>().InstancePerDependency();

            // Singlton services
            builder.RegisterType<LuisService>().Keyed<ILuisService>(FiberModule.Key_DoNotSerialize).AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<BingSearchService>().Keyed<ISearchService>(FiberModule.Key_DoNotSerialize).AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<ApiHandler>().Keyed<IApiHandler>(FiberModule.Key_DoNotSerialize).AsImplementedInterfaces().SingleInstance();
            
            // Objects depending on incoming messages
            builder.RegisterType<HandlerFactory>().Keyed<IHandlerFactory>(FiberModule.Key_DoNotSerialize).AsImplementedInterfaces().InstancePerMatchingLifetimeScope(DialogModule.LifetimeScopeTag);
            builder.RegisterType<SearchIntentHandler>().Keyed<IIntentHandler>(FiberModule.Key_DoNotSerialize).Named<IIntentHandler>(ZummerStrings.SearchIntentName).AsImplementedInterfaces().InstancePerMatchingLifetimeScope(DialogModule.LifetimeScopeTag);
            builder.RegisterType<GreetingIntentHandler>().Keyed<IIntentHandler>(FiberModule.Key_DoNotSerialize).Named<IIntentHandler>(ZummerStrings.GreetingIntentName).AsImplementedInterfaces().InstancePerMatchingLifetimeScope(DialogModule.LifetimeScopeTag);
            builder.RegisterType<ClassScheduleIntentHandler>().Keyed<IIntentHandler>(FiberModule.Key_DoNotSerialize).Named<IIntentHandler>(ZummerStrings.ClassScheduleIntentName).AsImplementedInterfaces().InstancePerMatchingLifetimeScope(DialogModule.LifetimeScopeTag);
            builder.RegisterType<NextClassIntentHandler>().Keyed<IIntentHandler>(FiberModule.Key_DoNotSerialize).Named<IIntentHandler>(ZummerStrings.NextClassIntentName).AsImplementedInterfaces().InstancePerMatchingLifetimeScope(DialogModule.LifetimeScopeTag);

        }
    }
}
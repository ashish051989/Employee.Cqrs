using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Core;
using Employee.Configuration.Extensions;
using Memento;
using Microsoft.Practices.Unity;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration = Employee.Configuration.IOC;

namespace Employee.Configuration.Registration
{
    public class ContainerBootstrapper
    {
        public static void BuildContainer()
        {
            var container = IOC.Container;

            container.RegisterRepositories();
            container.RegisterEventDispatcher();
            container.RegisterTranslators();
            container.RegisterHandlers(typeof(ICommandHandler<>));
        }

        public static void ConfigureBus()
        {
            string serviceBusEndPoint = "Endpoint=sb://cqrsapplication.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+IMFwFR4MHMbgKqcENhCZ2oAIH8nPfCLdOCTNjxpCfo=";
            string queueEndPoint = "cqrsqueue";

            var config = Configure.With(new UnityContainerAdapter(IOC.Container))
                .Logging(l => l.Trace())
                .Routing(r => r.TypeBased()
                    .MapAssemblyOf<SaveEmployeeHandler>(queueEndPoint)
                )
                .Transport(t => t.UseAzureServiceBus(serviceBusEndPoint, queueEndPoint, AzureServiceBusMode.Basic));

            var container = IOC.Container;
            var bus = config.Start();

            container.RegisterInstance(typeof(IBus), bus);
        }
    }
}

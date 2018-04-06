using Employee.Configuration.Registration;
using Rebus.Bus;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Configuration
{
    public sealed class ServiceLocator
    {
        private static IBus _bus;

        private static bool _isInitialized;
        private static readonly object _lockThis = new object();

        public static void Init()
        {
            if (!_isInitialized)
            {
                lock (_lockThis)
                {
                    ContainerBootstrapper.BuildContainer();
                    ContainerBootstrapper.ConfigureBus();
                    _bus = IOC.Container.Resolve<IBus>();
                    _isInitialized = true;
                }
            }
        }

        public static IBus Bus
        {
            get { return _bus; }
        }
    }
}

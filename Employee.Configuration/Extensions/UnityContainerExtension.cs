using Domain.DTO.Employee;
using Domain.DTO.ValueObjects;
using Domain.Translators;
using Domain.ValueObjects;
using Memento.Messaging;
using Memento.Messaging.Rebus;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Configuration.Extensions
{
    public static class UnityContainerExtension
    {
        public static void RegisterHandlers(this UnityContainer services, Type type)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var assemblyToRegister = type.Assembly;

            RegisterAssembly(services, assemblyToRegister);
        }

        public static void RegisterHandlers(this UnityContainer services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var callingAssembly = Assembly.GetCallingAssembly();

            RegisterAssembly(services, callingAssembly);
        }

        public static void RegisterRepositories(this UnityContainer container)
        {
            container.RegisterType(typeof(Repository.NHibernate.IPersistentRepository),
                typeof(Repository.NHibernate.PersistentRepository));
        }

        public static void RegisterEventDispatcher(this UnityContainer container)
        {
            container.RegisterType<IEventDispatcher, RebusEventDispatcher>();
        }

        public static void RegisterTranslators(this UnityContainer container)
        {
            container.RegisterType(typeof(ITranslator<Domain.Employee.Employee, EmployeeDto>), typeof(EmployeeDomainToDtoTranslator));
            container.RegisterType(typeof(ITranslator<EmployeeAddressDto, EmployeeAddress>), typeof(EmployeeAddressDtoToDomainTranslator));
        }

        static IEnumerable<Type> GetImplementedHandlerInterfaces(Type type)
        {
            return type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandleMessages<>));
        }

        static void RegisterAssembly(UnityContainer services, Assembly assemblyToRegister)
        {
            var typesToAutoRegister = assemblyToRegister.GetTypes()
                .Where(type => !type.IsInterface && !type.IsAbstract)
                .Select(type => new
                {
                    Type = type,
                    ImplementedHandlerInterfaces = GetImplementedHandlerInterfaces(type).ToList()
                })
                .Where(a => a.ImplementedHandlerInterfaces.Any())
                .ToList();

            foreach (var type in typesToAutoRegister)
            {
                RegisterType(services, type.Type);
            }
        }
        static void RegisterType(UnityContainer services, Type typeToRegister)
        {
            var implementedHandlerInterfaces = GetImplementedHandlerInterfaces(typeToRegister).ToArray();

            if (!implementedHandlerInterfaces.Any())
                return;

            implementedHandlerInterfaces
                .ForEach(i => services.RegisterType(i, typeToRegister, i.Name));
        }
    }
}

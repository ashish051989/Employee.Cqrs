using Microsoft.Practices.Unity;

namespace Employee.Configuration
{
    public class IOC
    {
        private static UnityContainer UnityContainer = null;
        private static readonly object padlock = new object();

        private IOC()
        {
        }

        public static UnityContainer Container
        {
            get
            {
                lock (padlock)
                {
                    if (UnityContainer == null)
                    {
                        UnityContainer = new UnityContainer();
                    }

                    return UnityContainer;
                }
            }
        }
    }
}

using StructureMap;
using StructureMap.Graph;

namespace NancyProject.IoC
{
    public class IoCContainer
    {
        public static void Configure(IContainer Container)
        {
            Container.Configure(config => config.Scan(c =>
                                                     {
                                                         c.TheCallingAssembly();
                                                         c.WithDefaultConventions();
                                                     }
            ));
        }
    }
}
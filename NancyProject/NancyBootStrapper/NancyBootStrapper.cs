using Nancy;
using Nancy.Bootstrapper;
using System.Text;
using Nancy.Bootstrappers.StructureMap;
using StructureMap;
using NancyProject.IoC;

namespace NancyProject.NancyBootStrapper
{
    //public class NancyBootStrapper:DefaultNancyBootstrapper
    //{
    //    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    //    {
    //        ///assign the handler for onError event
    //        pipelines.OnError += (context, exception) =>
    //        {
    //            if (exception is ExceptionHandlers.EmpNotExistsException)
    //            {
    //                return new Nancy.Response()
    //                {
    //                    StatusCode = HttpStatusCode.NotFound,
    //                    ContentType = "text/html",
    //                    Contents = (stream) =>
    //                    {
    //                        var errorMessage = Encoding.UTF8.GetBytes(exception.Message);
    //                        stream.Write(errorMessage, 0, errorMessage.Length);
    //                    }
    //                };
    //            }
    //            return HttpStatusCode.InternalServerError;
    //        };
    //        //base.ApplicationStartup(container, pipelines);
    //    }


    //}

    public class NancyBootStrapper : StructureMapNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IContainer existingContainer)
        {
            IoCContainer.Configure(existingContainer);
        }
        protected override void ApplicationStartup(IContainer container, IPipelines pipelines)
        {
            ///assign the handler for onError event
            pipelines.OnError += (context, exception) =>
            {
                if (exception is ExceptionHandlers.EmpNotExistsException)
                {
                    return new Nancy.Response()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ContentType = "text/html",
                        Contents = (stream) =>
                        {
                            var errorMessage = Encoding.UTF8.GetBytes(exception.Message);
                            stream.Write(errorMessage, 0, errorMessage.Length);
                        }
                    };
                }
                return HttpStatusCode.InternalServerError;
            };
            //base.ApplicationStartup(container, pipelines);
        }
    }
}
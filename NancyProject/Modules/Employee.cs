using Nancy;
using Nancy.ModelBinding;
using NancyProject.Models;
using NancyProject.Repository;
using System.Collections.Generic;

namespace NancyProject.Modules
{
    public class Employee:NancyModule
    {
        IEmpRepository _iEmpRepository;
        public Employee(IEmpRepository iEmpRepository)
        {
            _iEmpRepository = iEmpRepository;
            Get["/name"] = _ => "Hello Jyoti!";///string output GET method

            ///Parameterised GET method
            Get["/employee/{id}"] = args =>
            {
                int id = args.id;

                var emp=_iEmpRepository.GetEmpById(id);
                //if (id > 1000)
                //{
                //    throw new ExceptionHandlers.EmpNotExistsException();
                //}

                ///negotiate uses default accept headers of 'json/application' for content negotiations
                return Negotiate
                .WithStatusCode(HttpStatusCode.OK)
                //.WithModel(id);
                .WithModel(emp);
            };

            ///multi-level parameterised GET with Model output
            Get["/{role}/{numberofyears}"] = args => {
                var empAssignment = this.Bind<Assignment>();///bind the incoming request to a defined-Model structure. It requires parameters to have same name as 
                                                            ///properties defined in the model. 
                ///prepare output object model
                var emps = new List<Emp>{
                    new Emp {Id=1,Assignment=empAssignment},
                    new Emp {Id=2,Assignment=empAssignment },
                    new Emp {Id=3,Assignment=empAssignment }
                };

                return Negotiate
                .WithStatusCode(HttpStatusCode.OK)
                .WithModel(emps);
            };
        }

    }

    
}
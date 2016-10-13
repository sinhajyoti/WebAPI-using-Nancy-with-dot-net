using NancyProject.Models;
using NancyProject.ExceptionHandlers;

namespace NancyProject.Repository
{
    public class EmpRepository : IEmpRepository
    {
        Emp IEmpRepository.GetEmpById(int id)
        {
            if (id > 1000)
            {
                throw new EmpNotExistsException();
            }
            return new Emp { Id = id,Assignment= new Assignment { Role = "Architect", NumberOfYears = 8 } }; 
        }
    }
}
using NancyProject.Models;

namespace NancyProject.Repository
{
    public interface IEmpRepository
    {
        Emp GetEmpById(int id);
    }
}

using Intellimedia.Infrastructure;
using Intellimedia.RepositoriesInterfaces;
using Intellimedia.Models;

namespace Intellimedia.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository() : base()
        {
        }
    }
}
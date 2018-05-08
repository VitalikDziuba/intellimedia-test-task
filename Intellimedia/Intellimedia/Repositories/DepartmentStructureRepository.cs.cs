using Intellimedia.Infrastructure;
using Intellimedia.RepositoriesInterfaces;
using Intellimedia.Models;

namespace Intellimedia.Repositories
{
    public class DepartmentStructureRepository : GenericRepository<DepartmentStructure>, IDepartmentStructureRepository
    {
        public DepartmentStructureRepository() : base()
        {
        }
    }
}
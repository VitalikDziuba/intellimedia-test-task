using Intellimedia.Infrastructure;
using Intellimedia.RepositoriesInterfaces;
using Intellimedia.Models;

namespace Intellimedia.Repositories
{
    public class PersonnelTimeRepository : GenericRepository<PersonnelTime>, IPersonnelTimeRepository 
    {
        public PersonnelTimeRepository() : base()
        {
        }
    }
}
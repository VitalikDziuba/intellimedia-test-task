using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intellimedia.Models
{
    public class DepartmentStructure
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public List<int> SubordinatesIds { get; set; }
    }
}
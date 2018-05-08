using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intellimedia.Models
{
    public class PersonnelTime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeOfBeginning { get; set; }
        public int TimeOfEnding { get; set; }
    }
}
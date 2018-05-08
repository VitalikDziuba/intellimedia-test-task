using Intellimedia.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intellimedia.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int TimeId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string ContactInformation { get;set;}
        public DateTime DateOfAdding { get; set; }
    }
}
using Intellimedia.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Intellimedia.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public int TimeId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [MaxLength(30)]
        public string ContactInformation { get; set; }
        [Required]
        [Range(0, 24)]
        public int TimeOfBeginning { get; set; }
        [Required]
        [Range(0, 24)]
        public int TimeOfEnding { get; set; }
        public DateTime DateOfAdding { get; set; }
    }
}
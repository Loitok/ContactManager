using System;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.ViewModels
{
    public class CsvBaseViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool Married { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }
}

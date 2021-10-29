using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBlazor.Entity
{
    public class Employee
    {
        [Required]
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(20)]
        [Required]
        public string FirstName {  get; set; }
        [Required]
        [StringLength(15)]
        public string JobName {  get; set; }
        public bool IsSelected { get; set; } = false;

        public DateTime? StartDate { get; set; } = DateTime.Today;
        public DateTime? EndDate { get; set; } = DateTime.Today;

        public string Description { get; set; } = "Benefit";
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerModernManagementSystem.UI.Models
{
    public class MainMenuItem
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Employee Type")]

        [ForeignKey(name: "EmployeeId")]
        public int EmployeeId { get; set; }

        [Display(Name = "Department")]

        [ForeignKey(name: "DepartmentId")]
        public int DepartmentId { get; set; }

        [Display(Name = "Gender")]

        [ForeignKey(name: "GenderId")]
        public int GenderId { get; set; }

        [Display(Name = "Occupation")]

        [ForeignKey(name: "OccupationId")]
        public int OccupationId { get; set; }


        public virtual Employee Employee { get; set; }
        public virtual Department Department { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Occupation Occupation { get; set; }
    }
}

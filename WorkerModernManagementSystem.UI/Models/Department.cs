using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerModernManagementSystem.UI.Models
{
    public class Department
    {
        [Column(name:"Department Id")]
        public int Id { get; set; }
        [Column(name:"Department Name",TypeName = "varchar(50)"), Required]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerModernManagementSystem.UI.Models
{
    public class Gender
    {
        [Column(name: "Gender Id")]
        public int Id { get; set; }
        [Column(name: "Sex", TypeName = "varchar(50)"), Required]
        public string Name { get; set; }
    }
}

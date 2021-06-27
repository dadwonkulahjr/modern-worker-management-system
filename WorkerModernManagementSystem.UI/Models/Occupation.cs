using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerModernManagementSystem.UI.Models
{
    public class Occupation
    {
        [Column(name: "Occupation Id")]
        public int Id { get; set; }
        [Column(name: "Occupation Name", TypeName = "varchar(50)"), Required]
        public string Name { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerModernManagementSystem.UI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)"), Required, Display(Name ="First name")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)"), Required, Display(Name ="Last name")]
        public string LastName { get; set; }
        [Column(name:"Office Email",TypeName = "varchar(50)"), Required]
        public string Email { get; set; }
        [Required, DataType(DataType.Currency),Column(TypeName = "decimal(18, 0)")]
        public decimal? Salary { get; set; }
        //[Required]
        public string Image { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [DataType(DataType.Date), Required,DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name ="Date Hire")]
        public DateTime? DateHire { get; set; }
    }
}

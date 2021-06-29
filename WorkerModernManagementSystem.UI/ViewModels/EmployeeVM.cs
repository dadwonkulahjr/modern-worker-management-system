using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerModernManagementSystem.UI.Models;

namespace WorkerModernManagementSystem.UI.ViewModels
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            ListOfMainMenuItems = new List<MainMenuItem>();
            ListOfEmployeeItems = new List<Employee>();
       
        }
        public IEnumerable<MainMenuItem> ListOfMainMenuItems { get; set; }
        public IEnumerable<Employee> ListOfEmployeeItems { get; set; }
      
    }
}

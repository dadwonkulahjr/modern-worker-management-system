using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WorkerModernManagementSystem.UI.Models;

namespace WorkerModernManagementSystem.UI.InitialSeedData
{
    public static class InitialSeedingToDb
    {
        public static ModelBuilder PleaseSeedDb(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .HasData(GetListOfInitialEmployeesData());

            modelBuilder.Entity<Department>()
                       .HasData(GetListOfInitialDepartmentData());

            modelBuilder.Entity<Gender>()
                     .HasData(GetListOfInitialGenderData());

            modelBuilder.Entity<Occupation>()
                  .HasData(GetListOfInitialOccupationData());
            return modelBuilder;
        }
        private static IEnumerable<Employee> GetListOfInitialEmployeesData()
        {
            return new List<Employee>()
            {
                new()
                {
                    Id =1,
                    FirstName = "iamtuse",
                    LastName = "theProgrammer",
                    Email = "iamtuse@iamtuse.com",
                    DateHire = DateTime.Now,
                    Salary = 450000,
                    Image = "~/images/Iam_Tuse_Seven.jpg"
                },
                new()
                {
                    Id =2,
                    FirstName = "Tom",
                    LastName = "Hasting",
                    Email = "tom@iamtuse.com",
                    DateHire = DateTime.Now,
                    Salary = 50000,
                    Image = "~/images/david.png"
                },
                new()
                {
                    Id =3,
                    FirstName = "Iren",
                    LastName = "Collins",
                    Email = "iren@iamtuse.com",
                    DateHire = DateTime.Now,
                    Salary = 25000,
                    Image = "~/images/sara.png"
                },
            };
        }
        private static IEnumerable<Department> GetListOfInitialDepartmentData()
        {
            return new List<Department>()
            {
                new()
                {
                    Id = 1,
                    Name = "Information Technology"
                },
                new()
                {
                    Id = 2,
                    Name = "Management"
                },
                new()
                {
                    Id = 3,
                    Name = "Human Resource Management"
                },
                new()
                {
                    Id = 4,
                    Name = "Finance"
                },
            };
        }
        private static IEnumerable<Gender> GetListOfInitialGenderData()
        {
            return new List<Gender>()
            {
                new()
                {
                    Id = 1,
                    Name = "Male"
                },
                new()
                {
                    Id = 2,
                    Name = "Female"
                },
                new()
                {
                    Id = 3,
                    Name = "Unknown"
                }
            };
        }
        private static IEnumerable<Occupation> GetListOfInitialOccupationData()
        {
            return new List<Occupation>()
            {
                new()
                {
                    Id = 1,
                    Name = "Software Developer"
                },
                new()
                {
                    Id = 2,
                    Name = "Agent"
                },
                new()
                {
                    Id = 3,
                    Name = "Cash Officer"
                },
                new()
                {
                    Id = 4,
                    Name = "Loan Officer"
                },
                new()
                {
                    Id = 5,
                    Name = "IT Director"
                },
                 new()
                {
                    Id = 6,
                    Name = "Web Developer"
                },
            };
        }
    }
}

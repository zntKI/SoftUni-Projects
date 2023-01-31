using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            //Console.WriteLine(GetEmployeesFullInformation(softUniContext));
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(softUniContext));
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(softUniContext));
            //Console.WriteLine(AddNewAddressToEmployee(softUniContext));
            //Console.WriteLine(GetEmployeesInPeriod(softUniContext));
            //Console.WriteLine(GetAddressesByTown(softUniContext));
            //Console.WriteLine(GetEmployee147(softUniContext));
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(softUniContext));
            //Console.WriteLine(GetLatestProjects(softUniContext));
            //Console.WriteLine(IncreaseSalaries(softUniContext));
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(softUniContext));
            //Console.WriteLine(DeleteProjectById(softUniContext));
            //Console.WriteLine(RemoveTown(softUniContext));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            List<Employee> employees = new List<Employee>();
            employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .ToList();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            List<Employee> employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                { 
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Add(address);

            Employee employee = context.Employees
                .First(e => e.LastName == "Nakov");
            employee.Address = address;
            context.SaveChangesAsync();

            StringBuilder output = new StringBuilder();

            List<string> adresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            foreach (var adress in adresses)
            {
                output.AppendLine(adress);
            }

            return output.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirst = e.Manager.FirstName,
                    ManagerLast = e.Manager.LastName,
                    AllProjects = e
                        .EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep
                                .Project
                                .StartDate
                                .ToString("M/d/yyyy h:mm:ss tt"),
                            EndDate = ep.Project.EndDate.HasValue
                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                                : "not finished"
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirst} {e.ManagerLast}");

                foreach (var p in e.AllProjects)
                {
                    output.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return output.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var addresses = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .ToArray();

            foreach (var a in addresses)
            {
                output.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    AllProjects = e
                        .EmployeesProjects
                        .Select(p => new
                        {
                            ProjectName = p.Project.Name
                        })
                        .OrderBy(p => p.ProjectName)
                        .ToArray()
                })
                .ToArray();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var p in e.AllProjects)
                {
                    output.AppendLine(p.ProjectName);
                }
            }

            return output.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirst = d.Manager.FirstName,
                    ManagerLast = d.Manager.LastName,
                    Employees = d
                        .Employees
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var d in departments)
            {
                output.AppendLine($"{d.Name} - {d.ManagerFirst} {d.ManagerLast}");

                foreach (var e in d.Employees)
                {
                    output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return output.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.ProjectId)
                .OrderBy(p => p.Name)
                .ToArray();

            //var projects2 = projects
            //    .OrderBy(p => p.ProjectId)
            //    .ToArray();

            //var projects3 = projects2
            //    .OrderBy(p => p.Name)
            //    .ToArray();

            foreach (var p in projects)
            {
                output.AppendLine(p.Name);
                output.AppendLine(p.Description);
                output.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return output.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employeesToPromote = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in employeesToPromote)
            {
                e.Salary += (decimal)((double)e.Salary * 0.12);
                output.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return output.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            Project projToDel = context
                .Projects
                .Find(2);

            EmployeeProject[] referredEmployees = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == projToDel.ProjectId)
                .ToArray();
            context.EmployeesProjects.RemoveRange(referredEmployees);
            context.Projects.Remove(projToDel);
            context.SaveChanges();

            string[] projNames = context
                .Projects
                .Select(p => p.Name)
                .ToArray();

            foreach (var p in projNames)
            {
                output.AppendLine(p);
            }

            return output.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToArray();

            foreach (var e in employees)
            {
                e.AddressId = null;
            }

            var addresses = context
                .Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToArray();

            var town = context
                .Towns
                .First(t => t.Name == "Seattle");

            context.RemoveRange(addresses);
            context.Remove(town);
            context.SaveChanges();

            return $"{addresses.Count()} addresses in Seattle were deleted";
        }
    }
}

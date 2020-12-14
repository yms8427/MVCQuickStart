using BilgeAdam.Contracts;
using BilgeAdam.Data;
using BilgeAdam.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BilgeAdam.Services
{
    public class EmployeeService
    {
        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            using (var context = new NorthwindDbContextFactory().GetContext())
            {
                return context.Employees.OrderBy(o => o.FirstName)
                                        .Select(e => new EmployeeViewModel
                                        {
                                            FullName = e.FirstName + " " + e.LastName,
                                            BirthDate = e.BirthDate.Value,
                                            HireDate = e.HireDate.Value,
                                            City = e.City,
                                            Country = e.Country,
                                            Phone = e.HomePhone
                                        })
                                        .ToList();
            }
        }

        public EmployeeViewModel Insert(NewEmployeeInputModel model)
        {
            using (var context = new NorthwindDbContextFactory().GetContext())
            {
                var @new = new Employee
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    HomePhone = model.Phone,
                    BirthDate = model.BirthDate,
                    HireDate = DateTime.Now,
                    City = model.City,
                    Country = model.Country
                };
                context.Employees.Add(@new);
                context.SaveChanges();
                return new EmployeeViewModel
                {
                    FullName = $"{@new.FirstName} {@new.LastName}",
                    BirthDate = @new.BirthDate.Value,
                    HireDate = @new.HireDate.Value,
                    City = @new.City,
                    Country = @new.Country,
                    Phone = @new.HomePhone
                };
            }
        }
    }
}
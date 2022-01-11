using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomersDetail()
        {
            using (RentACarContext context =new RentACarContext())
            {
                var result = from customers in context.Customers
                             join users in context.Users
                             on customers.UserId equals users.Id
                             select new CustomerDetailDto
                             {
                                 UserId = customers.UserId,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 CompanyName = customers.CompanyName
                             };
                return result.ToList();
            } 
        }
    }
}

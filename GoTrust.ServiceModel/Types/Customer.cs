using ServiceStack;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoTrust.ServiceModel.Types
{
    public class Customer : AuditBase
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Identity { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public CustomerType CustomerType { get; set; }
        
    }

    public enum CustomerType
    {
        Personal,
        Company
    }

    [AutoApply(Behavior.AuditQuery)]
    public class QueryCustomers : QueryDb<Customer>
    {

    }

    [ValidateHasRole("Employee")]
    [AutoApply(Behavior.AuditCreate)]
    public class CreateCustomer : ICreateDb<Customer>, IReturn<IdResponse>
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Identity { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public CustomerType CustomerType { get; set; }
    }

    public class UpdateCustomer : IPatchDb<Customer>, IReturn<IdResponse>
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Identity { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public CustomerType CustomerType { get; set; }
    }

    public class DeleteCustomer : IDeleteDb<Customer>, IReturnVoid
    {
        public int Id { get; set; }
    }
}

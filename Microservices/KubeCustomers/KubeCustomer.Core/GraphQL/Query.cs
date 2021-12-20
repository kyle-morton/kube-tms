using KubeCustomer.Core.Data;
using KubeCustomer.Core.Domain;

namespace KubeCustomer.Core.GraphQL
{
    public  class Query
    {
        [UseDbContext(typeof(KubeCustomerDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Customer> GetCustomer([ScopedService] KubeCustomerDbContext context)
        {
            return context.Customers;
        }
    }
}

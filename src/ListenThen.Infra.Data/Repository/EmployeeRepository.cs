using ListenThen.Domain.Interfaces.Repository;
using ListenThen.Domain.Models;
using ListenThen.Infra.Data.Context;

namespace ListenThen.Infra.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ListenThenContext context) : base(context)
        {
        }
    }
}
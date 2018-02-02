using ListenThen.Domain.Interfaces.Repository;
using ListenThen.Domain.Models;
using ListenThen.Infra.Data.Context;

namespace ListenThen.Infra.Data.Repository
{
    public class JobTitleRepository : Repository<JobTitle>, IJobTitleRepository
    {
        public JobTitleRepository(ListenThenContext context) : base(context)
        {
        }
    }
}
using ListenThen.Domain.Interfaces.Repository;
using ListenThen.Domain.Models;
using ListenThen.Infra.Data.Context;

namespace ListenThen.Infra.Data.Repository
{
    public class OneToOneMeetingRepository : Repository<OneToOneMeeeting>, IOneToOneMeetingRepository
    {
        public OneToOneMeetingRepository(ListenThenContext context) : base(context)
        {
        }
    }
}
using Services.Core.Domain;

namespace Enquete.Domain.AggregateModel.PollAggregate
{
    public interface IOptionRepository : IRepository<Option>
    {
        Option GetbyId(int id);
        Option Update(Option option, Option optinOld);
    }
}

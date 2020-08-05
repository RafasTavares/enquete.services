using Services.Core.Domain;

namespace Enquete.Domain.AggregateModel.PollAggregate
{
    public interface IPollRepository : IRepository<Poll>
    {
        Poll GetbyId(int id);
        Poll Add(Poll poll);
        Poll Update(Poll poll, Poll pollOld);
    }
}

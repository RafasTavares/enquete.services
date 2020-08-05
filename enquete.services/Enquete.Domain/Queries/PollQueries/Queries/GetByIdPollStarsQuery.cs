using Enquete.Domain.Queries.PollQueries.Models;
using MediatR;

namespace Enquete.Domain.Queries.PollQueries.Queries
{
   public class GetByIdPollStarsQuery : IRequest<PollViewsQueryModel>
    {
        public int Id { get; private set; }
        public bool CalledByGetPollId { get; private set; }

        public GetByIdPollStarsQuery(int id, bool calledByGetPollId)
        {
            Id = id;
            CalledByGetPollId = calledByGetPollId;
        }
    }
}
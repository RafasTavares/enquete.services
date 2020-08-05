using Enquete.Domain.Queries.PollQueries.Models;
using MediatR;

namespace Enquete.Domain.Queries.PollQueries.Queries
{
    public class GetByIdQuery : IRequest<PoolQueryModel>
    {
        public int Id { get; private set; }

        public GetByIdQuery(int id)
        {
            Id = id;
        }
    }
}

using Enquete.Domain.AggregateModel.PollAggregate;
using Enquete.Domain.Queries.OptionQueries.Models;
using Enquete.Domain.Queries.PollQueries.Models;
using Enquete.Domain.Queries.PollQueries.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Enquete.Domain.Queries.PollQueries.Handlers
{
    public class GetByIdPollStarsQueryHandler : IRequestHandler<GetByIdPollStarsQuery, PollViewsQueryModel>
    {
        private readonly IPollRepository _pollRepository;

        public GetByIdPollStarsQueryHandler(IPollRepository pollRepository)
        {
            _pollRepository = pollRepository;
        }

        private PollViewsQueryModel CreateReturn(Poll poll)
        {
            var listVotes = new List<OptionViewsQueryModel>();

            foreach (var opt in poll.Options)
                listVotes.Add(new OptionViewsQueryModel(opt.Id, opt.Count ?? 0));

            var pollViews = new PollViewsQueryModel
            {
                Views = poll.CountViews,
                Votes = listVotes
            };

            return pollViews;
        }

        public Task<PollViewsQueryModel> Handle(GetByIdPollStarsQuery request, CancellationToken cancellationToken)
        {
            var poll = _pollRepository.GetbyId(request.Id);

            if (poll is null)
                return Task.FromResult(new PollViewsQueryModel());

            var pollNew = UpdateViews(poll);
            _pollRepository.Update(poll, new Poll(poll));

            _pollRepository.UnitOfWork.Salvar();

            var retorno = CreateReturn(poll);

            return Task.FromResult(retorno);
        }

        private Poll UpdateViews(Poll poll)
        {
            poll.CountViews += 1;
            return poll;
        }
    }
}
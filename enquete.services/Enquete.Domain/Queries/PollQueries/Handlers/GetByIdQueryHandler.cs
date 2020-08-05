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
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, PoolQueryModel>
    {
        private readonly IPollRepository _pollRepository;

        public GetByIdQueryHandler(IPollRepository pollRepository)
        {
            _pollRepository = pollRepository;
        }

        private PoolQueryModel CreatePollReturn(Poll poll)
        {
            var optionList = new List<OptionQueryModel>();

            foreach (var opt in poll.Options)
                optionList.Add(new OptionQueryModel(opt.Id, opt.OptionDescription));

            var pollModel = new PoolQueryModel()
            {
                Poll_id = poll.Id,
                Poll_description = poll.PollDescription,
                Options = optionList
            };

            return pollModel;
        }

        public Task<PoolQueryModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var poll = _pollRepository.GetbyId(request.Id);

            if (poll is null)
                return Task.FromResult(new PoolQueryModel());

            var retorno = CreatePollReturn(poll);

            return Task.FromResult(retorno);
        }
    }
}
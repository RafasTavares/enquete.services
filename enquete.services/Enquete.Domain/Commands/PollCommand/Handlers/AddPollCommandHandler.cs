using Enquete.Domain.AggregateModel.PollAggregate;
using Enquete.Domain.Commands.PollCommand.Commands;
using Enquete.Domain.Queries.PollQueries.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Enquete.Domain.Commands.PollCommand.Handlers
{
    public class AddPollCommandHandler : IRequestHandler<AddPollCommand, GetPollIdQueryModel>
    {
        private readonly IPollRepository _pollRepository;

        public AddPollCommandHandler(IPollRepository pollRepository)
        {
            _pollRepository = pollRepository;
        }

        private Poll CreateModelToCommand(AddPollCommand command)
        {
            var optionList = new List<Option>();

            foreach (var opt in command.Options)
                optionList.Add(new Option() { OptionDescription = opt });

            var poll = new Poll()
            {
                PollDescription = command.Poll_Description,
                Options = optionList
            };

            return poll;
        }

        public Task<GetPollIdQueryModel> Handle(AddPollCommand request, CancellationToken cancellationToken)
        {
            var poll = _pollRepository.Add(CreateModelToCommand(request));

            _pollRepository.UnitOfWork.Salvar();

            if (poll is null)
                return null;

            return Task.FromResult(new GetPollIdQueryModel(poll.Id));
        }
    }
}

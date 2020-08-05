using Enquete.Domain.AggregateModel.PollAggregate;
using Enquete.Domain.Commands.OptionCommand.Commands;
using MediatR;
using Services.Core.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Enquete.Domain.Commands.OptionCommand.Handlers
{
    public class AddPollToOptionCommandHandler : IRequestHandler<AddPollToOptionCommand, bool>
    {
        private readonly IOptionRepository _optionsRepository;

        public AddPollToOptionCommandHandler(IOptionRepository optionsRepository)
        {
            _optionsRepository = optionsRepository;
        }

        public Task<bool> Handle(AddPollToOptionCommand request, CancellationToken cancellationToken)
        {
            var optionNew = _optionsRepository.GetbyId(request.Id);

            if (optionNew is null)
                return Task.FromResult(false);

            var optionOld = new Option(optionNew);

            optionNew.Count = CalculateVote(optionNew);

            var option = _optionsRepository.Update(optionNew, optionOld);

            _optionsRepository.UnitOfWork.Salvar();

            return Task.FromResult(option is null ? false : true);
        }

        private int CalculateVote(Option option) =>
         (option.Count == null ? 0 : (int)option.Count) + 1;

    }
}

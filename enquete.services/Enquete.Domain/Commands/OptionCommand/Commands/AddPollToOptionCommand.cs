using MediatR;

namespace Enquete.Domain.Commands.OptionCommand.Commands
{
    public class AddPollToOptionCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public AddPollToOptionCommand(int id)
        {
            Id = id;
        }
    }
}

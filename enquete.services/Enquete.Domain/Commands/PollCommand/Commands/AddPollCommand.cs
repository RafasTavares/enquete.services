using Enquete.Domain.Queries.PollQueries.Models;
using MediatR;
using System.Collections.Generic;

namespace Enquete.Domain.Commands.PollCommand.Commands
{
    public class AddPollCommand : IRequest<GetPollIdQueryModel>
    {
        public string Poll_Description { get; set; }

        public List<string> Options { get; set; }

        public AddPollCommand(string pollDescription, List<string> options)
        {
            Poll_Description = pollDescription;
            Options = options;
        }
    }
}

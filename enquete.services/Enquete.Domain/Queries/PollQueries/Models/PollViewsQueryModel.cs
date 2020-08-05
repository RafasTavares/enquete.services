using Enquete.Domain.Queries.OptionQueries.Models;
using System.Collections.Generic;

namespace Enquete.Domain.Queries.PollQueries.Models
{
    public class PollViewsQueryModel
    {
        public int Views { get; set; }

        public List<OptionViewsQueryModel> Votes { get; set; }
    }
}

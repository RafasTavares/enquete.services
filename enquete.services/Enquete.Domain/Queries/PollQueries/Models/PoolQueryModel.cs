using Enquete.Domain.Queries.OptionQueries.Models;
using System.Collections.Generic;

namespace Enquete.Domain.Queries.PollQueries.Models
{
    public class PoolQueryModel
    {
        public int Poll_id { get; set; }

        public string Poll_description { get; set; }

        public List<OptionQueryModel> Options { get; set; }
    }
}

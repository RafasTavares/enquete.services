using Services.Core.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enquete.Domain.AggregateModel.PollAggregate
{
    [Table("Poll")]
    public class Poll : IAggregateRoot
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("poll_description")]
        public string PollDescription { get; set; }

        [Column("poll_count_views")]
        public int CountViews { get; set; }

        public List<Option> Options { get; set; }

        public Poll() { }

        public Poll(Poll poll)
        {
            Id = poll.Id;
            PollDescription = poll.PollDescription;
            Options = poll.Options;
            CountViews = poll.CountViews;
        }
    }
}

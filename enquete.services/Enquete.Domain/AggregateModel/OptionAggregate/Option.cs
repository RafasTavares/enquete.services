using Services.Core.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enquete.Domain.AggregateModel.PollAggregate
{
    public class Option : IAggregateRoot
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("poll_id")]
        public int PollId { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("option_description")]
        public string OptionDescription { get; set; }

        [Column("option_count")]
        public int? Count { get; set; }

        // [ForeignKey("FK_Options_Poll_ID")]
        public virtual Poll Poll { get; set; }

        public Option() { }

        public Option(Option option)
        {
            Id = option.Id;
            PollId = option.PollId;
            OptionDescription = option.OptionDescription;
            Count = option.Count;
        }
    }
}

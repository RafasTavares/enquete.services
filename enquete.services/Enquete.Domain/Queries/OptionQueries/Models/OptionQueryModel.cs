namespace Enquete.Domain.Queries.OptionQueries.Models
{
    public class OptionQueryModel
    {
        public int Option_id { get; set; }

        public string Option_description { get; set; }

        public OptionQueryModel(int option_id, string option_description)
        {
            Option_id = option_id;
            Option_description = option_description;
        }
    }
}

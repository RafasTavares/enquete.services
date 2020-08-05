namespace Enquete.Domain.Queries.OptionQueries.Models
{
    public class OptionViewsQueryModel
    {
        public int Option_id { get; set; }

        public int Qty { get; set; }

        public OptionViewsQueryModel(int option_id, int qty)
        {
            Option_id = option_id;
            Qty = qty;
        }
    }
}

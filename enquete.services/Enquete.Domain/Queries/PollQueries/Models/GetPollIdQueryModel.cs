namespace Enquete.Domain.Queries.PollQueries.Models
{
    public class GetPollIdQueryModel
    {
        public int Poll_id { get; set; }

        public GetPollIdQueryModel(int poll_id)
        {
            Poll_id = poll_id;
        }
    }
}

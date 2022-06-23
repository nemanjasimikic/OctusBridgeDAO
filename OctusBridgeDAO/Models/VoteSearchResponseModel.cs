namespace OctusBridgeDAO.Models
{
#pragma warning disable CS1591
    public class VoteSearchResponseModel
    {
        public long TotalCount { get; set; }
        public List<VoteModel> Votes { get; set; }
    }
}

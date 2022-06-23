namespace OctusBridgeDAO.Models
{
#pragma warning disable CS1591
    public class VotesSearchModel
    {
        public long limit { get; set; }
        public bool locked { get; set; }
        public long offset { get; set; }
        public OrderingModel ordering { get; set; }
        public long proposalId { get; set; }
        public bool support { get; set; }
        public string voter { get; set; }
    }
}

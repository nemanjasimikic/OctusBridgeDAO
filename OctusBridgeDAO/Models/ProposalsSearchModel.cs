namespace OctusBridgeDAO.Models
{
#pragma warning disable CS1591
    public class ProposalsSearchModel
    {
        public long endTimeGe { get; set; }
        public long endTimeLe { get; set; }
        public long limit { get; set; }
        public long offset { get; set; }
        public OrderingModel ordering { get; set; }
        public string proposalAddress { get; set; }
        public long proposalId { get; set; }
        public string proposer { get; set; }
        public long startTimeGe { get; set; }
        public long startTimeLe { get; set; }
        public string state { get; set; }
    }

    public class OrderingModel
    {
        public string column { get; set; }
        public string direction { get; set; }
    }
}

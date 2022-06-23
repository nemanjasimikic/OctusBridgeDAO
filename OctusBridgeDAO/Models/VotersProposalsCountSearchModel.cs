namespace OctusBridgeDAO.Models
{
#pragma warning disable CS1591
    public class VotersProposalsCountSearchModel
    {
        public long limit { get; set; }
        public long offset { get; set; }
        public OrderingModel ordering { get; set; }
        public List<string> voters { get; set; }
    }
}

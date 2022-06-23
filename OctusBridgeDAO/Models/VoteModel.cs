namespace OctusBridgeDAO.Models
{
#pragma warning disable CS1591
    public class VoteModel
    {
        public long CreatedAt { get; set; }
        public bool Locked { get; set; }
        public string MessageHash { get; set; }
        public long ProposalId { get; set; }
        public string Reason { get; set; }
        public bool Support { get; set; }
        public string TransactionHash { get; set; }
        public string Voter { get; set; }
        public string Votes { get; set; }
    }
}

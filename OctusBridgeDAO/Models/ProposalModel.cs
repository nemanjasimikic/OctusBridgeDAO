namespace OctusBridgeDAO.Models
{
#pragma warning disable CS1591
    public class ProposalModel
    {
        public ActionModel Actions { get; set; }
        public string AgainstVotes { get; set; }
        public bool Canceled { get; set; }
        public long CanceledAt { get; set; }
        public long CreatedAt { get; set; }
        public string Description { get; set; }
        public long EndTime { get; set; }
        public bool Executed { get; set; }
        public long ExecutedAt { get; set; }
        public long ExecutionTime { get; set; }
        public string ForVotes { get; set; }
        public long GracePeriod { get; set; }
        public string MessageHash { get; set; }
        public string ProposalAddress { get; set; }
        public long ProposalId { get; set; }
        public string Proposer { get; set; }
        public bool Queued { get; set; }
        public long QueuedAt { get; set; }
        public string QuorumVotes { get; set; }
        public long StartTime { get; set; }
        public string State { get; set; }
        public long TimeLock { get; set; }
        public string TransactionHash { get; set; }
        public long VotingDelay { get; set; }
    }
}

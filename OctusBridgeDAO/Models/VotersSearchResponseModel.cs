namespace OctusBridgeDAO.Models
{
#pragma warning disable CS1591
    public class VotersSearchResponseModel
    {
        public List<ProposalsWithVotesModel> ProposalWithVotes { get; set; }
        public long TotalCount { get; set; }
    }

    public class ProposalsWithVotesModel
    {
        public ProposalVoteModel Proposal { get; set; }
    }

    public class ProposalVoteModel : ProposalModel
    {
        public VoteModel Vote { get; set; }
    }
}

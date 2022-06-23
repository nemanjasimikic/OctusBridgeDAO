namespace OctusBridgeDAO.Models
{
#pragma warning disable CS1591
    public class VotersSearchModel : ProposalsSearchModel
    {
        public bool availableForUnlock { get; set; }
        public bool locked { get; set; }
        public bool support { get; set; }
    }
}

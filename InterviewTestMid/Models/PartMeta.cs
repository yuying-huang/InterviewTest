
namespace InterviewTestMid.Models
{
    internal class PartMeta
    {
        public LookupItem PartClassification { get; set; } = new ();
        public LookupItem PartMasterType { get; set; } = new();

        public LookupItem? PartColour { get; set; }

        public LookupItem? PartOpacity { get; set; }  = new();
    }
}

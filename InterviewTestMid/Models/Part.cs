
namespace InterviewTestMid.Models
{
    internal class Part
    {
        public int PartID { get; set; }

        public string PartNbr { get; set; } = string.Empty;

        public string PartDesc { get; set; } = string.Empty;

        public PartMeta Meta { get; set; } = new();

        public PartWeight PartWeight { get; set; } = new();

        public bool ConversionsApplied { get; set; }

        public List<MaterialEntry> Materials { get; set; } = new();

    }
}

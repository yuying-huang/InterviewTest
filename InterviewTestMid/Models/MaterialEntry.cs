
namespace InterviewTestMid.Models
{
    internal class MaterialEntry
    {
        public LookupItem Material { get; set; } = new();

        public decimal Percentage { get; set; }

        public bool? MatrIsBarrier { get; set; }

        public bool? MatrIsDensifier { get; set; }

        public bool? MatrIsOpacifier { get; set; }


    }
}

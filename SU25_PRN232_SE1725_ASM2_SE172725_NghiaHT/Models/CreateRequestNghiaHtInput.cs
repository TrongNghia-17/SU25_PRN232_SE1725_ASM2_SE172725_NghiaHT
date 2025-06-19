namespace SMMS.GraphQLAPIServices.NghiaHT.Models
{
    public class CreateRequestNghiaHtInput
    {
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Reason { get; set; }
        public string Instruction { get; set; }
        public int? Quantity { get; set; }
        public string? Strength { get; set; }
        public string? Indications { get; set; }
        public string? Contraindications { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsApproved { get; set; }
        public int? MedicationCategoryQuanTnid { get; set; }
    }
}

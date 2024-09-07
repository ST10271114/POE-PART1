namespace ASSIGNMENT.Models
{
    public class Claims
    {
        public string Program { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public string ClaimId { get; set; }
        public string Description { get; set; }

        public string Groups { get; set; }
        public decimal hourlyrate { get; set; }
        public int Numberofhours { get; set; }
        public decimal Total => Numberofhours * hourlyrate;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public IFormFile SupportingDocument { get; set; } // For file upload
       
    }
}
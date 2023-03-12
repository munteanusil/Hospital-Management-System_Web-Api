namespace Hospital_Management_System_Web_Api.RequiredData.PostDataTo
{
    public class MedicalReportPostDto
    {
        public string InvestigationsMade { get; set; }

        public string Findings { get; set; }

        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public Guid AppointmentId { get; set; }
    }
}

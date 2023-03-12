namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts
{
    public interface IMedicalReportsExportService
    {
        byte[] ExportDoctorMedicalReports(Guid id, DateTimeOffset? startDate, DateTimeOffset? endDate);
        byte[] ExportPatientMedicalReports(Guid id, DateTimeOffset? startDate, DateTimeOffset? endDate);
    }
}

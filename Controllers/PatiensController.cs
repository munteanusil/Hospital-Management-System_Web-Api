using Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts;
using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;

namespace Hospital_Management_System_Web_Api.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    /// read more about Adding role checks on https://learn.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-7.0
    public class PatiensController : Controller
    {
        private readonly IPatientsService _patientsService;
        /// <summary>
        /// Patients controller constructor
        /// </summary>
        public PatiensController(IPatientsService patientsService)
        {
            _patientsService = patientsService;
        }
        [HttpGet]
        public GetResponse<PatientGetDto> Get(int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _patientsService.Get(skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get patient
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Doctor, Patient")]
        public async Task<ActionResult<PatientGetDto>> GetById(Guid id)
        {
            var result = await _patientsService.GetByIdAsync(id);

            if (result != null)
            {
                return result;
            }

            return NotFound();
        }

        /// <summary>
        /// Get patient's appointments
        /// </summary>
        [HttpGet("{id}/Appointments")]
        [Authorize(Roles = "Doctor, Patient")]
        public GetResponse<AppointmentGetDto> GetPatientAppointments(Guid id, int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _patientsService.GetPatientAppointments(id, skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get patient's medical reports
        /// </summary>
        [HttpGet("{id}/MedicalReports")]
        [Authorize(Roles = "Doctor, Patient")]
        public GetResponse<MedicalReportGetDto> GetPatientMedicalReports(Guid id, int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _patientsService.GetPatientMedicalReports(id, skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Update patient
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult> Update(Guid id, [FromBody] PatientPostDto item)
        {
            if (ModelState.IsValid)
            {
                await _patientsService.UpdateAsync(item, id);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete patient
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                await _patientsService.DeleteAsync(id);
                return Ok();
            }

            return NotFound();
        }
    }
}



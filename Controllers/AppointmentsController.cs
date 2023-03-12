using Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts;
using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Web.Http;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;

namespace Hospital_Management_System_Web_Api.Controllers
{
        [System.Web.Http.Route("Appointments/[controller]")]
        [ApiController]
        [Authorize(Roles = "Doctor")]
        public class AppointmentsController : ControllerBase
        {
            private readonly IAppointmentsService _appointmentsService;
            /// <summary>
            /// Appointments controller constructor
            /// </summary>
            public AppointmentsController(IAppointmentsService appointmentsService)
            {
                _appointmentsService = appointmentsService;
            }

            /// <summary>
            /// Get appointments
            /// </summary>
            [System.Web.Http.HttpGet]
            public GetResponse<AppointmentGetDto> Get(int? skip, int? take, DateTimeOffset? startDate, DateTimeOffset? endDate, string filter = null, bool includeDeleted = false)
            {
                return _appointmentsService.Get(skip, take, startDate, endDate, filter, includeDeleted);
            }

            /// <summary>
            /// Get appointment
            /// </summary>
            [HttpGet("{id}")]
            [Authorize(Roles = "Doctor, Patient")]
            public async Task<ActionResult<AppointmentGetDto>> GetById(Guid id)
            {
                var result = await _appointmentsService.GetByIdAsync(id);

                if (result != null)
                {
                    return result;
                }

                return NotFound();
            }

            /// <summary>
            /// Add appointment
            /// </summary>
            [System.Web.Http.HttpPost]
            [Authorize(Roles = "Doctor, Patient")]
            public async Task<ActionResult> Add([System.Web.Http.FromBody] AppointmentPostDto item)
            {
                if (ModelState.IsValid)
                {
                    await _appointmentsService.AddAsync(item);
                    return Ok();
                }

                return BadRequest(ModelState);
            }

            /// <summary>
            /// Update appointment
            /// </summary>
            [HttpPut("{id}")]
            [Authorize(Roles = "Doctor, Patient")]
            public async Task<ActionResult> Update(Guid id, [FromBody] AppointmentPostDto item)
            {
                if (ModelState.IsValid)
                {
                    await _appointmentsService.UpdateAsync(item, id);
                    return Ok();
                }

                return BadRequest(ModelState);
            }

            /// <summary>
            /// Delete appointment
            /// </summary>
            [HttpDelete("{id}")]
            [Authorize(Roles = "Doctor, Patient")]
            public async Task<ActionResult> Delete(Guid? id)
            {
                if (id != null)
                {
                    await _appointmentsService.DeleteAsync(id);
                    return Ok();
                }

                return NotFound();
            }
        }
}


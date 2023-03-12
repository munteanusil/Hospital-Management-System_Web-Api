using Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace Hospital_Management_System_Web_Api.Controllers
{
    Route[("Authentication/[controller]")]
    [ApiController]
        public class AuthenticationController : ControllerBase
        {
            private  readonly IAuthenticationService _authenticationService;
            /// <summary>
            /// Authentication controller constructor
            /// </summary>
            public AuthenticationController(IAuthenticationService loginService)
            {
                _authenticationService = loginService;
            }
            /// <summary>
            /// Register as doctor
            /// </summary>
            [HttpPost("/Register/Doctor")]
            public async Task<ActionResult> DoctorRegister([FromBody] DoctorPostDto item)
            {
                if (ModelState.IsValid)
                {
                    await _authenticationService.RegisterAsync(item);
                    return Ok();
                }

                return BadRequest(ModelState);
            }
            /// <summary>
            /// Register as patient
            /// </summary>
            [HttpPost("/Register/Patient")]
            public async Task<ActionResult> PatientRegister([FromBody] PatientPostDto item)
            {
                if (ModelState.IsValid)
                {
                    await _authenticationService.RegisterAsync(item);
                    return Ok();
                }

                return BadRequest(ModelState);
            }

            /// <summary>
            /// Login as doctor
            /// </summary>
            [HttpPost("/Login/Doctor")]
            public async Task<ActionResult<string>> DoctorLogin(LoginPostDto item)
            {
                if (ModelState.IsValid)
                {
                    var result = await _authenticationService.DoctorLoginAsync(item);
                    if (result == null)
                    {
                        return BadRequest();
                    }
                    return result;
                }
                return BadRequest();
            }
            /// <summary>
            /// Login as patient
            /// </summary>
            [HttpPost("/Login/Patient")]
            public async Task<ActionResult<string>> PatientLogin(LoginPostDto item)
            {
                if (ModelState.IsValid)
                {
                    var result = await _authenticationService.PatientLoginAsync(item);
                    if (result == null)
                    {
                        return BadRequest();
                    }
                    return result;
                }
                return BadRequest();
            }
        }
    }


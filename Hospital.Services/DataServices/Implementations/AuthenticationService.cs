using AutoMapper;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Hospital.Repository.UnitofWork;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration jwtConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = jwtConfiguration;
        }

        public async Task<DoctorPostDto> RegisterAsync(DoctorPostDto item)
        {
            Doctor entity = _mapper.Map<Doctor>(item);

            CreatePasswordHash(item.Password, out byte[] passwordHash, out byte[] passwordSalt);

            Doctor result = await _unitOfWork.DoctorsRepository.RegisterAsync(entity, passwordHash, passwordSalt);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DoctorPostDto>(result);
        }

        public async Task<PatientPostDto> RegisterAsync(PatientPostDto item)
        {
            Patient entity = _mapper.Map<Patient>(item);

            CreatePasswordHash(item.Password, out byte[] passwordHash, out byte[] passwordSalt);

            Patient result = await _unitOfWork.PatientsRepository.RegisterAsync(entity, passwordHash, passwordSalt);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PatientPostDto>(result);
        }

        public async Task<string> DoctorLoginAsync(LoginPostDto item)
        {
            var doctorEntity = await _unitOfWork.DoctorsRepository.SingleOrDefaultAsync(filter: f => f.Username == item.UsernameOrEmail || f.Email == item.UsernameOrEmail);

            if (doctorEntity == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(item.Password, doctorEntity.PasswordHash, doctorEntity.PasswordSalt))
            {
                return null;
            }

            return CreateToken(doctorEntity);
        }

        public async Task<string> PatientLoginAsync(LoginPostDto item)
        {
            var patientEntity = await _unitOfWork.PatientsRepository.SingleOrDefaultAsync(filter: f => f.Username == item.UsernameOrEmail || f.Email == item.UsernameOrEmail);

            if (patientEntity == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(item.Password, patientEntity.PasswordHash, patientEntity.PasswordSalt))
            {
                return null;
            }

            return CreateToken(patientEntity);
        }

        private string CreateToken(Doctor doctorEntity)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, doctorEntity.Username),
                new Claim(ClaimTypes.Email, doctorEntity.Email),
                new Claim(ClaimTypes.Role, "Doctor")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                issuer: _configuration.GetSection("JwtSettings:Issuer").Value,
                audience: _configuration.GetSection("JwtSettings:Audience").Value,
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private string CreateToken(Patient patientEntity)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, patientEntity.Username),
                new Claim(ClaimTypes.Email, patientEntity.Email),
                new Claim(ClaimTypes.Role, "Patient")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}



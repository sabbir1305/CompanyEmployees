﻿using AutoMapper;
using CompanyEmployees.ActionFilters;
using CompanyEmployees.ResourcePath;
using Contracts.Authentication;
using Contracts.Logger;
using Entities.DataTransferObjects.Authentication;
using Entities.DataTransferObjects.UserManagement;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper; 
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        public AuthenticationController(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager) {
            _logger = logger; 
            _mapper = mapper; 
            _userManager = userManager;
            _authManager = authManager;
    }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
            }
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            return StatusCode((int)HttpStatusCode.Created);
            
        }

        [HttpPost(AuthEndponts.Login)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user)) { 
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password."); 
                return Unauthorized(); 
            }
            return Ok(new { Token = await _authManager.CreateToken() });
        }
    }

}

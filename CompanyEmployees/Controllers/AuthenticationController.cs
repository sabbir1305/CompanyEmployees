﻿using AutoMapper;
using CompanyEmployees.ActionFilters;
using Contracts.Logger;
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
        public AuthenticationController(ILoggerManager logger, IMapper mapper, UserManager<User> userManager) {
            _logger = logger; 
            _mapper = mapper; 
            _userManager = userManager; 
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
    }

}
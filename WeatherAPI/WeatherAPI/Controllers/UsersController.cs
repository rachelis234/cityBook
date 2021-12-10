using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Resources;
using WeatherAPI.Validators;
using WeatherCore.Models;
using WeatherCore.Services;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this._mapper = mapper;
            this._userService = userService;
        }
        //[HttpGet("")]
        //public async Task<ActionResult<IEnumerable<UserResource>>> GetAllUsers()
        //{


        //    var users = await _userService.get();
        //    var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

        //    return Ok(userResources);
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserResource>> GetUserById(int id)
        //{
        //    var user = await _userService.GetUserById(id);
        //    var userResource = _mapper.Map<User, UserResource>(user);

        //    return Ok(userResource);
        //}

        [HttpGet("{email}")]
        public async Task<ActionResult<UserResource>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            var userResource = _mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }
        [HttpPost("")]
        public async Task<ActionResult<UserResource>> CreateUser([FromBody] SaveUserResource saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userToCreate = _mapper.Map<SaveUserResource, User>(saveUserResource);
            

            var newUser = await _userService.CreateUser(userToCreate);
            if (newUser==null)
            {
                return BadRequest("Choose another email");
            }

            var user = await _userService.GetUserByEmail(newUser.Email);

            var userResource = _mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserResource>> UpdateUser(int id, [FromBody] SaveUserResource saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userToBeUpdate = await _userService.GetUserById(id);

            if (userToBeUpdate == null)
                return NotFound();

            var user = _mapper.Map<SaveUserResource, User>(saveUserResource);

            await _userService.UpdateUser(userToBeUpdate, user);

            var updatedUser = await _userService.GetUserById(id);
            var updatedUserResource = _mapper.Map<User, UserResource>(updatedUser);

            return Ok(updatedUserResource);
        }
    }
}

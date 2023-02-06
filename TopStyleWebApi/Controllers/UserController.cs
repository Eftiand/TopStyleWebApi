using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using TopStyleWebApi.Data;
using TopStyleWebApi.Models;
using TopStyleWebApi.Repository;
using TopStyleWebApi.Services;

namespace TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userServices;
        
        public UserController(ApiDbContext context)
        {
            _userServices = new UserService(context);
        }
        
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userServices.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_userServices.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            try
            {
                _userServices.Add(value);
                return Ok("User added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User value)
        {
            try
            {
                _userServices.Update(id, value);
                return Ok("User updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userServices.DeleteById(id);
                return Ok("User deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] User value)
        {
            try
            {
                var user = _userServices.Login(value.UserName,value.Password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

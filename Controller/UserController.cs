using Alkemy.Disney.Api.Data.Context;
using Alkemy.Disney.Api.Domain;
using Alkemy.Disney.Api.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MVCContext _context;
        private readonly IConfiguration _config;

        public UserController(MVCContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<User> Users = await _context.User.Select(x => new User()
            {
                Id = x.Id,
                UserName = x.UserName
            }).ToListAsync();

            return Ok(Users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User Usuarios = await _context.User.Where(x => x.Id == id).Select(x => new User()
            {
                Id = x.Id,
                UserName = x.UserName
            }).SingleOrDefaultAsync();
            return Ok(Usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }

            if (await _context.User.Where(x => x.UserName == user.UserName).AnyAsync())
            {
                return BadRequest(ErrorHelper.Response(400, $"El usuario {user.UserName} ya existe."));
            }

            HashedPassword Password = HashHelper.Hash(user.Password);
            user.Password = Password.Password;
            user.Sal = Password.Salt;
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = user.Id }, new User()
            {
                Id = user.Id,
                UserName = user.UserName
            });
        }
    }
}


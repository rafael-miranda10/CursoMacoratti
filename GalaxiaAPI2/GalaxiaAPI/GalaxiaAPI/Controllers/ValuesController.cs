using GalaxiaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GalaxiaAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly UserManager<MeuUserIdentity> _userManager;

        public ValuesController(UserManager<MeuUserIdentity> userManager)
        {
            _userManager = userManager;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            MeuUserIdentity user = _userManager.GetUserAsync(HttpContext.User).Result;
            return new string[] { "valor1", "valor1" , "valor3" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"valor {id}";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

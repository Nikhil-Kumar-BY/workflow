using dummy.Data;
using dummy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dummy.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private readonly pgdbContext _pg;
        public UserController(pgdbContext pg)
        {
            _pg = pg;
        }

       

        [HttpGet]
        public List<User> getUsers()
        {
            return _pg.users.ToList();
        }

        [HttpPost]
        public string postUser(User user)
        {
            _pg.users.Add(user);
            _pg.SaveChanges();
            return "user added";
        }
    }
}

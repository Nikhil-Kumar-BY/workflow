using dummy.Data;
using dummy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dummy.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ShiftController : Controller
    {
        private readonly pgdbContext _pg;
        public ShiftController(pgdbContext pg)
        {
            _pg = pg;
        }



        [HttpGet]
        public List<Shift> getUsers()
        {
            return _pg.shifts.ToList();
        }

        [HttpPost]
        public string postShift(Shift shift)
        {
            _pg.shifts.Add(shift);
            _pg.SaveChanges();
            return "shift added";
        }
    }
}

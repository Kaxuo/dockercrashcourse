using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using dockerApi.Models;
namespace dockerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ColourContext _context;
        public ValuesController(ColourContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Colour>> GetColourItems()
        {
            return _context.ColourItems;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Vega.Controllers.Resources;
using Vega.Persistence;
using Vega.Core.Models;

namespace Vega.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;
        public MakesController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes(){
            
              var makes =  await _context.Makes.Include( m => m.Models).ToListAsync();

              return _mapper.Map<List<Make>,List<MakeResource>>(makes);

        }
    }
}
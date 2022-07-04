using PinealWebMvc.Data;
using PinealWebMvc.Models;
using System.Linq;
using System.Collections.Generic;

namespace PinealWebMvc.Services
{
    public class VertenteService
    {
        private readonly PinealWebMvcContext _context;

        public VertenteService(PinealWebMvcContext context)
        {
            _context = context;
        }

        public List<Vertente> FindAll()
        {
            return _context.Vertente.OrderBy(x => x.Name).ToList();
        }
    }
}

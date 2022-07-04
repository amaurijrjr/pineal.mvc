using PinealWebMvc.Models;
using PinealWebMvc.Data;
using System.Collections.Generic;
using System.Linq;

namespace PinealWebMvc.Services
{
    public class TipoService
    {
        private readonly PinealWebMvcContext _context;

        public TipoService(PinealWebMvcContext context)
        {
            _context = context;
        }

        public List<Tipo> FindAll()
        {
            return _context.Tipo.OrderBy(x => x.Name).ToList();
        }
    }
}

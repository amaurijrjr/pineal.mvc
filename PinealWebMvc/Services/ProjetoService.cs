using PinealWebMvc.Data;
using System.Collections.Generic;
using PinealWebMvc.Models;
using System.Linq;

namespace PinealWebMvc.Services
{
    public class ProjetoService
    {
        private readonly PinealWebMvcContext _context;

        public ProjetoService(PinealWebMvcContext context)
        {
            _context = context;
        }

        public List<Projeto> FindAll()
        {
            return _context.Projeto.ToList();
        }

        public void Insert(Projeto obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}

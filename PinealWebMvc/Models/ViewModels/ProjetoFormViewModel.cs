using System.Collections.Generic;

namespace PinealWebMvc.Models.ViewModels
{
    public class ProjetoFormViewModel
    {
        public Projeto Projeto { get; set; }
        public ICollection<Vertente> Vertentes { get; set; }
        public ICollection<Tipo> Tipos { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public ICollection<Imagem> Imagems { get; set; }    
    }
}

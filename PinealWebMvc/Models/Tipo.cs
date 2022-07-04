using System.Collections.Generic;
using System;
using System.Linq;

namespace PinealWebMvc.Models
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();

        public Tipo()
        {
        }

        public Tipo(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddProjeto(Projeto projeto)
        {
            Projetos.Add(projeto);
        }

        public double TotalTracks(DateTime initial, DateTime final)
        {
            return Projetos.Sum(projeto => projeto.TotalTracks(initial, final));
        }
    }
}

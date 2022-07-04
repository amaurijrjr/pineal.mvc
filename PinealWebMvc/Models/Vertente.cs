using System;
using System.Collections.Generic;
using System.Linq;

namespace PinealWebMvc.Models
{
    public class Vertente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();

        public Vertente()
        {
        }

        public Vertente(int id, string name)
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

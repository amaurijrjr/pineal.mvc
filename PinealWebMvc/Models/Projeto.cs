using System;
using System.Collections.Generic;
using System.Linq;

namespace PinealWebMvc.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public ICollection<Imagem> Imagens { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Track> Tracks { get; set; } = new List<Track>();
        public Vertente Vertente { get; set; }
        public int VertenteId { get; set; }
        public Tipo Tipo { get; set; }
        public int TipoId { get; set; }

        public Projeto()
        {
        }

        public Projeto(int id, string name, string email, Vertente vertente, Tipo tipo)
        {
            Id = id;
            Name = name;
            Email = email;
            Vertente = vertente;
            Tipo = tipo;
        }

        public void AddTrack(Track track)
        {
            Tracks.Add(track);
        }

        public void RemoveTrack(Track track)
        {
            Tracks.Remove(track);
        }

        public double TotalTracks(DateTime initial, DateTime final)
        {
            return Tracks.Where(track => track.Lançamento >= initial && track.Lançamento <= final).Sum(track => track.Amount);
        }

        public void AddImagem(Imagem imagem)
        {
            Imagens.Add(imagem);
        }

        public void RemoveImagem(Imagem imagem)
        {
            Imagens.Remove(imagem);
        }

    }
}

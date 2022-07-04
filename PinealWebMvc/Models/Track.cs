using System;
using PinealWebMvc.Models.Enums;

namespace PinealWebMvc.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public DateTime Lançamento { get; set; }
        public TrackStatus TrackProperty { get; set; }
        public Projeto Projeto { get; set; }
        public Vertente Vertente { get; set; }
        public double Amount { get; set; }

        public Track()
        {
        }

        public Track(int id, string name, string link, DateTime lançamento, TrackStatus trackProperty, Projeto projeto, Vertente vertente)
        {
            Id = id;
            Name = name;
            Link = link;
            Lançamento = lançamento;
            TrackProperty = trackProperty;
            Projeto = projeto;
            Vertente = vertente;
        }
    }
}

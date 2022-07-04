using PinealWebMvc.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinealWebMvc.Models.Enums;

namespace PinealWebMvc.Data
{
    public class SeedingService
    {
        private readonly PinealWebMvcContext _context;

        public SeedingService(PinealWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Vertente.Any() ||
                _context.Tipo.Any() ||
                _context.Track.Any() ||
                _context.Projeto.Any())
            {
                return; //DB já foi populado
            }

            Vertente v1 = new Vertente(1, "Progressive Trance");
            Vertente v2 = new Vertente(2, "Full on");
            Vertente v3 = new Vertente(3, "Full on Night");
            Vertente v4 = new Vertente(4, "Full on Morning");
            Vertente v5 = new Vertente(5, "Full on Groove");
            Vertente v6 = new Vertente(6, "Prog Dark");
            Vertente v7 = new Vertente(7, "DarkPsy");
            Vertente v8 = new Vertente(8, "Forest");
            Vertente v9 = new Vertente(9, "Hitech");
            Vertente v10 = new Vertente(10, "Dark Experimental");

            Tipo tp1 = new Tipo(1, "Dj Set");
            Tipo tp2 = new Tipo(2, "Live");

            Projeto p1 = new Projeto(1, "Psycometric", "psycometric@gmail.com", v3, tp1);
            Projeto p2 = new Projeto(2, "Quinta Dimensão", "quintadimensão@gmail.com", v3, tp2);
            Projeto p3 = new Projeto(3, "ProjectX", "projectx@gmail.com", v5, tp2);

            Track t1 = new Track(1
                , "Set Groove"
                , "www.soundcloud.com/psycometric"
                , new DateTime(2022, 06, 17)
                , TrackStatus.Billed, p1, v5);
            Track t2 = new Track(2
                , "Set Full on"
                , "www.soundcloud.com/quintadimensao"
                , new DateTime(2022, 06, 17)
                , TrackStatus.Billed, p2, v2);
            Track t3 = new Track(3
                , "LiveSet X"
                , "www.soundcloud/projectx"
                , new DateTime(2022, 06, 17)
                , TrackStatus.Billed, p3, v5);

            _context.Vertente.AddRange(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10);
            _context.Tipo.AddRange(tp1, tp2);
            _context.Projeto.AddRange(p1, p2, p3);
            _context.Track.AddRange(t1, t2, t3);
            _context.SaveChanges();
        }
    }
}

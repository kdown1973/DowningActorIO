using System;
using System.Collections.Generic;
using System.Text;

namespace DowningActorIO
{
    class Actor
    {
        public string aYear { get; private set; }
        public string aCeremony { get; private set; }
        public string aWinner { get; private set; }
        public string aName { get; private set; }
        public string aFilm { get; private set; }

        public Actor(string year, string ceremony, string win, string name, string film)
        {
            aYear = year;
            aCeremony = ceremony;
            aWinner = win;
            aName = name;
            aFilm = film;
        }
    }
}

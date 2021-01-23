using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguryLib
{
    public class Okrag2D : Figura2D, IMierzalna1D
    {

        public double R;
        public Punkt2D O;

        public Okrag2D() : base() { }

        public Okrag2D(Punkt2D srodek, double promien = 0, string nazwa = "") : base(nazwa)
        {
            O = srodek;
            R = promien;
        }

        public double Dlugosc => 2 * Math.PI * R;

        public override void Przesun(double dx, double dy)
        {
            O = new Punkt2D(O.X + dx, O.Y + dy);
        }

        public override void Przesun(Wektor2D kierunek)
        {
            O = new Punkt2D(O.X + kierunek.X, O.Y + kierunek.Y);
        }

        public void Skaluj(double wspSkalowania)
        {
            R = R * wspSkalowania * wspSkalowania;
        }

        public override string ToString() => $"Okrag2D({O}, {R})";

        public virtual string ToString(Format format)
            => (format is Format.Prosty) ?
                  this.ToString()
                : $"{base.ToString()}, Okrag2D({O}, {R}), Długość = {Dlugosc:0.##}";

        public Kolo2D ToKolo2D() => new Kolo2D(O, R, Nazwa);
    }
}

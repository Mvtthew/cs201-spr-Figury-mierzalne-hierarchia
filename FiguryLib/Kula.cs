using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguryLib
{
    public class Kula : Sfera, IMierzalna3D, IMierzalna2D
    {

        public Kula() : base() { }

        public Kula(Punkt3D srodek, double promien, string nazwa = "") : base(srodek, promien, nazwa) { }

        public double Objetosc => 4D/3D * Math.PI * R * R * R;

        public override string ToString() => $"Kula({O}, {R})";

        public override string ToString(Format format) 
            => (format is Format.Prosty) ?
                  this.ToString()
                : $"{base.ToString().Replace("Sfera", "Kula")}, Objętość = {Objetosc}";

        public Sfera ToSfera() => new Sfera(O, R, Nazwa);

        public static explicit operator Okrag2D(Kula v) => v.ToOkrag2D();

        public virtual Kolo2D ToKolo2D() => new Kolo2D(new Punkt2D(O.X, O.Y), R, Nazwa);

        public static explicit operator Kolo2D(Kula v) => v.ToKolo2D();


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Praktikum
{
    internal class TäisnurkneKolmnurk : IKujund
    {
        public double A { get; set; }
        public double B { get; set; }

        private double C { get; }

        public TäisnurkneKolmnurk(double a, double b)
        {
            A = a;
            B = b;
            double c = Math.Sqrt(a * a + b * b);
        }

       
        public double ArvutaPindala() => (A * B) / 2;
        public double ArvutaÜmbermõõt() => A + B + C;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Lift.DataSource
{
    internal class Lift
    {

        DateOnly hasznalatIdopontja;
        int kartyaSorszama;
        int induloSzint;
        int celSzint;

        public Lift(DateOnly hasznalatIdopontja, int kartyaSorszama, int induloSzint, int celSzint)
        {
            this.hasznalatIdopontja = hasznalatIdopontja;
            this.kartyaSorszama = kartyaSorszama;
            this.induloSzint = induloSzint;
            this.celSzint = celSzint;
        }

        public DateOnly HasznalatIdopontja { get => hasznalatIdopontja; set => hasznalatIdopontja = value; }
        public int KartyaSorszama { get => kartyaSorszama; set => kartyaSorszama = value; }
        public int InduloSzint { get => induloSzint; set => induloSzint = value; }
        public int CelSzint { get => celSzint; set => celSzint = value; }
    }
}

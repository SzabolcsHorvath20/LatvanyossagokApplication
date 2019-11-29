using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatvanyossagokApplication
{
    class Varos
    {
        private int id;
        private string nev;
        private int ar;

        public Varos(int id, string nev, int ar)
        {
            this.id = id;
            this.nev = nev;
            this.ar = ar;
        }

        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }
        public int Ar { get => ar; set => ar = value; }

        public override string ToString()
        {
            return nev;
        }
    }
}

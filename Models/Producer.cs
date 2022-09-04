using System;
using System.Collections.Generic;
using System.Text;

namespace Ex._2_Laborator_16_.Models
{
    class Producer
    {
        /*
         • Producatorul va avea
            • Id:int
            • Nume
            • Adresa:string
         */
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public override string ToString() =>
            $"{Name}";
    }
}

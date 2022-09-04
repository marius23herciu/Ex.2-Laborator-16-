using System;
using System.Collections.Generic;
using System.Text;

namespace Ex._2_Laborator_16_.Models
{
    class Vehicle
    {
        /*
         • Un autovehicul este caracterizat de
         urmatoarele proprietati
          • Id:int
          • Nume
          • Serie de sasiu: string
          • An de fabricatie :int
          • Producator
         */
        public int Id { get; private set; }
        public string Name { get; set; }
        public Guid VehicleIdentificationNumber { get; set; }
        public int YearOfProduction { get; set; }
        public Producer Producer { get; set; }
        public Vehicle()
        {
            VehicleIdentificationNumber = Guid.NewGuid();
        }
        public override string ToString() =>
            $"{Producer} {Name} with identification no {VehicleIdentificationNumber} produced in {YearOfProduction}.";
    }
}

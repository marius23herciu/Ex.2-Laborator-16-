using Ex._2_Laborator_16_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ex._2_Laborator_16_
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Exercitiul 2
            • Creeati modelul, adaugati EF 3.1,
            Adaugati DB
            • Creeati in clasa “main” o functie
            “Seed” care va popula DB-ul
             */
            SeedTable();

            using VehicleDbContext context = new VehicleDbContext();

            /*
             • Afisati toate autovehiculele in ordine
             descrescatoare a anului de fabricatie
             */
            context.Vehicles.Include(v => v.Producer).OrderByDescending(v => v.YearOfProduction).ToList().ForEach(v => Console.WriteLine(v));

            Console.WriteLine();
            /*
             • Suplimentar
             • Afisati autovehiculele grupate in functie
             de numele producatorului sub forma
             “Autovehiculele producatorului Trabant”:
             Id, nume, serie, an de fabricatie
             .
             .
             .
             etc
             */

            var groupVehiclesByProducer = context.Producers
                   .GroupBy(p => p.Name)
                   .Select(g => new { name = g.Key });

            foreach (var group in groupVehiclesByProducer)
            {
                {
                    Console.WriteLine($"Vehicles produced by {group.name}:");
                }
                foreach (var vehicle in context.Vehicles.Include(p => p.Producer).ToList())
                {
                    if (vehicle.Producer.Name == group.name)
                    {
                        Console.WriteLine(vehicle);
                    }
                }
                Console.WriteLine();
            }
        }
        static void SeedTable()
        {
            using var ctx = new VehicleDbContext();

            if (ctx.Vehicles.Count() != 0 || ctx.Producers.Count() != 0)
            {
                return;
            }

            Producer dacia = new Producer
            {
                Name = "Dacia",
                Adress = "Romania"
            };
            Producer bmw = new Producer
            {
                Name = "BMW",
                Adress = "Germany"
            };
            Producer volvo = new Producer
            {
                Name = "Volvo",
                Adress = "Sweden"
            };
            Producer oltcit = new Producer
            {
                Name = "Oltcit",
                Adress = "Romania"
            };
            Producer audi = new Producer
            {
                Name = "Audi",
                Adress = "Germany"
            };

            ctx.Vehicles.Add(new Vehicle
            {
                Name = "320d",
                YearOfProduction = 2009,
                Producer = bmw
            });

            ctx.Vehicles.Add(new Vehicle
            {
                Name = "520i",
                YearOfProduction = 2017,
                Producer = bmw
            });

            ctx.Vehicles.Add(new Vehicle
            {
                Name = "Q7",
                YearOfProduction = 2008,
                Producer = audi
            });

            ctx.Vehicles.Add(new Vehicle
            {
                Name = "Logan",
                YearOfProduction = 2019,
                Producer = dacia
            });

            ctx.Vehicles.Add(new Vehicle
            {
                Name = "X1",
                YearOfProduction = 2022,
                Producer = bmw
            });

            ctx.Vehicles.Add(new Vehicle
            {
                Name = "XC60",
                YearOfProduction = 2018,
                Producer = volvo
            });

            ctx.Vehicles.Add(new Vehicle
            {
                Name = "Club 12 RTS",
                YearOfProduction = 1988,
                Producer = oltcit
            });

            ctx.Vehicles.Add(new Vehicle
            {
                Name = "TT",
                YearOfProduction = 2002,
                Producer = audi
            });
            ctx.Vehicles.Add(new Vehicle
            {
                Name = "Spring",
                YearOfProduction = 2022,
                Producer = dacia
            });

            ctx.Vehicles.Add(new Vehicle
            {
                Name = "Sport",
                YearOfProduction = 1984,
                Producer = dacia
            });


            ctx.SaveChanges();
        }
    }
}

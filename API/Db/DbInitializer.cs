using API.Models;
using System.Diagnostics;

namespace API.Db
{
    public static class DbInitializer
    {
        public static void Initialize(ApiDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new User[]
                {
                    new User{ UserName="jtest",Password = "12345", Email = "jtest@test.com"},
                    new User{ UserName="atest",Password = "12345", Email = "atest@test.com"}
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            if (!context.Propietarios.Any())
            {
                var propietarios = new Propietario[]
                {
                    new Propietario{Name="Carson",LastName="Alexander", BirthDate=DateTime.Parse("1989-09-01"), Cedula ="00101234567", Tipo = TipoPersona.Fisica},
                    new Propietario{Name="Meredith",LastName="Alonso",BirthDate=DateTime.Parse("2017-09-01"), Cedula ="00104561237", Tipo = TipoPersona.Juridica},
                    new Propietario{Name="Arturo",LastName="Anand",BirthDate=DateTime.Parse("1988-09-01"), Cedula ="00165432107", Tipo = TipoPersona.Fisica}
                };

                context.Propietarios.AddRange(propietarios);
                context.SaveChanges();
            }


            if (!context.Vehiculos.Any())
            {
                var vehiculos = new Vehiculo[]
                {
                    new Vehiculo{ Tipo = TipoAutomovil.Publico },
                    new Vehiculo{ Tipo = TipoAutomovil.Transporte },
                    new Vehiculo{ Tipo = TipoAutomovil.Pesado },
                    new Vehiculo{ Tipo = TipoAutomovil.Privado },
                    new Vehiculo{ Tipo = TipoAutomovil.Publico },
                    new Vehiculo{ Tipo = TipoAutomovil.Publico },
                    
                };

                context.Vehiculos.AddRange(vehiculos);
                context.SaveChanges();
            }


            if (!context.Placas.Any())
            {
                var placas = new Placa[]
                {
                    new Placa{ VehiculoId = 1, PropietarioId = 1, Number = 121212, Monto = 0.0M},
                    new Placa{ VehiculoId = 2, PropietarioId = 2, Number = 131313, Monto = 12500.0M},
                    new Placa{ VehiculoId = 3, PropietarioId = 1, Number = 141414, Monto = 125000.0M},
                    new Placa{ VehiculoId = 4, PropietarioId = 3, Number = 151515, Monto = 1250.0M},
                    new Placa{ VehiculoId = 5, PropietarioId = 1, Number = 161616, Monto = 0.0M},
                    new Placa{ VehiculoId = 6, PropietarioId = 1, Number = 171717, Monto = 0.0M}
                };

                context.Placas.AddRange(placas);
                context.SaveChanges();
            }
        }
    }
}

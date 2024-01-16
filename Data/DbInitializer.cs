using web.Data;
using web.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelContext context)
        {
            context.Database.EnsureCreated();
            var roles = new IdentityRole[] {
                new IdentityRole{Id="1", Name="Administrator"}
            };

            foreach (IdentityRole r in roles)
            {
                context.Roles.Add(r);
            }

            if (context.Guest.Any())
            {
                return;   // DB has been seeded
            }

            var guests = new Guest[]
            {
                new Guest{Name="Janez", Surname="Novak", Address="Dunajska 1", Age=20, PhoneNumber=040999999, Email="janeznovak@gmail.com"},
                new Guest{Name="Ana", Surname="Kovač", Address="Prešernova 5", Age=25, PhoneNumber=041111111, Email="anakovac@gmail.com"},
                new Guest{Name="Matej", Surname="Horvat", Address="Trubarjeva 12", Age=30, PhoneNumber=041234567, Email="matejhorvat@gmail.com"},
                new Guest{Name="Maja", Surname="Bizjak", Address="Cankarjeva 8", Age=22, PhoneNumber=040876543, Email="majabizjak@gmail.com"},
                new Guest{Name="Luka", Surname="Krajnc", Address="Miklošičeva 3", Age=28, PhoneNumber=041234567, Email="lukakrajnc@gmail.com"},
                new Guest{Name="Tina", Surname="Zupan", Address="Strojarska 7", Age=26, PhoneNumber=040987654, Email="tinazupan@gmail.com"},
                new Guest{Name="Marko", Surname="Oblak", Address="Gosposvetska 15", Age=24, PhoneNumber=041111111, Email="markooblak@gmail.com"},
                new Guest{Name="Nina", Surname="Hribar", Address="Šmartinska 10", Age=27, PhoneNumber=040876543, Email="ninahribar@gmail.com"},
                new Guest{Name="Miha", Surname="Petrovič", Address="Slovenska 2", Age=23, PhoneNumber=041234567, Email="mihapetrovic@gmail.com"},
                new Guest{Name="Eva", Surname="Kos", Address="Linhartova 6", Age=29, PhoneNumber=040987654, Email="evakos@gmail.com"},
                new Guest{Name="Boris", Surname="Kotnik", Address="Vodnikova 9", Age=31, PhoneNumber=041111111, Email="boriskotnik@gmail.com"}

            };
            
            foreach (Guest g in guests){
                context.Guest.Add(g);
            }
            
            //context.Guest.AddRange(guests);
            context.SaveChanges();

            var hotels = new Hotel[]
            {
                new Hotel { Name = "Hotel JZ", Location = "City A", Rating = 5 }
            };

            var rooms = new Room[]
            {
                new Room { NumberOfBeds = 2, Price = 100, Description = "Standard Room", HotelId = 1 },
                new Room { NumberOfBeds = 1, Price = 250, Description = "Single Room", HotelId = 1 },
                new Room { NumberOfBeds = 3, Price = 500, Description = "Suite", HotelId = 1 },
                // Add more rooms as needed
            };

            context.Hotel.AddRange(hotels);
            context.Room.AddRange(rooms);
            context.SaveChanges();

            var user = new ApplicationUser
            {
                FirstName = "Bob",
                LastName = "Dilon",
                City = "Ljubljana",
                Email = "bob@example.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "bob@example.com",
                NormalizedUserName = "bob@example.com",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "Testni123!");
                user.PasswordHash = hashed;
                context.Users.Add(user);
                context.SaveChanges(); // Save changes to get the user's Id

                // Retrieve the "Administrator" role from the database
                var administratorRole = context.Roles.SingleOrDefault(r => r.Name == "Administrator");

                if (administratorRole != null)
                {
                    // Assign the "Administrator" role to the user
                    var userRole = new IdentityUserRole<string>
                    {
                        RoleId = administratorRole.Id,
                        UserId = user.Id
                    };

                    context.UserRoles.Add(userRole);
                    context.SaveChanges();
                }
            }


            context.SaveChanges();
            
            var UserRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>{RoleId = roles[0].Id, UserId=user.Id},
                //new IdentityUserRole<string>{RoleId = roles[1].Id, UserId=user.Id},
            };

            foreach (IdentityUserRole<string> r in UserRoles)
            {
                context.UserRoles.Add(r);
            }
        }
    }
}
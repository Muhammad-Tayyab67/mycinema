using Microsoft.AspNetCore.Identity;
using mycinema.Data.Static;
using mycinema.Models;

namespace mycinema.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();

                context.Database.EnsureCreated();

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            desc = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            desc = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            desc = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            desc = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                           desc = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();

                }
                //Actor
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Name = "Actor 1",
                            bio = "This is the Bio of the first actor",
                            profilepicurl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            Name = "Actor 2",
                            bio = "This is the Bio of the second actor",
                            profilepicurl = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 3",
                            bio = "This is the Bio of the second actor",
                            profilepicurl = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 4",
                            bio = "This is the Bio of the second actor",
                            profilepicurl = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 5",
                            bio = "This is the Bio of the second actor",
                            profilepicurl = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();

                }
                //Producer
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Name = "Producer 1",
                            bio = "This is the Bio of the first actor",
                            profilepicurl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            Name = "Producer 2",
                            bio = "This is the Bio of the second actor",
                            profilepicurl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 3",
                            bio = "This is the Bio of the second actor",
                            profilepicurl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 4",
                            bio = "This is the Bio of the second actor",
                            profilepicurl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 5",
                            bio = "This is the Bio of the second actor",
                            profilepicurl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();

                }
                //Movie
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            descr = "This is the Life movie description",
                            price = 39.50,
                            imgurl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            starttime = DateTime.Now.AddDays(-10),
                            endtime = DateTime.Now.AddDays(10),
                            cinemaId = 13,
                            ProducerId = 10,
                            MovieCategery = MovieCategery.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            descr = "This is the Shawshank Redemption description",
                            price = 29.50,
                            imgurl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            starttime = DateTime.Now,
                            endtime = DateTime.Now.AddDays(3),
                            cinemaId = 16,
                            ProducerId = 11,
                            MovieCategery = MovieCategery.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            descr = "This is the Ghost movie description",
                            price = 39.50,
                            imgurl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            starttime = DateTime.Now,
                            endtime = DateTime.Now.AddDays(7),
                            cinemaId = 14,
                            ProducerId = 10,
                            MovieCategery = MovieCategery.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            descr = "This is the Race movie description",
                            price = 39.50,
                            imgurl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            starttime = DateTime.Now.AddDays(-10),
                            endtime = DateTime.Now.AddDays(-5),
                            cinemaId = 15,
                            ProducerId = 9,
                            MovieCategery = MovieCategery.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            descr = "This is the Scoob movie description",
                            price = 39.50,
                            imgurl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            starttime = DateTime.Now.AddDays(-10),
                            endtime = DateTime.Now.AddDays(-2),
                            cinemaId = 13,
                            ProducerId = 8,
                            MovieCategery = MovieCategery.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            descr = "This is the Cold Soles movie description",
                            price = 39.50,
                            imgurl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            starttime = DateTime.Now.AddDays(3),
                            endtime = DateTime.Now.AddDays(20),
                            cinemaId = 12,
                            ProducerId = 7,
                            MovieCategery = MovieCategery.Drama
                        }
                    });
                    context.SaveChanges();

                }
                //Actor movie
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 12,
                            MovieId = 15
                        },
                        new Actor_Movie()
                        {
                            ActorId = 13,
                            MovieId = 14
                        },

                        new Actor_Movie()
                        {
                            ActorId = 15,
                            MovieId = 13
                        },


                        new Actor_Movie()
                        {
                            ActorId = 14,
                            MovieId = 15
                        },

                        new Actor_Movie()
                        {
                            ActorId = 15,
                            MovieId = 16
                        },
                    });
                    context.SaveChanges();

                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

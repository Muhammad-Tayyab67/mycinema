using Microsoft.Extensions.DependencyInjection;
using mycinema.Models;

namespace mycinema.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context= servicescope.ServiceProvider.GetService<AppDBContext>();

                context.Database.EnsureCreated();
                
                //Cinema
                if(!context.Cinemas.Any())
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
                            cinemaId = 3,
                            ProducerId = 3,
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
                            cinemaId = 1,
                            ProducerId = 1,
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
                            cinemaId = 4,
                            ProducerId = 4,
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
                            cinemaId = 1,
                            ProducerId = 2,
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
                            cinemaId = 1,
                            ProducerId = 3,
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
                            cinemaId = 1,
                            ProducerId = 5,
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
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();

                }
            }

        }
    }
}

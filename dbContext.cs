using Microsoft.EntityFrameworkCore;
using Mirgation06_12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCprocs
{
    public class TournamentTopContext : DbContext
    {
        public string connectionString = @"Data Source=DESKTOP-OF66R01\SQLEXPRESS;Initial Catalog=TournamentTopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DbSet<Game> Games { set; get; }
        public DbSet<Command> Commands { set; get; }
        public DbSet<CommandPlayer> CommandPlayers { set; get; }
        public DbSet<GameGoal> GameGoals { set; get; }
        public DbSet<Player> Players { set; get; }
        public DbSet<TournamentTop> TournamentTop { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public void GetTop3ScorersInCommand(string parameter)
        {
            var res = Players.FromSql($"Top3ScorerCommnad {parameter}").ToList();
            foreach (var p in res)
                    Console.WriteLine($"Name: {p.Name}, Ingame Number: {p.IngameNumber}\n");
        }
        public void GetTop1ScorersInCommand(string parameter)
        {
            var res = Players.FromSql($"Top3ScorerCommnad {parameter}").ToList();
            Console.WriteLine($"Name: {res.ElementAt(0).Name}, Ingame Number: {res.ElementAt(0).IngameNumber}\n");
        }
        public void GetTop3Scorers()
        {
            var res = Players.FromSql($"Top3Scorer").ToList();
            foreach (var p in res)
                Console.WriteLine($"Name: {p.Name}, Ingame Number: {p.IngameNumber}\n");
        }
        public void GetTop1Scorers()
        {
            var res = Players.FromSql($"Top3Scorer").ToList();
            Console.WriteLine($"Name: {res.ElementAt(0).Name}, Ingame Number: {res.ElementAt(0).IngameNumber}\n");
        }
        public void GetTop3TeamScorers()
        {
            var res = Commands.FromSql($"Top3TeamScores").ToList();
            foreach (var p in res)
                Console.WriteLine($"Name: {p.Name}, Country: {p.Country}\n");
        }
        public void GetTop1TeamScorers()
        {
            var res = Commands.FromSql($"Top3TeamScores").ToList();
            Console.WriteLine($"Name: {res.ElementAt(0).Name}, Country: {res.ElementAt(0).Country}\n");
        }
        public void GetTop3TeamPasses()
        {
            var res = Commands.FromSql($"Top3TeamPasses").ToList();
            foreach (var p in res)
                Console.WriteLine($"Name: {p.Name}, Country: {p.Country}\n");
        }
        public void GetTop1TeamPasses()
        {
            var res = Commands.FromSql($"Top3TeamPasses").ToList();
            Console.WriteLine($"Name: {res.ElementAt(0).Name}, Country: {res.ElementAt(0).Country}\n");
        }
        public void GetTop3TeamByScore()
        {
            var res = TournamentTop.FromSql($"Top3TeamByScore").ToList();
            foreach (var p in res)
                Console.WriteLine($"Name: {p.Name}, Wins: {p.Wins}\n");
        }
        public void GetTop1TeamByScore()
        {
            var res = TournamentTop.FromSql($"Top3TeamByScore").ToList();
            Console.WriteLine($"Name: {res.ElementAt(0).Name}, Country: {res.ElementAt(0).Wins}\n");
        }
        public void GetTop3TeamByBadScore()
        {
            var res = TournamentTop.FromSql($"Top3TeamByBadScore").ToList();
            foreach (var p in res)
                Console.WriteLine($"Name: {p.Name}, Country: {p.Wins}\n");
        }
        public void GetTop1TeamByBadScore()
        {
            var res = TournamentTop.FromSql($"Top3TeamByBadScore").ToList();
            Console.WriteLine($"Name: {res.ElementAt(0).Name}, Country: {res.ElementAt(0).Wins}\n");
        }
    }
}

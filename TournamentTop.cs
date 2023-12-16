using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCprocs
{
    public class TournamentTop
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Top { set; get; }
        public int Wins { set; get; }
        public int Loses { set; get; }
        public int Draws { set; get; }

        public TournamentTop()
        {

        }
        public TournamentTop(int id, string name, int top, int wins, int loses, int draws)
        {
            Id = id;
            Name = name;
            Top = top;
            Wins = wins;
            Loses = loses;
            Draws = draws;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Top: {Top}, Wins: {Wins}, Loses: {Loses}, Draws: {Draws}");
        }
    }
}

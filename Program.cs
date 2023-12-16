using EFCprocs;
using Microsoft.Data.SqlClient;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (TournamentTopContext db = new TournamentTopContext())
            {
                //db.GetTop3ScorersInCommand("TeamA");
                //db.GetTop1ScorersInCommand("TeamA");
                //db.GetTop3Scorers();
                //db.GetTop1Scorers();
                //db.GetTop3TeamScorers();
                //db.GetTop1TeamScorers();
                //db.GetTop3TeamPasses();
                //db.GetTop1TeamPasses();
                //db.GetTop3TeamByScore();
                //db.GetTop1TeamByScore();
                //db.GetTop3TeamByBadScore();
                //db.GetTop1TeamByBadScore();
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
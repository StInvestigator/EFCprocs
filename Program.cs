using Microsoft.Data.SqlClient;
using Mirgation06_12;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (GameContext db = new GameContext())
            {
                //db.Top3StudiosByGames();
                //db.Top1StudiosByGames();
                //db.Top3StylesByGames();
                //db.Top1StylesByGames();
                //db.Top3StylesBySoldCopies();
                //db.Top1StylesBySoldCopies();
                //db.Top3SinglePlayers();
                //db.Top1SinglePlayer();
                //db.Top3MultiPlayers();
                //db.Top1MultiPlayer();
                //db.Top1Game();
                db.DeleteGamesWithLessSoldCopies(600);
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
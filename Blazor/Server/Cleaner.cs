using E_Voting.Transfer;
using static System.Collections.Specialized.BitVector32;

namespace E_Voting
{
    public static class Cleaner
    {
        public static void Check()
        {
            while(true)
            {
                Log.Write("Cleaning the log...");
                Log.Clear();

                Log.Write("Cleaning the database...");

                List<Election> elections = Database.GetElections(true, PrivacyLevel.Admin);
                foreach (Election election in elections)
                {
                    if(election.End.AddDays(Config.ElectionCleanerThreshold) < DateTime.UtcNow)
                    {
                        Database.DeleteElection(election.ID);
                    }
                }

                Log.WriteSuccess("Cleaning done!");
                Thread.Sleep(Config.CleanerInterval * 1000);
            }
        }
    }
}

using E_Voting.Transfer;

namespace E_Voting
{
    public static class Reminder
    {
        public static void Check()
        {
            while(true)
            {
                Log.Write("Sending reminders...");

                List<Election> elections = Database.GetElections(false, PrivacyLevel.Admin);
                foreach (Election election in elections)
                {
                    if(election.Result == Config.EmptyResult && 
                    election.End.AddDays(-Config.ReminderDaysBefore) <= DateTime.UtcNow)
                    {
                        foreach(Voter voter in election.Voters)
                        {
                            if(!voter.ReminderSent && !voter.Voted)
                            {
                                Mail.SendVoterReminder(election, voter);
                                Database.UpdateVoterReminder(voter.ID);
                            }
                        }
                    }
                }

                Log.WriteSuccess("Reminders done!");
                Thread.Sleep(Config.ReminderInterval * 1000);
            }
        }
    }
}

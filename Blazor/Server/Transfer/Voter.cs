namespace E_Voting.Transfer
{
    public class Voter
    {
        private long id;
        private string mail;
        private string token;
        private bool voted;
        private bool reminder_sent;
        private long election_id;

        public long ID => id;
        public string Mail => mail;
        public string Token => token;
        public bool Voted => voted;
        public bool ReminderSent => reminder_sent;
        public long ElectionID => election_id;

        public Voter(long id, string mail, string token, bool voted, bool reminder_sent, long election_id)
        {
            this.id = id;
            this.mail = mail;
            this.token = token;
            this.voted = voted;
            this.reminder_sent = reminder_sent;
            this.election_id = election_id;
        }
    }
}

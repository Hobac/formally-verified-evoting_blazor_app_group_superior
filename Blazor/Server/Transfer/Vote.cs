namespace E_Voting.Transfer
{
    public class Vote
    {
        private long id;
        private string value;
        private long election_id;

        public string Value => value;

        public Vote(long id, string value, long election_id)
        {
            this.id = id;
            this.value = value;
            this.election_id = election_id;
        }
    }
}

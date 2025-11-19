namespace E_Voting.Transfer
{
    public class Candidate
    {
        private long id;
        private string name;
        private long election_id;

        public long ID => id;
        public string Name => name;
        public long ElectionID => election_id;

        public Candidate(long id, string name, long election_id)
        {
            this.id = id;
            this.name = name;
            this.election_id = election_id;
        }
    }

}

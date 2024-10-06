namespace CQRS_Implementation.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string ShortId { get; set; }

        //Parameterless constructor for EF core
        private User()
        {
        }

        public User(int id, string name, string emailId, string shortId)
        {
            Id  = id;
            Name = name;
            EmailId = emailId;
            ShortId = shortId;
        }

    }
}

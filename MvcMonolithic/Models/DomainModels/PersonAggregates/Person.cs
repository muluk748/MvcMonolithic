namespace MvcMonolithic.Models.DomainModels.PersonAggregates
{
    public class Person // a class of person. here we say what information we need.
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

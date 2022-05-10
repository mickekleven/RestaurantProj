namespace RestaurantProj
{
    public class Employee : People
    {
        public int Salary { get; set; }
    }


    public abstract class People
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}

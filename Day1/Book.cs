namespace Day1
{
    public class Book
    {
        public Guid Id { get; set; }

        public Book()
        {
            this.Id = Guid.NewGuid();
        }
    }
}

namespace Review.Data.Entities
{
    public class Review
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }
    }
}

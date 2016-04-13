namespace Carriers.Model
{
    public class Rating
    {
        public int Id { get; set; }
        public int CarrierId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }

        public virtual Carrier Carrier { get; set; }
    }
}

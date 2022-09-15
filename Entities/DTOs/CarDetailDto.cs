namespace Core.Entities
{
    public class CarDetailDto : IDto
    {
        public int CarID { get; set; }

        public string BrandName { get; set; }

        public string ModelName { get; set; }

        public string ColorName{ get; set; }

        public short ModelYear { get; set; }

        public decimal DailyPrice { get; set; }

        public string Description { get; set; }
    }
}

namespace DapperProject.Dtos.PropertyDtos
{
    public class GetByIdPropertyDto
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string? VideoUrl { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool ForRent { get; set; }
        public bool ForSale { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public decimal Price { get; set; }
        public int AreaSize { get; set; }
        public bool IsFeatured { get; set; }
        public int BuildAge { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string LocationName { get; set; }
        public string CategoryName { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
    }
}

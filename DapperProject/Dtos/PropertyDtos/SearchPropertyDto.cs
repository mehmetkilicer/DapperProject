namespace DapperProject.Dtos.PropertyDtos
{
    public class SearchPropertyDto
    {
        public int? CategoryId { get; set; }
        public bool IsForRent { get; set; }
        public bool IsForSale { get; set; }
        public int? MinimumBedroomCount { get; set; }
        public int? MinimumBathroomCount { get; set; }
        public decimal? MinimumPrice { get; set; }
        public decimal? MaximumPrice { get; set; }
        public int? MinimumAreaSize { get; set; }
        public int? MaximumAreaSize { get; set; }
    }
}
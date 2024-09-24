﻿namespace DapperProject.Dtos.SliderDtos
{
    public class CreateSliderDto
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}

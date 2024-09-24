namespace DapperProject.Dtos.KaggleDatasetDtos
{
    public class ResultDataDto
    {
        public int id { get; set; }
        public string BrokeredBy { get; set; } // varchar(50)
        public string Status { get; set; } // varchar(50)
        public string Price { get; set; } // varchar(50)
        public string Bed { get; set; } // varchar(50)
        public string Bath { get; set; } // varchar(50)
        public string AcreLot { get; set; } // varchar(50)
        public string Street { get; set; } // varchar(50)
        public string City { get; set; } // varchar(50)
        public string State { get; set; } // varchar(50)
        public string ZipCode { get; set; } // varchar(50)
        public string HouseSize { get; set; } // varchar(50)
    }

}

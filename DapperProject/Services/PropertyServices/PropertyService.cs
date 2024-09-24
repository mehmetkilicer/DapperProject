using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.PropertyDtos;

namespace DapperProject.Services.PropertyServices
{
    public class PropertyService : IPropertyService
    {
        private readonly DapperContext _dapperContext;

        public PropertyService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<int> CreatePropertyAsync(CreatePropertyDto dto)
        {
            var query = @"
        INSERT INTO TblProperty (
            PropertyName, 
            VideoUrl, 
            Address, 
            Description, 
            ForRent, 
            ForSale, 
            BedroomCount, 
            BathroomCount, 
            ImageUrl1, 
            ImageUrl2, 
            ImageUrl3, 
            Price, 
            AreaSize, 
            IsFeatured, 
            BuildAge, 
            CategoryId, 
            LocationId
        ) 
        VALUES (
            @PropertyName, 
            @videoUrl, 
            @address, 
            @description, 
            @ForRent, 
            @ForSale, 
            @bedroomCount, 
            @bathroomCount, 
            @imageurl1, 
            @imageurl2, 
            @imageurl3, 
            @price, 
            @areaSize, 
            @isFeatured, 
            @buildAge, 
            @categoryId, 
            @locationId
        ); 
        SELECT CAST(SCOPE_IDENTITY() as int);";

            var parameters = new DynamicParameters();
            parameters.Add("@PropertyName", dto.PropertyName);
            parameters.Add("@videoUrl", dto.VideoUrl);
            parameters.Add("@address", dto.Address);
            parameters.Add("@description", dto.Description);
            parameters.Add("@ForRent", dto.ForRent);
            parameters.Add("@ForSale", dto.ForSale);
            parameters.Add("@bedroomCount", dto.BedroomCount);
            parameters.Add("@bathroomCount", dto.BathroomCount);
            parameters.Add("@price", dto.Price);
            parameters.Add("@areaSize", dto.AreaSize);
            parameters.Add("@isFeatured", dto.IsFeatured);
            parameters.Add("@buildAge", dto.BuildAge);
            parameters.Add("@categoryId", dto.CategoryId);
            parameters.Add("@locationId", dto.LocationId);
            parameters.Add("@imageurl1", dto.ImageUrl1);
            parameters.Add("@imageurl2", dto.ImageUrl2);
            parameters.Add("@imageurl3", dto.ImageUrl3);

            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query, parameters);
            }
        }


        public async Task DeletePropertyAsync(int id)
        {
            string query = "delete from TblProperty where PropertyId=@propertyid";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyid", id);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task<List<ResultPropertyDto>> GetAllPropertyAsync()
        {
            var query = "Select * From TblProperty";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = (await connection.QueryAsync<ResultPropertyDto>(query)).ToList();


                return values;
            }
        }

        public async Task<List<ResultPropertyByIsFeatureDto>> GetAllPropertyByIsFeatureAsync()
        {
            var query = "SELECT dbo.TblProperty.*, dbo.TblLocation.Location, dbo.TblCategory.CategoryName FROM dbo.TblCategory INNER JOIN dbo.TblProperty ON dbo.TblCategory.CategoryId = dbo.TblProperty.CategoryId INNER JOIN dbo.TblLocation ON dbo.TblProperty.LocationId = dbo.TblLocation.LocationId Where dbo.TblProperty.IsFeatured=1";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = (await connection.QueryAsync<ResultPropertyByIsFeatureDto>(query)).ToList();


                return values;
            }
        }

        public async Task<ResultPropertyForDetailDto> GetPropertyForDetailAsync(int id)
        {
            var query = @"
        SELECT dbo.TblCategory.CategoryName, dbo.TblProperty.*, dbo.TblLocation.Location 
        FROM dbo.TblCategory 
        INNER JOIN dbo.TblProperty ON dbo.TblCategory.CategoryId = dbo.TblProperty.CategoryId 
        INNER JOIN dbo.TblLocation ON dbo.TblProperty.LocationId = dbo.TblLocation.LocationId 
        WHERE dbo.TblProperty.PropertyId = @PropertyId";

            using (var connection = _dapperContext.CreateConnection())
            {
                var Property = await connection.QueryFirstOrDefaultAsync<ResultPropertyForDetailDto>(query, new { PropertyId = id });



                return Property;

            }
        }


        public async Task<List<ResultPropertyWithCategoryAndLocationDto>> GetAllPropertyWithCategoryAndLocationAsync()
        {
            var query = "SELECT dbo.TblProperty.*, dbo.TblLocation.Location, dbo.TblCategory.CategoryName FROM dbo.TblCategory INNER JOIN dbo.TblProperty ON dbo.TblCategory.CategoryId = dbo.TblProperty.CategoryId INNER JOIN dbo.TblLocation ON dbo.TblProperty.LocationId = dbo.TblLocation.LocationId";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = (await connection.QueryAsync<ResultPropertyWithCategoryAndLocationDto>(query)).ToList();


                return values;
            }
        }

        public async Task<GetByIdPropertyDto> GetPropertyAsync(int id)
        {
            string query = "Select * From TblProperty Where PropertyId=@PropertyId";
            var parameter = new DynamicParameters();
            parameter.Add("@PropertyId", id);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdPropertyDto>(query, parameter);


            return values;

        }

        public async Task<List<ResultPropertyByIsFeatureDto>> GetLast4PropertyAsync()
        {
            var query = @"
        WITH RankedProperties AS (
            SELECT 
                dbo.TblProperty.*, 
                dbo.TblLocation.Location, 
                dbo.TblCategory.CategoryName,
                ROW_NUMBER() OVER (ORDER BY dbo.TblProperty.PropertyId DESC) AS RowNum
            FROM 
                dbo.TblCategory
                INNER JOIN dbo.TblProperty ON dbo.TblCategory.CategoryId = dbo.TblProperty.CategoryId
                INNER JOIN dbo.TblLocation ON dbo.TblProperty.LocationId = dbo.TblLocation.LocationId
        )
        SELECT * 
        FROM RankedProperties 
        WHERE RowNum <= 4;";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = (await connection.QueryAsync<ResultPropertyByIsFeatureDto>(query)).ToList();
                return values;
            }
        }


        public async Task UpdatePropertyAsync(UpdatePropertyDto dto)
        {
            var query = @"
        UPDATE TblProperty
        SET 
            PropertyName = @PropertyName,
            VideoUrl = @videoUrl,
            Adress = @adress,
            Description = @description,
            ForRent = @ForRent,
            ForSale = @ForSale,
            BedroomCount = @bedroomCount,
            BathroomCount = @bathroomCount,
            Price = @price,
            AreaSize = @areaSize,
            IsFeatured = @isFeatured,
            BuildAge = @buildAge,
            CategoryId = @categoryId,
            LocationId = @locationId,
            ImageUrl1 = @imageUrl1,
            ImageUrl2 = @imageUrl2,
            ImageUrl3 = @imageUrl3
        WHERE 
            PropertyId = @PropertyId";

            var parameters = new DynamicParameters();
            parameters.Add("@PropertyId", dto.PropertyId);
            parameters.Add("@PropertyName", dto.PropertyName);
            parameters.Add("@videoUrl", dto.VideoUrl);
            parameters.Add("@adress", dto.Address);
            parameters.Add("@description", dto.Description);
            parameters.Add("@ForRent", dto.ForRent);
            parameters.Add("@ForSale", dto.ForSale);
            parameters.Add("@bedroomCount", dto.BedroomCount);
            parameters.Add("@bathroomCount", dto.BathroomCount);
            parameters.Add("@price", dto.Price);
            parameters.Add("@areaSize", dto.AreaSize);
            parameters.Add("@isFeatured", dto.IsFeatured);
            parameters.Add("@buildAge", dto.BuildAge);
            parameters.Add("@categoryId", dto.CategoryId);
            parameters.Add("@locationId", dto.LocationId);
            parameters.Add("@imageUrl1", dto.ImageUrl1);
            parameters.Add("@imageUrl2", dto.ImageUrl2);
            parameters.Add("@imageUrl3", dto.ImageUrl3);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async Task<List<ResultPropertyWithCategoryAndLocationDto>> Search(SearchPropertyDto dto)
        {
            string query = @"
        SELECT * 
        FROM TblProperty 
        WHERE 
            (@CategoryId IS NULL OR [CategoryId] = @CategoryId) AND
            (@IsForRent IS NULL OR [ForRent] = @IsForRent) AND
            (@IsForSale IS NULL OR [ForSale] = @IsForSale) AND
            (@MinimumBedroomCount IS NULL OR [BedroomCount] >= @MinimumBedroomCount) AND
            (@MinimumBathroomCount IS NULL OR [BathroomCount] >= @MinimumBathroomCount) AND
            (@MinimumPrice IS NULL OR [Price] >= @MinimumPrice) AND
            (@MaximumPrice IS NULL OR [Price] <= @MaximumPrice) AND
            (@MinimumAreaSize IS NULL OR [AreaSize] >= @MinimumAreaSize) AND
            (@MaximumAreaSize IS NULL OR [AreaSize] <= @MaximumAreaSize)";

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", dto.CategoryId);
            parameters.Add("@IsForRent", dto.IsForRent);
            parameters.Add("@IsForSale", dto.IsForSale);
            parameters.Add("@MinimumBedroomCount", dto.MinimumBedroomCount);
            parameters.Add("@MinimumBathroomCount", dto.MinimumBathroomCount);
            parameters.Add("@MinimumPrice", dto.MinimumPrice);
            parameters.Add("@MaximumPrice", dto.MaximumPrice);
            parameters.Add("@MinimumAreaSize", dto.MinimumAreaSize);
            parameters.Add("@MaximumAreaSize", dto.MaximumAreaSize);

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyWithCategoryAndLocationDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast4PropertyDto>> GetLast4PropertyListAsync()
        {
            string query = "SELECT TOP 4 * FROM Last4Property"; 
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast4PropertyDto>(query);
                return values.ToList();
            }
        }

   

        public async Task<int> GetPropertyCount()
        {
            string query = "select count(*) from TblProperty";
            var connection = _dapperContext.CreateConnection();
            var value = await connection.QueryAsync<int>(query);
            return value.FirstOrDefault();
        }


        public async Task<int> GetAgentCount()
        {
            string query = "select count(*) from TblAgent";
            var connnection = _dapperContext.CreateConnection();
            var value = await connnection.QueryAsync<int>(query);
            return value.FirstOrDefault();
        }

        public async Task<int> GetTestimonialCount()
        {
            string query = "select count(*) from TblTestimonial";
            var connnection = _dapperContext.CreateConnection();
            var value = await connnection.QueryAsync<int>(query);
            return value.FirstOrDefault();
        }

        public async Task<int> PropertyForRentCount()
        {
            string query = "select count(*) from TblProperty where ForRent = 1";
            var connection = _dapperContext.CreateConnection();
            var value = await connection.QueryAsync<int>(query);
            return value.FirstOrDefault();
        }

        public async Task<int> PropertyForSaleCount()
        {
            string query = "select count(*) from TblProperty where ForSale = 1";
            var connection = _dapperContext.CreateConnection();
            var value = await connection.QueryAsync<int>(query);
            return value.FirstOrDefault();
        }

        public async Task<GetByIdPropertyWithCategoryAndLocationDto> GetByIdPropertyWithIncludeAsync(int id)
        {
            string query = "select * from TblProperty inner join TblCategory on TblProperty.CategoryId = TblCategory.CategoryId inner join TblLocation on TblProperty.LocationId = TblLocation.LocationId where PropertyId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdPropertyWithCategoryAndLocationDto>(query, parameters);
            return values;
        }
    }
}

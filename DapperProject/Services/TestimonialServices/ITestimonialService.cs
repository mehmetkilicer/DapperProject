using DapperProject.Dtos.TestimonialDtos;

namespace DapperProject.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto dto);
        Task DeleteTestimonialAsync(int id);
        Task UpdateTestimonialAsync(UpdateTestimonialDto dto);
        Task<GetByIdTestimonialDto> GetTestimonialAsync(int id);
    }
}

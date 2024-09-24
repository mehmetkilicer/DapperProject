using DapperProject.Dtos.TagDtos;

namespace DapperProject.Services.TagServices
{
    public interface ITagService
    {
        Task<List<DetailResultTagDto>> GetAllTagsByPropertyId(int id);
        Task<List<ResultTagDto>> GetAllTagAsync();

    }
}

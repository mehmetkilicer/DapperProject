using DapperProject.Dtos.PaginatedListDtos;

namespace DapperProject.Services.PaginatedServices
{
    public interface IPaginatedListService<T> 
    {
        Task<PaginatedList<T>> CreateAsync(List<T> source, int pageIndex, int pageSize);

    }
}

using DapperProject.Dtos.PaginatedListDtos;

namespace DapperProject.Services.PaginatedServices
{
    public class PaginatedListService<T> : IPaginatedListService<T>
    {
        public async Task<PaginatedList<T>> CreateAsync(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}

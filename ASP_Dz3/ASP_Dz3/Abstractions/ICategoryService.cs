using ASP_Dz3.Models;

namespace ASP_Dz3.Abstractions
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories();
        int AddCategory(CategoryDto category);
    }
}

using ASP_Dz3.Models;

namespace ASP_Dz3.Abstractions
{
    public interface IStorageService
    {
        IEnumerable<StorageDto> GetStorages();
        int AddStorage(StorageDto storage);
    }
}

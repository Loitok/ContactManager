using ContactManager.Data.Models.Result.Generics;
using ContactManager.Data.Models.Result.Interfaces;
using ContactManager.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManager.Services.Abstractions
{
    public interface IContactManagerService
    {
        Task<IResult<IList<FileViewModel>>> GetAllFilesAsync();

        Task<IResult<int>> CreateFileAsync(IList<CsvBaseViewModel> model, string fileName);

        Task<IResult<IList<CsvViewModel>>> GetAllRowsInFileAsync(int fileId);

        Task<IResult> UpdateRowAsync(CsvViewModel model);

        Task<IResult> DeleteRowAsync(int rowId);
    }
}

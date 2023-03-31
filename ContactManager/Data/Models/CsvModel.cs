using ContactManager.ViewModels;

namespace ContactManager.Data.Models
{
    public class CsvModel : CsvViewModel
    {
        public FileModel File { get; set; }
        public int FileId { get; set; }
    }
}

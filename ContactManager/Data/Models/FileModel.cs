using ContactManager.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Data.Models
{
    public class FileModel : FileViewModel
    {
        public FileModel()
        {
            Csvs = new List<CsvModel>();
        }
        public List<CsvModel> Csvs { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ContactManager.ViewModels
{
    public class CsvViewModel : CsvBaseViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}

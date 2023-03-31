using System.ComponentModel.DataAnnotations;

namespace ContactManager.ViewModels
{
    public class FileViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

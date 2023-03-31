using AutoMapper;
using ContactManager.Data.Models;
using ContactManager.ViewModels;

namespace ContactManager.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FileModel, FileViewModel>();

            CreateMap<CsvModel, CsvBaseViewModel>();
            CreateMap<CsvBaseViewModel, CsvModel>();

            CreateMap<CsvModel, CsvViewModel>();
            CreateMap<CsvViewModel, CsvModel>();
        }
    }
}

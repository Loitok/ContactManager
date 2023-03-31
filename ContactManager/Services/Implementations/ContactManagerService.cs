using AutoMapper;
using ContactManager.Data.Contexts;
using ContactManager.Data.Models;
using ContactManager.Data.Models.Result.Generics;
using ContactManager.Data.Models.Result.Implementations;
using ContactManager.Data.Models.Result.Interfaces;
using ContactManager.Services.Abstractions;
using ContactManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Services.Implementations
{
    public class ContactManagerService : IContactManagerService
    {
        private readonly ContactManagerContext _context;

        private readonly IMapper _mapper;

        public ContactManagerService(ContactManagerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IResult<IList<FileViewModel>>> GetAllFilesAsync()
        {
            try
            {
                var files = await _context.FileModels
                    .AsNoTracking()
                    .ToListAsync();

                var viewModels = _mapper.Map<List<FileViewModel>>(files);

                return Result<List<FileViewModel>>.CreateSuccess(viewModels);
            }
            catch (Exception e)
            {
                return Result<IList<FileViewModel>>.CreateFailure("Get Files Error", e);
            }
        }

        public async Task<IResult<int>> CreateFileAsync(IList<CsvBaseViewModel> model, string fileName)
        {
            try
            {
                var records = _mapper.Map<List<CsvModel>>(model);

                var newFile = new FileModel
                {
                    Name = fileName
                };

                newFile.Csvs.AddRange(records);

                _context.FileModels.Add(newFile);

                await _context.SaveChangesAsync();

                var fileId = newFile.Id;

                return Result<int>.CreateSuccess(fileId);
            }
            catch (Exception e)
            {
                return Result<int>.CreateFailure("Create File Error", e);
            }
        }

        public async Task<IResult<IList<CsvViewModel>>> GetAllRowsInFileAsync(int fileId)
        {
            try
            {
                var rows = await _context.CsvModels
                    .AsNoTracking()
                    .Where(x => x.FileId == fileId)
                    .ToListAsync();

                var viewModels = _mapper.Map<List<CsvViewModel>>(rows);

                return Result<List<CsvViewModel>>.CreateSuccess(viewModels);
            }
            catch (Exception e)
            {
                return Result<IList<CsvViewModel>>.CreateFailure("Get Rows Error", e);
            }
        }

        public async Task<IResult> UpdateRowAsync(CsvViewModel model)
        {
            try
            {
                var row = await _context.CsvModels
                    .FirstOrDefaultAsync(x => x.Id == model.Id);

                _mapper.Map(model, row);

                await _context.SaveChangesAsync();

                return Result.CreateSuccess();
            }
            catch (Exception e)
            {
                return Result.CreateFailure("Update Row Error", e);
            }
        }

        public async Task<IResult> DeleteRowAsync(int rowId)
        {
            try
            {
                var row = await _context.CsvModels
                    .FirstOrDefaultAsync(x => x.Id == rowId);

                if (row is null)
                    return Result.CreateFailure("Row not find!");

                _context.CsvModels.Remove(row);

                await _context.SaveChangesAsync();

                return Result.CreateSuccess();
            }
            catch (Exception e)
            {
                return Result.CreateFailure("Delete Books Error", e);
            }
        }
    }
}

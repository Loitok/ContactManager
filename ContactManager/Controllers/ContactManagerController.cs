using AutoMapper;
using ContactManager.Services.Abstractions;
using ContactManager.ViewModels;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    public class ContactManagerController : Controller
    {
        private readonly IContactManagerService _service;
        private readonly IMapper _mapper;

        public ContactManagerController(IContactManagerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<FileViewModel>>> UploadCsv()
        {
            var result = await _service.GetAllFilesAsync();
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;

            return View(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile(IFormFile file)
        {
            var model = new List<CsvBaseViewModel>();

            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("file", "Please select a CSV file to upload.");

                return View("UploadCsv");
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    model = csv
                        .GetRecords<CsvBaseViewModel>()
                        .ToList();
                }
            }

            var result = await _service.CreateFileAsync(model, file.FileName);
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;


            return RedirectToAction("ViewCsv", new { fileId = result.Data });
        }


        public async Task<ActionResult<IEnumerable<CsvViewModel>>> ViewCsv(int fileId)
        {
            var result = await _service.GetAllRowsInFileAsync(fileId);
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;

            return View(result.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRow([FromForm] CsvViewModel model)
        {
            var result = await _service.UpdateRowAsync(model);
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;

            return Json("Update Row Success!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRow(int rowId)
        {
            var result = await _service.DeleteRowAsync(rowId);
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;

            return Json("Delete Row Success!");
        }
    }
}

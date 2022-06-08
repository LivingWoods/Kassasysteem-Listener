using Microsoft.AspNetCore.Mvc;
using RegisterAPI.Models;
using RegisterAPI.Services;

namespace RegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterController
    {
        private readonly IPrinterService _printerService;

        public PrinterController(IPrinterService printerService)
        {
            _printerService = printerService;
        }  

        [HttpGet("{id}")]
        public async Task<Printer> GetPrinter(int id)
        {
           return await _printerService.GetPrinter(id);
        }

        [HttpPost]
        public async Task CreatePrinter([FromBody]Printer printer)
        {
            await _printerService.CreatePrinter(printer);
        }
    }
}

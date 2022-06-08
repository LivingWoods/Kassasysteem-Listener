using Kassa.Services;
using Kassa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Kassa.Hubs;

namespace Kassa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterController
    {
        private readonly IPrinterService _printerService;
        private readonly IHubContext<PrinterHub> _hubContext;

        public PrinterController(IPrinterService printerService, IHubContext<PrinterHub> hubContext)
        {
            _printerService = printerService;
            _hubContext = hubContext;
        }

        [HttpGet()]
        public async Task<IEnumerable<Printer>> GetPrinters()
        {
            return await _printerService.GetPrinters();
        }

        [HttpGet("{id}")]
        public async Task<Printer> GetPrinter(int id)
        {
            return await _printerService.GetPrinter(id);
        }

        [HttpPatch("{interfaceId}")]
        public async Task<Printer> updatePrinterTellerstand(int interfaceId)
        {
            Printer printer = await _printerService.UpdatePrinterTellerstandByInterface(interfaceId);
            if (printer != null)
            {
                _hubContext.Clients.All.SendAsync("ReceivePrinterStatus", printer.PrinterId, printer.PrinterHuidigeTeller);
            }

            return printer;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RegisterAPI.Services;

namespace RegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterStaffelController
    {
        private readonly IPrinterStaffelService _printerStaffelService;

        public PrinterStaffelController(IPrinterStaffelService printerStaffelService)
        {
            _printerStaffelService = printerStaffelService;
        }
    }
}

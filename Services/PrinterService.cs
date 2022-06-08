using Kassa.Models;
using Kassa.Repositories;

namespace Kassa.Services
{
    public class PrinterService : IPrinterService
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterService(IPrinterRepository printerRepository)
        {
            this._printerRepository = printerRepository;
        }

        public async Task<IEnumerable<Printer>> GetPrinters()
        {
            return await this._printerRepository.GetPrinters();
        }

        public async Task<Printer> GetPrinter(int id)
        {
            return await this._printerRepository.GetPrinter(id);
        }

        public async Task<Printer> UpdatePrinterTellerstandByInterface(int interfaceId)
        {
            return await this._printerRepository.UpdatePrinterTellerstandByInterface(interfaceId);
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using Kassa.Models;

namespace Kassa.Hubs
{
    public class PrinterHub : Hub
    {
        public async Task SendPrinterStatus(int PrinterId, int PrinterHuidigeTeller)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(PrinterId);
                Console.WriteLine(PrinterId);
                await Clients.All.SendAsync("ReceivePrinterStatus", PrinterId, PrinterHuidigeTeller);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        public async Task UpdatePrinter(int PrinterId, int PrinterHuidigeTeller)
        {
            await Clients.All.SendAsync("ReceivePrinterStatus", PrinterId, PrinterHuidigeTeller);
        }
        /*public async Task ReceivePrinterUpdate()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }*/
    }
}

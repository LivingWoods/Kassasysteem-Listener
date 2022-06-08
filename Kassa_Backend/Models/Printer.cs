using System.ComponentModel.DataAnnotations.Schema;

namespace Kassa_Backend.Models
{
    [Table("Printers")]
    public class Printer
    {       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int printerId { get; private set; }
        public string printerNaam { get; private set; }
        public int printerInterface { get; private set; }
        public int printerHuidigeTeller { get; private set; }

        public List<PrinterStaffel> printerStaffels { get; set; }

        public Printer()
        {

        }

        /*public Printer(int printerId, string printerNaam, int printerInterface, int printerHuidigeTeller, List<PrinterStaffel> printerStaffels)
        {
            this.printerId = printerId;
            this.printerNaam = printerNaam;
            this.printerInterface = printerInterface;
            this.printerHuidigeTeller = printerHuidigeTeller;
            this.printerStaffels = printerStaffels;
        }*/
    }
}

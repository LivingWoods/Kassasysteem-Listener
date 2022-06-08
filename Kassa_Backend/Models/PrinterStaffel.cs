using System.ComponentModel.DataAnnotations.Schema;


namespace Kassa_Backend.Models
{
    [Table("PrinterStaffels")]
    public class PrinterStaffel
    {
        public int printerStaffelId { get; private set; }

        [ForeignKey("printerId")]

        public int printerId { get; private set; }

        public int ondergrens { get; private set; } 
        
        public int bovengrens { get; private set; } 

        public double prijs { get; private set; }

        public Printer printer { get; private set; }

        public PrinterStaffel()
        {

        }

        /*public PrinterStaffel(int printerStaffelId, int printerId, int ondergrens, int bovengrens, double prijs)
        {
            this.printerStaffelId = printerStaffelId;
            this.printerId = printerId;
            this.ondergrens = ondergrens;
            this.bovengrens = bovengrens;
            this.prijs = prijs;
        }*/
    }
}
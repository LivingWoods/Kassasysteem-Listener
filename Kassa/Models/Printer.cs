namespace Kassa.Models
{
    public class Printer
    {
        public int PrinterId { get; set; }
        public string PrinterNaam { get; set; }
        public int PrinterInterface { get; set; }
        public int PrinterHuidigeTeller { get; set; }
        public virtual List<PrinterStaffel> PrinterStaffels { get; set; }
    }
}

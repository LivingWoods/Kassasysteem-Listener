namespace RegisterAPI.Models
{

    public class Printer
    {
        public int PrinterId { get; set; }
        public string PrinterNaam { get; set; }
        public int PrinterInterface { get; set; }
        public int PrinterHuidigeTeller { get; set; }
        public List<PrinterStaffel> PrinterStaffels { get; set; } = new List<PrinterStaffel>();

    }
}

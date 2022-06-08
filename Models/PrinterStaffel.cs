namespace Kassa.Models
{
    public class PrinterStaffel
    {
        public int PrinterStaffelId { get; set; }
        public int PrinterId { get; set; }
        public int Ondergrens { get; set; }
        public int Bovengrens { get; set; }
        public double Prijs { get; set; }
    }
}

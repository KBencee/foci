using System.ComponentModel.DataAnnotations;

namespace FociWebApp.Models
{
    public class Meccs
    {
        [Key]
        public int Id { get; set; }
        public int Fordulo { get; set; }
        public int HazaiVeg {  get; set; }
        public int VendegVeg { get; set; }
        public int HazaiFelido { get; set; }
        public int VendegFelido { get; set; }
        public string HazaiCsapat {  get; set; }
        public string VendegCsapat { get; set; }
    }
}

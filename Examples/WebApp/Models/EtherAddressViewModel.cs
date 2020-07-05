using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class EtherAddressViewModel
    {
        [Required]
        public string Address { get; set; }
    }
}
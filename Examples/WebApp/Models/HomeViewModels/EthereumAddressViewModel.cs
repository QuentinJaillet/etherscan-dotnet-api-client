using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.HomeViewModels
{
    public class EthereumAddressViewModel
    {
        [Required]
        public string Address { get; set; }
    }
}
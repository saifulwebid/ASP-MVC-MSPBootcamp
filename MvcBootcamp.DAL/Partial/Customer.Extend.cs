using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcBootcamp.DAL
{
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {

    }

    public class CustomerMetadata
    {
        [Display(Name = "Customer ID")]
        [Required(ErrorMessage = "Customer ID harus diisi.")]
        [StringLength(5, ErrorMessage = "Customer ID maksimal 5 karakter.")]
        [Remote("CheckCustomerID", "Customers", ErrorMessage = "Customer ID tersebut sudah ada.")]
        public string CustomerID { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name harus diisi.")]
        [StringLength(40, ErrorMessage = "Company Name maksimal 40 karakter.")]
        public string CompanyName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.ViewModels
{
    public class SupplierViewModel
    {
       
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Document { get; set; }

        public int TypeSupplier { get; set; }

        public bool Active { get; set; }

    }

    public class SupplierViewModelUpdate
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Document { get; set; }

        public int TypeSupplier { get; set; }

        public bool Active { get; set; }

    }
}

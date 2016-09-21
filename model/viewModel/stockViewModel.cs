using System.ComponentModel.DataAnnotations;

namespace model.viewModel
{
    public class stockViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Code can be maximum 15 length")]
        public string code { get; set; }

        [StringLength(20, ErrorMessage = "Name can be maximum 20 length")]
        public string name { get; set; }

        [DataType(DataType.Currency)]
        public int quantity { get; set; }

        public int price { get; set; }

        public string user_guid { get; set; }
    }
}

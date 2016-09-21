using System.ComponentModel.DataAnnotations;

namespace model.viewModel
{
  public  class stockSettingsViewModel
    {
        [Required]
        [DataType(DataType.Currency)]
        public int ticker_minute { get; set; }

        public string user_guid { get; set; }
    }
}

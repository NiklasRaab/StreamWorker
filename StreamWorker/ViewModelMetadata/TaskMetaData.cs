using System.ComponentModel.DataAnnotations;

namespace StreamWorker.ViewModelMetadata
{
    public class TaskMetaData
    {

        [Required]
        [Display(Name = "Preis", Description = "")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }

    class DescriptionTimeLineEntryMetaData
    {
        [Required]
        [Display(Name = "Beschreibung")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
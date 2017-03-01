using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Framework.Mvc.ViewModel;
using Heroic.AutoMapper;
using StreamWorker.Data.Models;
using StreamWorker.ViewModelMetadata;

namespace StreamWorker.ViewModels.Task
{
    [MetadataType(typeof(TaskMetaData))]
    public class CreateTaskViewModel : BaseViewModel, IMapFrom<Data.Models.Task>
    {
        public IList<TimeLineEntryViewModel> TimeLineEntryViewModels { get; set; } = new List<TimeLineEntryViewModel>();

        public decimal Price { get; set; }
    }

    public class TimeLineEntryViewModel : BaseViewModel, IMapFrom<TimeLineEntry>
    {
        public override string ConcreteModelType => base.ConcreteModelType;
    }

    [MetadataType(typeof(DescriptionTimeLineEntryMetaData))]
    public class DescriptionTimeLineEntryViewModel : TimeLineEntryViewModel, IMapFrom<TimeLineEntry>
    {
        public string Description { get; set; }
    }
}
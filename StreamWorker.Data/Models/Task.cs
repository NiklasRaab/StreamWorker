using System.Collections.Generic;

namespace StreamWorker.Data.Models
{
    public class Task : StreamWorkerEntity
    {
        public decimal Price { get; set; }

        public IEnumerable<TimeLineEntry> TimeLine { get; set; }

        public virtual StreamWorkerUser StreamWorkerUser { get; set; }
    }

    public abstract class TimeLineEntry : StreamWorkerEntity
    {
        public virtual StreamWorkerUser ModifiedBy { get; set; }
    }

    public class TaskModifiedTimeLineEntry : TimeLineEntry
    {
        public EditType EditType { get; set; }
    }

    public class DescriptionTimeLineEntry : TimeLineEntry
    {
        public string Description { get; set; }
    }

    public enum EditType
    {
        Created,
        Updated,
        Deleted
    }
}
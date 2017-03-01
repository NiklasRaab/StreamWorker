using Framework.Data.Model;

namespace StreamWorker.Data.Models
{
    public class StreamWorkerEntity : BaseEntity
    {
        public StreamWorkerUser Creator { get; set; }
        public StreamWorkerUser LastEditor { get; set; }
    }
}
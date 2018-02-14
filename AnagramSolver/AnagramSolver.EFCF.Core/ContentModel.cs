using AnagramSolver.EFCF.Core.Model;

namespace AnagramSolver.EFCF.Core
{
    public class ContentModel
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int TaskId { get; set; }
        public virtual TaskModel Task { get; set; }
    }
}

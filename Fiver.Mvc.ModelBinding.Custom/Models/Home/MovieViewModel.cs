using Fiver.Mvc.ModelBinding.Custom.Lib;

namespace Fiver.Mvc.ModelBinding.Custom.Models.Home
{
    public class MovieViewModel
    {
        [ProtectedId]
        public string Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Summary { get; set; }
    }
}

using Fiver.Mvc.ModelBinding.Custom.Lib;

namespace Fiver.Mvc.ModelBinding.Custom.Models.Home
{
    public class MovieInputModel
    {
        [ProtectedId]
        public string Id { get; set; }
        public string Title { get; set; }
    }
}

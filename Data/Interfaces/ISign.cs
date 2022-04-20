using Data.Enums;

namespace Data.Interfaces
{
    public interface ISign : IModelBase
    {        
        string Title { get; set; }
        string Description { get; set; }
        SignType Type { get; set; }
    }
}
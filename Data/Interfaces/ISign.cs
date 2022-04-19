using Data.Enums;

namespace Data.Interfaces
{
    public interface ISign : IModelBase
    {        
        string Title { get; set; }
        SignType Type { get; set; }
    }
}
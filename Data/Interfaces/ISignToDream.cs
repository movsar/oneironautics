namespace Data.Interfaces
{
    public interface ISignToDream : IModelBase
    {
        string DreamId { get; }
        string SignId { get; }
    }
}
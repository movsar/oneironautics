namespace Data.Models
{
    public interface ISign
    {
        string Title { get; set; }
        Sign.SignType Type { get; set; }
    }
}
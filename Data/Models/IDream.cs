using MongoDB.Bson;
using System;

namespace Data.Models
{
    public interface IDream : IModelBase
    {
        int Index { get; set; }
        string Content { get; set; }
        string Notes { get; set; }
        DateTimeOffset DreamDateTime { get; set; }

        LucidityLevel Lucidity { get; set; }
        SleepingPosition Position { get; set; }
    }
}
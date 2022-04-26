using MongoDB.Bson;
using System;
using Data.Enums;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IDream : IModelBase
    {
        int Index { get; set; }
        string Title { get; set; }
        string Content { get; set; }
        string Notes { get; set; }
        DateTimeOffset DreamDateTime { get; set; }
        LucidityLevel Lucidity { get; set; }
        SleepingPosition Position { get; set; }
        IList<string> AssociatedSignIds { get; set; }
    }
}
using MongoDB.Bson;
using System;

namespace Data.Models
{
    public interface IDream : IModelBase
    {
        string Title { get; set; }
        string Content { get; set; }
     
        int Lucidity { get; set; }
        string Notes { get; set; }

        SleepingPosition Position { get; set; }
    }
}
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oneironautics.ViewModels
{
    internal class DreamViewModel : ViewModelBase
    {
        public int DreamId { get; }
        public string Content { get; }
        public string Title { get; }
        public string Notes { get; }
        public DateTimeOffset DreamDateTime { get; }

        public LucidityLevel Lucidity { get; }
        public SleepingPosition Position { get; }

        public DreamViewModel(IDream dream)
        {
            DreamId = dream.DreamId;
            Content = dream.Content;
            Title = dream.Title;
            Notes = dream.Notes;   
            Position = dream.Position;
            Lucidity = dream.Lucidity;
            DreamDateTime = dream.DreamDateTime;
        }

    
    }
}

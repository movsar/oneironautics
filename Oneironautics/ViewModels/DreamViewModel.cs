using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using MongoDB.Bson;
using Data.Enums;
using Data.Models;

namespace DesktopApp.ViewModels
{
    public class DreamViewModel : ViewModelBase
    {
        private readonly IDream _dream;
        public DreamViewModel(IDream dream) => _dream = dream;
        public string DreamId => _dream.Id;
        public string Index => $"#{_dream.Index}";
        public string Content => _dream.Content;
        public string Notes => _dream.Notes;
        public DateTimeOffset DreamDateTime => _dream.DreamDateTime;
        public LucidityLevel Lucidity => _dream.Lucidity;
        public SleepingPosition Position => _dream.Position;
    }
}

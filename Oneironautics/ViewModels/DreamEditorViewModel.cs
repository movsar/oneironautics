using Data.Models;
using DesktopApp.Models;
using DesktopApp.Stores;
using DesktopApp.Commands;
using DesktopApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopApp.ViewModels
{
    internal class DreamEditorViewModel : ViewModelBase
    {
        public ICommand CloseWindowAction { get; }
        public ICommand SaveDreamAction { get; }

        public IEnumerable<string> SleepingPositions { get; set; } = Enum.GetNames(typeof(SleepingPosition));
        public IEnumerable<string> LucidityLevels { get; set; } = Enum.GetNames(typeof(LucidityLevel));

        private SleepingPosition _sleepingPosition;
        public SleepingPosition SleepingPosition
        {
            get { return _sleepingPosition; }
            set
            {
                _sleepingPosition = value;
                OnPropertyChanged(nameof(SleepingPosition));
            }
        }

        private LucidityLevel _lucidityLevel;
        public LucidityLevel LucidityLevel
        {
            get { return _lucidityLevel; }
            set
            {
                _lucidityLevel = value;
                OnPropertyChanged(nameof(LucidityLevel));
            }
        }

        private string _content = "";
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        private string _notes = "";
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }

        private DateTime _dreamDateTime = DateTime.Now;
        public DateTime DreamDateTime
        {
            get
            {
                return _dreamDateTime;
            }
            set
            {
                _dreamDateTime = value;
                OnPropertyChanged(nameof(DreamDateTime));
            }
        }

        public DreamEditorViewModel(JournalStore journalStore, WindowActions windowActions, IDream? dream = null)
        {
            // Load dream data (when opening existing dream)
            if (dream != null)
            {
                Content = dream.Content;
                Notes = dream.Notes;
                DreamDateTime = new DateTime(dream.DreamDateTime.Ticks);
                SleepingPosition = dream.Position;
                LucidityLevel = dream.Lucidity;
            }
            
            CloseWindowAction = new DreamEditorCommands.Close(windowActions);
            SaveDreamAction = new DreamEditorCommands.Save(journalStore, windowActions, this, dream);
        }
    }
}

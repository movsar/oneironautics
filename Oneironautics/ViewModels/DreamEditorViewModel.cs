using Data.Interfaces;
using DesktopApp.Models;
using DesktopApp.Stores;
using DesktopApp.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Data.Enums;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopApp.ViewModels
{
    internal class DreamEditorViewModel : UiElementBase
    {
        public ICommand CloseWindowAction { get; }
        public ICommand SaveDreamAction { get; }
        public ICommand AddNewSign { get; }
        public ICommand DeleteSign { get; }
        public ICommand EditSign { get; }

        public ObservableCollection<SignViewModel> Signs { get; } = new();
        public ObservableCollection<SignViewModel> AwarenessSigns
        {
            get
            {
                var innerAwarenessSigns = Signs.Where(sign => sign.Type == SignType.InnerAwareness);
                var signs = new ObservableCollection<SignViewModel>();
                foreach (var sign in innerAwarenessSigns)
                {
                    signs.Add(sign);
                }
                return signs;
            }
        }

        public IEnumerable<SignViewModel> ActionSigns =>
            Signs.Where(sign => sign.Type == SignType.Action);
        public IEnumerable<SignViewModel> FormSigns =>
            Signs.Where(sign => sign.Type == SignType.Form);
        public IEnumerable<SignViewModel> ContextSigns =>
            Signs.Where(sign => sign.Type == SignType.Context);

        public IEnumerable<string> SleepingPositions { get; set; } = Enum.GetNames(typeof(SleepingPosition));
        public IEnumerable<string> LucidityLevels { get; set; } = Enum.GetNames(typeof(LucidityLevel));

        private SleepingPosition _sleepingPosition;
        public SleepingPosition SleepingPosition
        {
            get { return _sleepingPosition; }
            set
            {
                _sleepingPosition = value;
                SetProperty(ref _sleepingPosition, value, nameof(SleepingPosition));
            }
        }

        private LucidityLevel _lucidityLevel;
        public LucidityLevel LucidityLevel
        {
            get { return _lucidityLevel; }
            set
            {
                _lucidityLevel = value;
                SetProperty(ref _lucidityLevel, value, nameof(LucidityLevel));
            }
        }

        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                SetProperty(ref _content, value, nameof(Content));
            }
        }

        private string _notes;
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                SetProperty(ref _notes, value, nameof(Notes));
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
                SetProperty(ref _dreamDateTime, value, nameof(DreamDateTime));
            }
        }

        private string[] _checkedSignIds;

        private void LoadSignsForTheDream()
        {
            var signsAsViewModels = _journalStore.Signs.Select(sign => new SignViewModel()
            {
                Id = sign.Id,
                Title = sign.Title,
                Type = sign.Type,
                Description = sign.Description,
                IsChecked = _checkedSignIds != null && _checkedSignIds.Contains(sign.Id)
            });

            Signs.Clear();

            foreach (var signViewModel in signsAsViewModels)
            {
                Signs.Add(signViewModel);
            }
        }
        private readonly JournalStore _journalStore;
        public DreamEditorViewModel(Journal journal, JournalStore journalStore, WindowActions windowActions, IDream? dream = null)
        {
            // Load dream data (when opening existing dream)
            _journalStore = journalStore;

            if (dream != null)
            {
                Content = dream.Content;
                Notes = dream.Notes;
                DreamDateTime = new DateTime(dream.DreamDateTime.Ticks);
                SleepingPosition = dream.Position;
                LucidityLevel = dream.Lucidity;

                _checkedSignIds = journal.GetSignIdsByDreamAssociations(dream.Id);
            }

            LoadSignsForTheDream();

            CloseWindowAction = new DreamEditorCommands.Close(windowActions);
            SaveDreamAction = new DreamEditorCommands.Save(journal, journalStore, windowActions, this, dream);

            AddNewSign = new DreamEditorCommands.AddNewSign(journalStore);
            EditSign = new DreamEditorCommands.EditSign(journalStore);
            DeleteSign = new DreamEditorCommands.DeleteSign(journalStore, this);

            journalStore.SignDeleted += OnSignDeleted;
        }

        private void OnSignDeleted(ISign sign)
        {
            LoadSignsForTheDream();
            switch (sign.Type)
            {
                case SignType.InnerAwareness:
                    OnPropertyChanged(nameof(AwarenessSigns));
                    break;
                case SignType.Action:
                    OnPropertyChanged(nameof(ActionSigns));
                    break;
                case SignType.Form:
                    OnPropertyChanged(nameof(FormSigns));
                    break;
                case SignType.Context:
                    OnPropertyChanged(nameof(ContextSigns));
                    break;
            }

        }
    }
}

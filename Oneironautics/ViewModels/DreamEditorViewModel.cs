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
    internal class DreamEditorViewModel : ViewModelBase
    {
        public ICommand Close { get; }
        public ICommand Save { get; }
        public ICommand AddNewSign { get; }
        public ICommand DeleteSign { get; }
        public ICommand EditSign { get; }

        public ObservableCollection<SignViewModel> Signs { get; } = new();
        public IEnumerable<SignViewModel> AwarenessSigns =>
            Signs.Where(sign => sign.SignType == SignType.InnerAwareness);
        public IEnumerable<SignViewModel> ActionSigns =>
            Signs.Where(sign => sign.SignType == SignType.Action);
        public IEnumerable<SignViewModel> FormSigns =>
            Signs.Where(sign => sign.SignType == SignType.Form);
        public IEnumerable<SignViewModel> ContextSigns =>
            Signs.Where(sign => sign.SignType == SignType.Context);

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

        private void SetSignsCheckedStatus(IList<string> checkedSignIds)
        {
            foreach (var signViewModel in Signs)
            {
                signViewModel.IsSelected = checkedSignIds.Contains(signViewModel.SignId);
            }
        }
        private readonly JournalStore _journalStore;
        public DreamEditorViewModel(JournalStore journalStore, string? dreamId = null)
        {
            // Load dream data (when opening existing dream)
            _journalStore = journalStore;
            var dream = _journalStore.Dreams.FirstOrDefault(d => d.Id == dreamId);

            // Load all signs
            foreach (var sign in _journalStore.Signs)
            {
                Signs.Add(new SignViewModel(sign));
            }

            if (dream != null)
            {
                Content = dream.Content;
                Notes = dream.Notes;
                DreamDateTime = new DateTime(dream.DreamDateTime.Ticks);
                SleepingPosition = dream.Position;
                LucidityLevel = dream.Lucidity;
                SetSignsCheckedStatus(dream.AssociatedSignIds);
            }

            Close = new DreamEditorCommands.Close();
            Save = new DreamEditorCommands.Save(journalStore, this, dream);

            AddNewSign = new DreamEditorCommands.AddNewSign(journalStore);
            EditSign = new DreamEditorCommands.EditSign(journalStore);
            DeleteSign = new DreamEditorCommands.DeleteSign(journalStore, this);

            journalStore.ItemAdded += OnSignAdded;
            journalStore.ItemUpdated += OnSignUpdated;
            journalStore.ItemDeleted += OnSignDeleted;
        }

        private void OnSignAdded(IModelBase model)
        {
            if (model.GetType().IsAssignableTo(typeof(ISign)) == false) return;

            var sign = model as ISign;
            Signs.Add(new SignViewModel(sign));
            OnSignChanged(sign);
        }

        private void OnSignUpdated(IModelBase model)
        {
            if (model.GetType().IsAssignableTo(typeof(ISign)) == false) return;

            var sign = model as ISign;
            var index = Signs.ToList().FindIndex(s => s.SignId == sign!.Id);
            Signs[index] = new SignViewModel(sign, Signs[index].IsSelected);
            OnSignChanged(sign);
        }

        private void OnSignDeleted(IModelBase model)
        {
            if (model.GetType().IsAssignableTo(typeof(ISign)) == false) return;

            var sign = model as ISign;
            var index = Signs.ToList().FindIndex(s => s.SignId == sign!.Id);
            Signs.RemoveAt(index);
            OnSignChanged(sign);
        }

        private void OnSignChanged(ISign sign)
        {
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

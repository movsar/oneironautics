﻿using Data.Models;
using Oneironautics.Commands;
using Oneironautics.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Oneironautics.ViewModels
{
    internal class DreamEditorViewModel : ViewModelBase
    {
        public ICommand SaveDreamAction { get; }

        private string _title = "";
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

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

        public DreamEditorViewModel(NavigationStore navigationStore)
        {
            SaveDreamAction = new DreamEditorCommands.SaveDream(this, navigationStore);
        }
    }
}
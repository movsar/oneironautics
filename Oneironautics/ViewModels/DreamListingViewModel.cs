using Data;
using Data.Models;
using Oneironautics.Commands;
using Oneironautics.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Oneironautics.ViewModels
{
    internal class DreamListingViewModel : ViewModelBase
    {
        public readonly ObservableCollection<IDream> _dreams;
        public ICommand AddNewDreamAction { get; }

        public IEnumerable<IDream> Dreams => _dreams;

        public DreamListingViewModel(NavigationStore navigationStore)
        {
            _dreams = new ObservableCollection<IDream>();

            foreach (var dream in Storage.DreamsRepository.GetAll<Dream>())
            {
                _dreams.Add(dream);
            }
            AddNewDreamAction = new DreamListingCommands.AddNewDream(navigationStore);
        }

    }
}

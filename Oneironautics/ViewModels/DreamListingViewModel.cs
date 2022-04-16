using Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oneironautics.ViewModels
{
    internal class DreamListingViewModel : ViewModelBase
    {
        public readonly ObservableCollection<DreamViewModel> _dreams;
        public IEnumerable<DreamViewModel> Dreams => _dreams;

        public DreamListingViewModel()
        {
            _dreams = new ObservableCollection<DreamViewModel>();

            _dreams.Add(new DreamViewModel(new Dream()
            {
                DreamId = 1,
                Title = "Whatever",
                Content = "Lorem ipsum",
                DreamDateTime = DateTime.Now.AddDays(-2),
                Lucidity = LucidityLevel.Transient,
                Position = SleepingPosition.Left
            }));
        }
    }
}

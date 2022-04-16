using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oneironautics.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }
        public MainViewModel() {
            CurrentViewModel = new DreamListingViewModel();



            //Storage.Initialize(cleanStart: true);

            //// Add new Dream
            //Dream myDream = new Dream()
            //{
            //    Content = "I was dreaming and dreamt about something weird",
            //    Lucidity = 2,
            //    Position = SleepingPosition.Left,
            //    Title = "Weirdness"
            //};

            //Storage.DreamsRepository.Add(myDream);
            //myDream = Storage.DreamsRepository.FindByTitle(myDream.Title).FirstOrDefault();
            //ShowDreamInfo(myDream);

            //// Update Title
            //myDream.Title = "New Title";

            //Storage.DreamsRepository.Update(myDream);

            //myDream = Storage.DreamsRepository.GetById<Dream>(myDream.Id);
            //ShowDreamInfo(myDream);

            //void ShowDreamInfo(IDream dream)
            //{
            //    Debug.WriteLine("=================================");
            //    Debug.WriteLine(dream.Title);
            //    Debug.WriteLine($"CreatedAt: { dream.CreatedAt}");
            //    Debug.WriteLine($"ModifiedAt: { dream.ModifiedAt}");
            //}

        }
    }
}

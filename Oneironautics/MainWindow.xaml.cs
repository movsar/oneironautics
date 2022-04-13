using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oneironautics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Storage.Initialize(cleanStart: true);

            // Add new Dream
            Dream myDream = new Dream()
            {
                Content = "I was dreaming and dreamt about something weird",
                Lucidity = 2,
                Position = SleepingPosition.Left,
                Title = "Weirdness"
            };

            Storage.DreamsRepository.Add(myDream);
            myDream = Storage.DreamsRepository.FindByTitle(myDream.Title).FirstOrDefault();
            ShowDreamInfo(myDream);

            System.Threading.Thread.Sleep(2500);
            // Update Title
            myDream.Title = "New Title";

            Storage.DreamsRepository.Update(myDream);

            myDream = Storage.DreamsRepository.GetById<Dream>(myDream.Id);
            ShowDreamInfo(myDream);

            void ShowDreamInfo(IDream dream)
            {
                Debug.WriteLine("=================================");
                Debug.WriteLine(dream.Title);
                Debug.WriteLine($"CreatedAt: { dream.CreatedAt}");
                Debug.WriteLine($"ModifiedAt: { dream.ModifiedAt}");
            }

        }
    }
}

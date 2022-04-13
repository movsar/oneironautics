using System;
using Xunit;
using Data;
using Data.Models;
using System.Linq;
using Realms;
using System.Diagnostics;

namespace Data.Test
{
    public class DreamRepositoryTest
    {
        static DreamRepositoryTest()
        {
            Storage.Initialize(true, Constants.DbPath);
        }
        
        [Fact]
        public void DreamRepository_Add_ShouldWork()
        {
            // Add new Dream
            Dream myDream = new Dream()
            {
                Content = "I was dreaming and dreamt about something weird",
                Lucidity = 2,
                Position = SleepingPosition.Left,
                Title = "Weirdness"
            };

            Storage.DreamsRepository.Add(myDream);
            myDream = Storage.DreamsRepository.GetById<Dream>(myDream.Id);

            Assert.NotNull(myDream);
        }


        [Fact]
        public void DreamRepository_Delete_ShouldWork()
        {
            // Add new Dream
            Dream myDream = new Dream()
            {
                Content = "I was dreaming and dreamt about something weird",
                Lucidity = 2,
                Position = SleepingPosition.Left,
                Title = "Weirdness"
            };

            Storage.DreamsRepository.Add(myDream);
            myDream = Storage.DreamsRepository.GetById<Dream>(myDream.Id);
            Assert.NotNull(myDream);

            Storage.DreamsRepository.Delete(myDream);
            myDream = Storage.DreamsRepository.GetById<Dream>(myDream.Id);
            Assert.Null(myDream);
        }

     
    }
}

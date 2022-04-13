using System;
using Xunit;
using Data;
using Data.Models;
using System.Linq;

namespace Data.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Storage.Initialize(cleanStart: false);

            // Add new Dream
            Dream myDream = new Dream()
            {
                Content = "I was dreaming and dreamt about something weird",
                Lucidity = 2,
                Position = SleepingPosition.Left,
                Title = "Weirdness"
            };

            Storage.DreamsRepository.Add(myDream);
            myDream = Storage.DreamsRepository.FindByTitle("Weirdness").FirstOrDefault();

            Assert.NotNull(myDream);
        }
    }
}

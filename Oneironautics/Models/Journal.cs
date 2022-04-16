using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Models
{
    internal class Journal
    {
        internal void AddDream(IDream dream)
        {
            Storage.DreamsRepository.Add(dream);
        }

        internal IEnumerable<IDream> GetAllDreams()
        {
            return Storage.DreamsRepository.GetAll<Dream>();
        }
    }
}

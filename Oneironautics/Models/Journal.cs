using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Models
{
    public class Journal
    {
        public void UpdateDream(IDream dream)
        {
            Storage.DreamsRepository.Update(dream);
        }

        public void AddDream(IDream dream)
        {
            Storage.DreamsRepository.Add(dream);
        }

        public IEnumerable<IDream> GetAllDreams()
        {
            return Storage.DreamsRepository.GetAll<Dream>();
        }
    }
}

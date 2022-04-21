using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Models
{
    public abstract class ItemModelBase : UiElementBase, INotifyPropertyChanged
    {
        public string? Id { get; set; }
        public DateTimeOffset CreatedAt { get; set;  }
        public DateTimeOffset ModifiedAt { get; set; }

    }
}

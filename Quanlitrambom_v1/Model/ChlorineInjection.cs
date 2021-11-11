using Quanlitrambom_v1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlitrambom_v1.Model
{
    public class ChlorineInjection:Classbase
    {
        private int _chlorineInjectionID;

        private int _amountOfChlorine;
        private string _employeeName;
        public string employeeName { get => _employeeName; set { _employeeName = value; OnPropertyChanged(); } }
        private DateTime _injectionTime;

        private int _processingSystemID;

        private object _processingSystem;
        public int chlorineInjectionID { get => _chlorineInjectionID; set { _chlorineInjectionID = value; OnPropertyChanged(); } }
        public int amountOfChlorine { get => _amountOfChlorine; set { _amountOfChlorine = value; OnPropertyChanged(); } }
        public DateTime injectionTime { get => _injectionTime; set { _injectionTime = value; OnPropertyChanged(); } }
        public int processingSystemID { get => _processingSystemID; set { _processingSystemID = value; OnPropertyChanged(); } }
        public object processingSystem { get => _processingSystem; set { _processingSystem = value; OnPropertyChanged(); } }
        
    }
}

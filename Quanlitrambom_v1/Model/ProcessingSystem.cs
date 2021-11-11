using Quanlitrambom_v1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlitrambom_v1.Model
{
    public class ProcessingSystem:Classbase
    {
        private int _processingSystemID;

        private string _processingSystemName;

        private int _waterLevel;

        private int _waterPressure;

        private int _chlorineConcentration;

        private int _stationID;

        private object _station;
        private ICollection<ChlorineInjection> _chlorineInjections;
        public int processingSystemID { get => _processingSystemID; set { _processingSystemID = value; OnPropertyChanged(); } }
        public string processingSystemName { get => _processingSystemName; set { _processingSystemName = value; OnPropertyChanged(); } }
        public int waterLevel { get => _waterLevel; set { _waterLevel = value; OnPropertyChanged(); } }
        public int waterPressure { get => _waterPressure; set { _waterPressure = value; OnPropertyChanged(); } }
        public int chlorineConcentration { get => _chlorineConcentration; set { _chlorineConcentration = value; OnPropertyChanged(); } }
        public object station { get => _station; set { _station = value; OnPropertyChanged(); } }
        public int stationID { get => _stationID; set { _stationID = value; OnPropertyChanged(); } }

        public ICollection<ChlorineInjection> chlorineInjections { get => _chlorineInjections; set { _chlorineInjections = value; OnPropertyChanged(); } }
    }
}

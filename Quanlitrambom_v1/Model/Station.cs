using Quanlitrambom_v1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlitrambom_v1.Model
{
    public class Station:Classbase
    {
        private int _stationID;
        private string _stationName;
        private string _stationAddress;
        private List<object> _waterFlowControlSystems;
        private List<ProcessingSystem> _processingSystems;
        public int stationID { get => _stationID; set { _stationID = value; OnPropertyChanged(); } }
        public string stationName { get => _stationName; set { _stationName = value; OnPropertyChanged(); } }
        public string stationAddress { get => _stationAddress; set { _stationAddress = value; OnPropertyChanged(); } }
        public List<object> waterFlowControlSystems { get => _waterFlowControlSystems; set { _waterFlowControlSystems = value; OnPropertyChanged(); } }
        public List<ProcessingSystem> processingSystems { get => _processingSystems; set { _processingSystems = value; OnPropertyChanged(); } }
        
    }
}

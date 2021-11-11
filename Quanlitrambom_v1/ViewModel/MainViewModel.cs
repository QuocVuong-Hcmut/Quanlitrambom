using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Quanlitrambom_v1.Model;
using S7.Net;

namespace Quanlitrambom_v1.ViewModel
{

    public class MainViewModel : Classbase
    {
        public ICommand LoadWindowCommand { set; get; }
        public ICommand SelectStation1 { set; get; }
        public ICommand SelectStation2 { set; get; }
        public ICommand SelectStation3 { set; get; }
        public ICommand IAdd { set; get; }
        public ICommand Update { set; get; }
        public ObservableCollection<Station> Stations { get => _stations; set { _stations = value; OnPropertyChanged(); } }
        private ObservableCollection<Station> _stations;
        public ObservableCollection<ProcessingSystem> ProcessingSystems { get => _processingSystems; set { _processingSystems = value; OnPropertyChanged(); } }
        private ObservableCollection<ProcessingSystem> _processingSystems;

        public ObservableCollection<ChlorineInjection> ChlorineInjections { get => _chlorineInjections; set { _chlorineInjections = value; OnPropertyChanged(); } }
        private ObservableCollection<ChlorineInjection> _chlorineInjections;
        public ObservableCollection<ProcessingSystem> ProcessingSystemsDispplay { get => _processingSystemsDispplay; set { _processingSystemsDispplay = value; OnPropertyChanged(); } }
        private ObservableCollection<ProcessingSystem> _processingSystemsDispplay;

        public ObservableCollection<ChlorineInjection> ChlorineInjectionsDispplay { get => _chlorineInjectionsDispplay; set { _chlorineInjectionsDispplay = value; OnPropertyChanged(); } }
        private ObservableCollection<ChlorineInjection> _chlorineInjectionsDispplay;
        private string _staion;
        private string _staion1;
        public string Staion1 { get => _staion1; set { _staion1 = value; OnPropertyChanged(); } }
        private string _staion2;
        public string Staion2 { get => _staion2; set { _staion2 = value; OnPropertyChanged(); } }
        private string _staion3;
        public string Staion3 { get => _staion3; set { _staion3 = value; OnPropertyChanged(); } }

        private ChlorineInjection _selectChlorineInject;


        public ChlorineInjection SelectChlorineInject
        {
            get => _selectChlorineInject; set
            {
                _selectChlorineInject = value; OnPropertyChanged();
                if (SelectChlorineInject != null) { INJECTIONTIME = SelectChlorineInject.injectionTime; Nongdo = SelectChlorineInject.amountOfChlorine; Name = SelectChlorineInject.employeeName; }
            }
        }
        private ProcessingSystem _selectItemSystem;
        public ProcessingSystem SelectItemSystem
        {
            get => _selectItemSystem; set
            {
                _selectItemSystem = value; OnPropertyChanged();
                if (SelectItemSystem != null)
                {
                    ChlorineInjectionsDispplay = new ObservableCollection<ChlorineInjection>();
                    var data = ChlorineInjections.Where(p => SelectItemSystem.processingSystemID == p.processingSystemID);
                    foreach (ChlorineInjection item in data)
                    {
                       
                        ChlorineInjectionsDispplay.Add(item);
                    }
                    WaterLevel = SelectItemSystem.waterLevel;
                    Pressure = SelectItemSystem.waterPressure;
                    Concenstrationion = SelectItemSystem.chlorineConcentration;
                    Location = SelectItemSystem.processingSystemName;
                }
            }
        }

        private DateTime _INJECTIONTIME;
        public DateTime INJECTIONTIME { get => _INJECTIONTIME; set { _INJECTIONTIME = value; OnPropertyChanged(); } }
        private int _Concenstration;
        public int Concenstrationion { get => _Concenstration; set { _Concenstration = value; OnPropertyChanged(); PConcenstrationion = (int)(_Concenstration * 3.6); } }
        private int _WaterLevel;
        public int WaterLevel { get => _WaterLevel; set { _WaterLevel = value; OnPropertyChanged(); PWaterLevel = (int)(_WaterLevel * 36); } }
        private int _Pressure;
        public int Pressure { get => _Pressure; set { _Pressure = value; OnPropertyChanged(); PPressure = (int)(_Pressure* 3.6); } }
        private int _PConcenstration;
        public int PConcenstrationion { get => _PConcenstration; set { _PConcenstration = value; OnPropertyChanged(); } }
        private int _PWaterLevel;
        public int PWaterLevel { get => _PWaterLevel; set { _PWaterLevel = value; OnPropertyChanged(); } }
        private int _PPressure;
        public int PPressure { get => _PPressure; set { _PPressure = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Location;
        public string Location { get => _Location; set { _Location = value; OnPropertyChanged(); } }
        private int _Nongdo;
        public int Nongdo { get => _Nongdo; set { _Nongdo = value; OnPropertyChanged(); } }
        private string _auth;
        public string Auth { get => _auth; set { _auth = value; OnPropertyChanged(); } }
        DispatcherTimer timer = new DispatcherTimer();
        public string Staion
        {
            get => _staion; set
            {
                _staion = value; OnPropertyChanged();
                if (Stations!=null)
                {
                    int idStation = Stations.Where(p => p.stationName == Staion).First().stationID;
                    ProcessingSystemsDispplay = new ObservableCollection<ProcessingSystem>();
                    var data = ProcessingSystems.Where(p => p.stationID == idStation);
                    foreach (ProcessingSystem item in data)
                    {

                        ProcessingSystemsDispplay.Add(item);
                    }
                }
             
            }
        }



        public MainViewModel()
        {

            LoadWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
                {
                    
                    if (p != null)
                    {
                        
                        
                        p.Hide();
                        LoginFirst lgf = new LoginFirst();
                        lgf.ShowDialog();
                        LoginFirstViewModel lgfvm = lgf.DataContext as LoginFirstViewModel;
                        if (lgfvm.VerifyLogin)
                        {
                            lgf.Hide();
                            Auth = lgfvm.auth;
                            GetData();
                            LoaddStation();
                            StartTimer();
                            p.ShowDialog();
                            

                        }
                    }
                    else
                    {
                        return;
                    }
                });

            
            SelectStation1 = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                Staion = Staion1;
            });
            SelectStation2 = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                Staion = Staion2;
            });
            SelectStation3 = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                Staion = Staion3;
            });
            Update = new RelayCommand<Button>((p) => { return p == null ? false : true; }, (p) =>
            {


                ChlorineInjection data = ChlorineInjectionsDispplay.Where( a =>  SelectChlorineInject.chlorineInjectionID == a.chlorineInjectionID ).SingleOrDefault();
                data.injectionTime = INJECTIONTIME;
                data.employeeName = Name;
                data.amountOfChlorine = Nongdo;
                
                OnPropertyChanged("ChlorineInjectionsDispplay");
                Put(data);





            });

            IAdd = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if(p != null)
                {
                    Add();
                    ConnectPLC();
                }


            });




        }
        public void StartTimer()
        {
            timer.Interval = TimeSpan.FromMinutes(30);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GetData();
        }

        public void Put(ChlorineInjection chlorine)
        {
            HttpMethod.Ins.PutDataHttp(chlorine);
        }
        public void Add()
        {
            ChlorineInjection chlorine = new ChlorineInjection();
            chlorine.injectionTime = INJECTIONTIME;
            chlorine.processingSystemID = SelectItemSystem.processingSystemID;
            chlorine.amountOfChlorine = Nongdo;
            chlorine.employeeName = Name;
            ChlorineInjectionsDispplay.Add(chlorine);
            OnPropertyChanged("ChlorineInjectionsDispplay");
            HttpMethod.Ins.PostDataHttp(chlorine);
        }
        public void ConnectPLC()
        {

            Plc plc = new Plc(CpuType.S71200, "192.168.1.50", 0, 1);
            bool State = true;
            plc.Open();
            if (plc.IsConnected)
                {
                    MessageBox.Show("Connect");
                    if (plc.Read(DataType.Output, 0, 0, VarType.Bit, 1, 0) != null)
                    {
                        State = (bool)plc.Read(DataType.Output, 0, 0, VarType.Bit, 1, 0);

                        plc.WriteBit(DataType.Memory, 0, 0, 0, !State);
                    }
                }
            else
                {
                    MessageBox.Show("NoConnect");
                }
            }
        public void GetData()
        {
            Stations = new ObservableCollection<Station>();
            Stations = HttpMethod.Ins.HttpGetStation(Auth);
            ProcessingSystems = new ObservableCollection<ProcessingSystem>();
            ProcessingSystems = HttpMethod.Ins.HttpGetProcessingSystemn(Auth);
            ChlorineInjections = new ObservableCollection<ChlorineInjection>();
            ChlorineInjections = HttpMethod.Ins.HttpGetChlorineInjection(Auth);
            //Task T1 = new Task(() =>
            //{
            //    Stations = new ObservableCollection<Station>();
            //    Stations = HttpMethod.Ins.HttpGetStation();
            //});
            //Task T2 = new Task(() =>
            //{
            //    ProcessingSystems = new ObservableCollection<ProcessingSystem>();
            //    ProcessingSystems = HttpMethod.Ins.HttpGetProcessingSystemn();
            //});

            //    ChlorineInjections = new ObservableCollection<ChlorineInjection>();
            //    ChlorineInjections = HttpMethod.Ins.HttpGetChlorineInjection();

            //T1.Start();
            //T2.Start();
            //T1.Wait();
            //T2.Wait();

        }
        public void LoaddStation()
        {

            if (Stations != null)
            {
                Staion1 = Stations[0].stationName;
                Staion2 = Stations[1].stationName;
                Staion3 = Stations[2].stationName;
            }


        }

    }
}
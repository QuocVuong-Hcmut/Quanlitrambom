using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quanlitrambom_v1.Model;
using xNet;

namespace Quanlitrambom_v1.Model
{
    public class HttpMethod
    {
        private static HttpMethod _ins;
        public static HttpMethod Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new HttpMethod();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }
        HttpRequest HttpRequest;
        public HttpMethod()
        {
            HttpRequest = new HttpRequest();

        }
        
        public ObservableCollection<ChlorineInjection> HttpGetChlorineInjection(string auth)
        {
            string Url = "https://sampleapiproject.azurewebsites.net/chlorineinjections/list";
            ObservableCollection<ChlorineInjection> ChlorineInjections = new ObservableCollection<ChlorineInjection>();
            HttpRequest.Authorization = auth;
            try
            {
                ChlorineInjections = JsonConvert.DeserializeObject<ObservableCollection<ChlorineInjection>>(HttpRequest.Get(Url).ToString());
            }
            catch { }
            
            

            return ChlorineInjections;
        }
        public ObservableCollection<ProcessingSystem> HttpGetProcessingSystemn(string auth)
        {
            HttpRequest.Authorization = auth;
            ObservableCollection<ProcessingSystem> ProcessingSystems = new ObservableCollection<ProcessingSystem>();
            try {
                string Url = "https://sampleapiproject.azurewebsites.net/processingsystems/list";

                ProcessingSystems = JsonConvert.DeserializeObject<ObservableCollection<ProcessingSystem>>(HttpRequest.Get(Url).ToString());
            }
            catch { }
            

            return ProcessingSystems;
        }
        public ObservableCollection<Station> HttpGetStation(string auth)
        {
            ObservableCollection<Station> Stations = new ObservableCollection<Station>();
            
            try
            {
                HttpRequest.Authorization = auth;
                string Url = "https://sampleapiproject.azurewebsites.net/Stations/list";
                Stations = JsonConvert.DeserializeObject<ObservableCollection<Station>>(HttpRequest.Get(Url).ToString());
            }
            catch
            {

            }
           

            return Stations;
        }
        public void PostDataHttp(ChlorineInjection chlorine)
        {
            //string data = "{\"ChlorineVolume\": 90, \"EmployeeName\": \"Nguyen Van Xuan\", \"InjectionTime\": \"2021-10-27T09:08:00\", \"ProcessingSystemID\": 35 }";
            try {
                string url = "https://sampleapiproject.azurewebsites.net/chlorineinjections";
                string data = JsonConvert.SerializeObject(chlorine);
                HttpRequest.Post(url, data, "application/json");

            } catch { }

            
            

        }
        public void PutDataHttp(ChlorineInjection chlorine)
        {

            string url = "https://sampleapiproject.azurewebsites.net/chlorineinjections";
            string data = JsonConvert.SerializeObject(chlorine);
            
        }
        public bool PostCreateUser( User user )
        {
            bool sucessful = false;
            try
            {
                string url = "https://sampleapiproject.azurewebsites.net/api/users";
                string data = JsonConvert.SerializeObject(user);
                string status = HttpRequest.Post(url, data, "application/json").StatusCode.ToString();
                if (status == "OK")
                {
                    sucessful = true;
                }
            }
            catch
            {
                sucessful = false;
            }
           
            return sucessful;


    }
        public string PostLogin(InforLogin Infor)
        {
            string url = "https://sampleapiproject.azurewebsites.net/api/auth";
            string auth = "null";
            string data = JsonConvert.SerializeObject(Infor);
            try
            {
                string auth_pre = HttpRequest.Post(url, data, "application/json").ToString();
                List<string> auths = auth_pre.Split('\"').ToList<string>();
                for( int i =0; i< auths.Count(); i++)
                {
                    if(auths[i] == "authToken")
                    {
                        auth = auths[i + 2];
                        auth = auth.Replace('\"', ' ');
                        break;
                    }
                }
                
                
                
            }
            catch
            {
                auth = "null";
            }

            return auth;

        }




    }
    
}

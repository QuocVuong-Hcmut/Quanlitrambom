using Quanlitrambom_v1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quanlitrambom_v1.ViewModel
{
    public class LoginFirstViewModel:Classbase
    {
        public ICommand ILoginCommand { set; get; }
        public ICommand ISignInCommand { set; get; }
        public ICommand IPasswordChangedCommand { set; get; }
        public ICommand ICreatePasswordChangedCommand { set; get; }
        
        public ICommand ICreateUser { set; get; }
        private DateTime _timeBirthDay;
        public DateTime TimeBirthDay { get => _timeBirthDay; set { _timeBirthDay = value; OnPropertyChanged(); } }
        public int Height { get => _Height; set { _Height = value; OnPropertyChanged(); } }

        private int _Height;
        public string LastName { get => _LastName; set { _LastName = value; OnPropertyChanged(); } }

        private string _LastName;
        public string FisrtName { get => _fisrtName; set { _fisrtName = value; OnPropertyChanged(); } }

        private string _fisrtName;
        public string User { get => _user; set { _user = value; OnPropertyChanged(); } }

        private string _user;
        private string _pass;
        public string Pass
        {
            get => _pass; set { _pass = value; OnPropertyChanged(); }
        }
        public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }

        private string _username;
        public string PassWord
        {
            get => _passWord; set { _passWord = value; OnPropertyChanged(); }
        }

        private string _passWord;
        public string auth { set; get; }
        public bool VerifyLogin = false;
        public LoginFirstViewModel()
        {
            Height = 450;
            IPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return p == null ? false : true; }, (p) =>
                {
                    if (p != null)
                    {
                        PassWord = p.Password;
                    }
                
                });
            ICreatePasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    Pass = p.Password;
                }
                
            });
            ILoginCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                
                InforLogin Infor = new InforLogin();
                Infor.userName = Username;
                Infor.password = PassWord;
                auth = HttpMethod.Ins.PostLogin(Infor);
                if (auth != "null" )
            {
                    VerifyLogin = true;
                    p.Close();
                    auth = "Bearer       " + auth;
                }
                else { VerifyLogin = false; }
            });
            ICreateUser = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                ThreadStart threadStart = new ThreadStart(Tranfer);
                Thread thread = new Thread(threadStart);
                thread.Start();
            });
            ISignInCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                User newAcc = new User();
                bool sucessful = false;
                newAcc.dateOfBirth = TimeBirthDay;
                newAcc.fisrtName = FisrtName;
                newAcc.lastName = LastName;
                newAcc.password = Pass;
                newAcc.userName = User;
                sucessful=HttpMethod.Ins.PostCreateUser(newAcc);
                if (sucessful)
                {
                    MessageBox.Show("Sucessful");
                }

            });

        }
        public void Tranfer()
        {
            for (int i = 450; i > 0;)
            {
                Thread.Sleep(100);
                Height = i;
                i -= 5;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quanlitrambom_v1.ViewModel
{
    public class LoginSencodViewModel:Classbase
    {
        public ICommand PasswordChangedCommand { set; get; }
        public ICommand ButtonCommand { set; get; }
        public ICommand ButtonExitCommand { set; get; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        public string PassWord { get => _PassWord; set { _PassWord = value; OnPropertyChanged(); } }

        private string _PassWord;

        public bool VerifyLoginSecond = false;
        
        public LoginSencodViewModel()
        {
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return p == null ? false : true; }, (p) => {

                PassWord = p.Password;
            });
            ButtonExitCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
          {
              
              if (p != null)
              {
                  p.Close();
              }
          }
            );

           ButtonCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window w = p as Window;
                if (w != null)
                {
                    if (_UserName == "Vuong" && _PassWord == "123456")
                    {
                        VerifyLoginSecond = true;
                        w.Close();
                    }
                    else
                    {
                        MessageBox.Show("PassWord Error");
                    }

                }
               
            }

            );
          



        }

    }
}

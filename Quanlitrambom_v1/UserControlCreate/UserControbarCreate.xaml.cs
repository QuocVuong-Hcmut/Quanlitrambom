using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Quanlitrambom_v1.ViewModel;

namespace Quanlitrambom_v1.UserControlCreate
{
    /// <summary>
    /// Interaction logic for UserControbarCreate.xaml
    /// </summary>
    public partial class UserControbarCreate : UserControl
    {
        public UserControlBarCreateViewModel viewModel = new UserControlBarCreateViewModel();


        public UserControbarCreate()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}

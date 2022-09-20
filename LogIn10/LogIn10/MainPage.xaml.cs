using LogIn10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LogIn10
{
    public partial class MainPage : ContentPage
    {
        private List<UserModel> userList = new List<UserModel>();

        public MainPage()
        {
            InitializeComponent();
        }     
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LogIn10.Models
{
    public class UserModel : BindableObject
    {
        private string _userName;

        public string UserID { get; set; }
        public string UserName 
        {
            get => this._userName; 
            set
            {
                if(_userName != value)
                {
                    this._userName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email { get; set; }
        public string Tel { get; set; }
        public DateTime? RegistDate { get; set; }
    }
}

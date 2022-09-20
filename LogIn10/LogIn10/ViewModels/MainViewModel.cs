using LogIn10.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace LogIn10.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableRangeCollection<UserModel> _userModels = new ObservableRangeCollection<UserModel>();
        private UserModel _selectedItem;
        private string _userID;
        private string _userName;
        private string _email;
        private string _tel;
        private DateTime? _registDate;

        public ICommand RegistCommand { get; private set; }
        public ICommand ModifyCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand SelectionChangedCommand { get; private set; }

        public MainViewModel()
        {
            RegistDate = DateTime.Now;

            RegistCommand = new Command(() => Regist());
            ModifyCommand = new Command(() => Modify());
            DeleteCommand = new Command(() => Delete());
            SelectionChangedCommand = new Command(() => SelectionChanged());
        }

        private void SelectionChanged()
        {
            this.UserID = this.SelectedItem.UserID;
            this.UserName = this.SelectedItem.UserName;
            this.Email = this.SelectedItem.Email;
            this.Tel = this.SelectedItem.Tel;
            this.RegistDate = this.SelectedItem.RegistDate;
        }

        private void Regist()
        {
            UserModel newUser = new UserModel()
            {
                UserID = this.UserID,
                UserName = this.UserName,
                Email = this.Email,
                Tel = this.Tel,
                RegistDate = this.RegistDate
            };

            this.UserModels.Add(newUser);

            ClearDataForm();
        }

        private void Modify()
        {            
            var item = UserModels.Where(i => i.UserID == this.SelectedItem.UserID).FirstOrDefault();

            item.UserName = this.UserName;
            item.Email = this.Email;
            item.Tel = this.Tel;
            item.RegistDate = this.RegistDate;
        }

        private void Delete()
        {
            this.UserModels.Remove(this.SelectedItem);
            ClearDataForm();
        }

        private void ClearDataForm()
        {
            this.UserID = string.Empty;
            this.UserName = string.Empty;
            this.Email = string.Empty;
            this.Tel = string.Empty;
            this.RegistDate = DateTime.Now;
        }

        public UserModel SelectedItem
        {
            get => this._selectedItem;
            set => SetProperty(ref this._selectedItem, value);
        }

        public string UserID
        {
            get => this._userID;
            set => SetProperty(ref this._userID, value);
        }

        public string UserName
        {
            get => this._userName;
            set => SetProperty(ref this._userName, value);
        }

        public string Email
        {
            get => this._email;
            set => SetProperty(ref this._email, value);
        }
        public string Tel
        {
            get => this._tel;
            set => SetProperty(ref this._tel, value);
        }

        public DateTime? RegistDate
        {
            get => this._registDate;
            set => SetProperty(ref this._registDate, value);
        }


        public ObservableRangeCollection<UserModel> UserModels
        {
            get => this._userModels;
            set => SetProperty(ref this._userModels, value);
        }        
    }
}

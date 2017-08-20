using FokWPF.Commands;
using FokWPF.Common;
using FokWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FokWPF.ViewModels
{
    class NewsViewModel : INotifyPropertyChanged
    {
        private NewsModel _newsModel;
        public event PropertyChangedEventHandler PropertyChanged;

        public NewsViewModel()
        {
            _newsModel = new NewsModel();
        }

        public RelayCommand ReiceveNewsCommand
        {
            get { return new RelayCommand(o => ReceiveData(), o => !string.IsNullOrWhiteSpace(URL)); }
        }

        public NewsModel News
        {
            get => _newsModel;
        }

        public string URL
        {
            get { return News.URL; }
            set { News.URL = value; OnPropertyChanged(nameof(URL)); }
        }

        public string Content
        {
            get { return News.Content; }
            set { News.Content = value; OnPropertyChanged(nameof(Content)); }
        }

        public void ReceiveData()
        {
            Debug.WriteLine(URL);
            var request = WebRequest.Create(URL);
            var response = request.GetResponse();

            using (var data = response.GetResponseStream())
            {
                using (var reader = new StreamReader(data))
                {
                    string content = reader.ReadToEnd();

                    Content = "Request-Status: " + (response as HttpWebResponse).StatusDescription + "\n\n" + content;

                    reader.Close();
                }

                response.Close();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

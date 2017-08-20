using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FokWPF.Models
{
    class NewsModel
    {
        private string _url;
        private string _content;

        public string URL
        {
            get => _url;
            set => _url = value;
        }

        public string Content
        {
            get => _content;
            set => _content = value;
        }
    }
}

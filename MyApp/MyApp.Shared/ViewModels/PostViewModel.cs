using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Shared.ViewModels
{
    public partial class PostViewModel : ViewModel
    {
        private long userId;

        [JsonProperty("userId")]
        public long UserId
        {
            get => userId;
            set
            {
                if (value != userId)
                {
                    userId = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private long id;

        [JsonProperty("id")]
        public long Long
        {
            get => id;
            set
            {
                if (value != id)
                {
                    id = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private string title;

        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string body;

        [JsonProperty("body")]
        public string Body
        {
            get { return body; }
            set
            {
                if (body != value)
                {
                    body = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}

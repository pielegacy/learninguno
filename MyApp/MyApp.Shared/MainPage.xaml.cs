using MyApp.Shared;
using MyApp.Shared.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyApp
{

    /// <summary>
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly string dataEndpoint = "https://jsonplaceholder.typicode.com/posts/";

        public ObservableCollection<PostListViewModel> Posts { get; set; }
        public PostViewModel SelectedPost { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Posts = new ObservableCollection<PostListViewModel>();
            SelectedPost = new PostViewModel();
            Loaded += LoadData;
        }

        private async void LoadData(object sender, RoutedEventArgs e)
        {
            if (Posts.Count == 0)
            {
                var client = new HttpClient();
                using (client)
                {
                    var response = await client.GetAsync(dataEndpoint);
                    foreach (var post in (await response.Content.ReadAsObjectAsync<ICollection<PostViewModel>>()))
                        Posts.Add(new PostListViewModel(post));
                }
            }
        }

        private void PostSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (ListPosts.SelectedItem as PostListViewModel);
            if (selectedItem == null)
            {
                return;
            }
            SelectedPost.Title = selectedItem.Title;
            SelectedPost.Body = selectedItem.Body;
            // Navigate if mobile
            if (ColumnDetails.Width.Value == 0)
                Frame.Navigate(typeof(ViewPost), selectedItem);
        }
    }

    public class PostListViewModel : PostViewModel
    {
        public PostListViewModel() { }

        public PostListViewModel(PostViewModel post)
        {
            UserId = post.UserId;
            Title = post.Title;
            Body = post.Body;
            Long = post.Long;
        }
        public string Summary => Body.Split('\n')[0] + "...";
    }
}

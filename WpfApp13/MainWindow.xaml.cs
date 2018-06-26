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
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WpfApp13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string usernamevalue = username.Text;
            WebClient Client = new WebClient();
            Client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            string githuburl = string.Format("https://api.github.com/users/{0}/repos", usernamevalue);
            string downloadString = Client.DownloadString(githuburl);
            var result = JsonConvert.DeserializeObject<List<JSonModel.RootObject>>(downloadString);
            foreach (var repo in result) 
            { repositoriesLV.Items.Add(repo.name);};


            WebClient Client1 = new WebClient();
            string userModel = username.Text;
            string repoModel = repositoriesLV.SelectedItem.ToString();
            string url = string.Format("https://api.github.com/repos/{0}/{1}", userModel, repoModel);
            string downloadstring = Client1.DownloadString(url);
            var res1 = JsonConvert.DeserializeObject<JsonM.RootObject1>(downloadString);
           

        }

        private void repositoriesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Info.Content = res1.;
        }
    }
}

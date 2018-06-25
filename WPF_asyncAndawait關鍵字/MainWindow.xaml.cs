using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WPF_asyncAndawait關鍵字
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //C# 4.0 寫法  舊方法
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //AccessUrlForNet4Async();

            AccessUrlForNet5Async();
        }

        //改用 C# 5.0  async 與 await
        public async void AccessUrlForNet5Async()
        {
            var client = new WebClient();

            GetUrlLength(await client.DownloadStringTaskAsync(new Uri("http://msdn.microsoft.com/zh-tw")));
            GetUrlLength(await client.DownloadStringTaskAsync(new Uri("http://www.microsoft.com/zh-tw")));
            GetUrlLength(await client.DownloadStringTaskAsync(new Uri("http://channel9.msdn.com/")));
            GetUrlLength(await client.DownloadStringTaskAsync(new Uri("http://technet.microsoft.com/zh-TW/")));
        }

        private void AccessUrlForNet4Async()
        {
            var client = new WebClient();
            client.DownloadStringCompleted += AccessUrlForNet4AsyncDownloadStringCompleted;
            client.DownloadStringAsync(new Uri("http://msdn.microsoft.com/zh-tw"));
        }

        private void AccessUrlForNet4AsyncDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            GetUrlLength(e.Result);

            var client = new WebClient();

            client.DownloadStringCompleted += AccessUrlForNet4AsyncDownloadStringCompleted2;
            client.DownloadStringAsync(new Uri("http://www.microsoft.com/zh-tw"));
        }

        private void AccessUrlForNet4AsyncDownloadStringCompleted2(object sender, DownloadStringCompletedEventArgs e)
        {
            GetUrlLength(e.Result);

            var client = new WebClient();
            client.DownloadStringCompleted += AccessUrlForNet4AsyncDownloadStringCompleted3;
            client.DownloadStringAsync(new Uri("http://channel9.msdn.com/"));
        }

        private void AccessUrlForNet4AsyncDownloadStringCompleted3(object sender, DownloadStringCompletedEventArgs e)
        {
            GetUrlLength(e.Result);

            var client = new WebClient();
            client.DownloadStringCompleted += AccessUrlForNet4AsyncDownloadStringCompleted4;
            client.DownloadStringAsync(new Uri("http://technet.microsoft.com/zh-TW/"));
        }

        private void AccessUrlForNet4AsyncDownloadStringCompleted4(object sender, DownloadStringCompletedEventArgs e)
        {
            GetUrlLength(e.Result);

        }

        private void GetUrlLength(string result)
        {
            results.Text += "下載 Url 字串長度：" + result.Length + "。\r\n";
        }
      
    }
}

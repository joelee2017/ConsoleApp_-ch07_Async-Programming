using System;
using System.Collections.Generic;
using System.IO;
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
            //AccessUrlForNet5Async();

            AccessUrls();
        }

        //使用同步方法來撰寫，在等侯被要求的資源下載時，介面執行緒(主執行緒) 的被封鎖。
        //因此點擊「開始」後，介面無法移動，最大化，最小，甚至無法關閉。
        private void AccessUrls()
        {
            // 注意，此行程式未進行安全性處理
            string[] urls = InputUrl.Text.Split(',');

            foreach(var url in urls)
            {
                byte[] content = GetUrl(url);
                results.Text +=
                    string.Format("下載 URL" + url + "字串長度： {0}.\r\n\r\n", content.Length);
            }
        }

        private byte[] GetUrl(string url)
        {
            // 下載的資源將放置於 MemoryStream 的變數內
            var content = new MemoryStream();

            // 初始化 HttpWebRequest
            var webRequest = (HttpWebRequest)WebRequest.Create(url);

            //進行其他的工作
            DoOtherWork(url);

            //送出要求，等待網路資源回應
            using (WebResponse response = webRequest.GetResponse())
            {
                //取得回應的 stream
                using (Stream responseStream = response.GetResponseStream())
                {
                    // 將回應的資料流複製到 content
                    responseStream.CopyTo(content);
                }
            }

            // 回應 byte array
            return content.ToArray();
        }

        private void DoOtherWork(string url)
        {
            results.Text += "下載 " + url + " 中...................\r\n";
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

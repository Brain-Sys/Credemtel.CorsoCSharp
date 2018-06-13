using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace Credemtel.CorsoCSharp.WindowsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource sourceToken = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
            sourceToken.Token.Register(() => { MessageBox.Show("Operazione annullata!!!"); });
        }

        private async void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            // int numero = await countTagAsync("http://www.ilcittadino.it", "img");

            int n = await generaPdf(2000);
            MessageBox.Show($"Operazione completata! PDF generati : {n}");
        }

        private async Task<int> countTagAsync(string url, string tagName)
        {
#if DEBUG
            await Task.Delay(10000);
#endif

            HttpClient client = new HttpClient();
            string html = await client.GetStringAsync(url);

            return new Random().Next(0, 900);
        }

        private async Task<int> generaPdf(int n)
        {
            int count = 0;

            await Task.Run(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    ++count;
                    if (sourceToken.IsCancellationRequested) break;

                    File.WriteAllText($@"E:\Database\{i}.pdf", DateTime.Now.ToString());
                }
            }, sourceToken.Token);

            return count;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            sourceToken.Cancel();
        }

        private async void btnWcf_Click(object sender, RoutedEventArgs e)
        {
            Service.Service1Client client = new Service.Service1Client();
            string value = await client.GetDataAsync(23);
            MessageBox.Show(value.ToString());
        }
    }
}

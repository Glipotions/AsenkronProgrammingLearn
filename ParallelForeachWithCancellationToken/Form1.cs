namespace ParallelForeachWithCancellationToken
{
    public partial class Form1 : Form
    {

        private CancellationTokenSource ct ;
        private int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
            ct = new CancellationTokenSource();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            ct = new CancellationTokenSource();
            List<string> urlLists = new()
            {
                "https://www.Google.com",
                "https://www.Microsoft.com",
                "https://www.amazon.com",
                "https://www.instagram.com",
                "https://www.twitter.com",
                "https://www.Google.com",
                "https://www.Microsoft.com",
                "https://www.amazon.com",
                "https://www.instagram.com",
                "https://www.twitter.com",
                "https://www.Google.com",
                "https://www.Microsoft.com",
                "https://www.amazon.com",
                "https://www.instagram.com",
                "https://www.twitter.com",
                "https://www.Google.com",
                "https://www.Microsoft.com",
                "https://www.amazon.com",
                "https://www.instagram.com",
                "https://www.twitter.com",
            };
            HttpClient httpClient = new HttpClient();

            ParallelOptions parallelOptions = new();
            parallelOptions.CancellationToken = ct.Token;

            Task.Run(() =>
            {
                Parallel.ForEach<string>(urlLists, parallelOptions, (url) =>
                {
                    try
                    {
                        var content = httpClient.GetStringAsync(url).Result;

                        string data = $"{url}:{content.Length}";

                        ct.Token.ThrowIfCancellationRequested();

                        listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(data); });

                    }
                    catch (OperationCanceledException ex)
                    {

                        MessageBox.Show("Ýþlem iptal edildi: " + ex.Message);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Genel bir hata meydana geldi: " + ex.Message);
                    }

                });
            });
        }

        private void btnArttir_Click(object sender, EventArgs e)
        {
            btnArttir.Text = counter++.ToString();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }
    }
}
namespace TaskThreadApp
{
    public partial class Form1 : Form
    {
        private static int Counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSayac_Click(object sender, EventArgs e)
        {
            Counter += 1;
            btnSayac.Text = Counter.ToString();
        }

        private async void btnBaslat_Click(object sender, EventArgs e)
        {
            var atask = Go(progressBar1);
            var btask = Go(progressBar2);

            await Task.WhenAll(atask, btask);
        }


        private async Task Go(ProgressBar progressBar)
        {

            await Task.Run(() =>
              {
                  Enumerable.Range(1, 100).ToList().ForEach(x =>
                  {
                      Thread.Sleep(100);

                      progressBar.Invoke((MethodInvoker)delegate { progressBar.Value = x; });
                  });
              });

        }
    }
}
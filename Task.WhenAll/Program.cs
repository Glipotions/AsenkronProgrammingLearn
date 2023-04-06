namespace TaskWhenall.Example
{
    public class Program
    {
        async static Task Main(string[] args)
        {
            List<string> urlLists = new()
            {
                "https://www.Google.com",
                "https://www.Microsoft.com",
                "https://www.amazon.com",
                "https://www.instagram.com",
                "https://www.twitter.com"
            };

            List<Task<Content>> taskList = new();

            urlLists.ToList().ForEach(x =>
            {
                taskList.Add(GetContentAsync(x));
            });
            #region Task.WhenAll metod kullanımı
            /// Hepsini aynı anda çalıştırmayı sağlar ve task listesindeki görevler bitene kadar devam eder.

            //var contents = Task.WhenAll(taskList.ToArray());
            //Console.WriteLine("WhenAll metodundan sonra başka işler falan işte");
            //var data = await contents;
            ////var contents = await Task.WhenAll(taskList.ToArray());
            ////var data = contents;

            //data.ToList().ForEach(x =>
            //{
            //    Console.WriteLine($"{x.UrlName} - Boyut: {x.Length}");
            //});

            #endregion,

            #region Task.WhenAny
            /// Task.WhenAny ile ilk yaptığı görevi getirir.
            /// 

            //var FirstData = await Task.WhenAny(taskList);
            //await Console.Out.WriteLineAsync($"{FirstData.Result.Site} - {FirstData.Result.Length}");

            #endregion

            #region Task.WaitAll
            /// thredi tüm datalar dönene kadar bloklamaktadır.
            /// 

            //Console.WriteLine("waitAll metodundan önce");
            //bool result= Task.WaitAll(taskList.ToArray(), 300);
            //Console.WriteLine("3 saniyede geldi mi: "+ result);
            //Console.WriteLine("waitAll metodundan sonra");

            //await Console.Out.WriteLineAsync($"{taskList.First().Result.Site} - {taskList.First().Result.Length}");

            #endregion

            #region Task.WaitAny
            /// Task.WaitAny ile ilk yaptığı görevi getirir. ilk görevi getirene kadar thredi bloklar

            var FirstData =  Task.WaitAny(taskList.ToArray());
            await Console.Out.WriteLineAsync($"{taskList[FirstData].Result.Site} - {taskList[FirstData].Result.Length}");

            #endregion
        }





        public static async Task<Content> GetContentAsync(string url)
        {
            Content content = new();

            var data = await new HttpClient().GetStringAsync(url);

            content.Site = url;
            content.Length = data.Length;

            await Console.Out.WriteLineAsync("GetContentAsync thread Id: " + Thread.CurrentThread.ManagedThreadId);
            await Console.Out.WriteLineAsync("GetContentAsync thread name: " + Thread.CurrentThread.Name);
            await Console.Out.WriteLineAsync("GetContentAsync thread CurrentUICulture: " + Thread.CurrentThread.CurrentUICulture);
            await Console.Out.WriteLineAsync("GetContentAsync thread CurrentCulture: " + Thread.CurrentThread.CurrentCulture);
            await Console.Out.WriteLineAsync("GetContentAsync thread ExecutionContext: " + Thread.CurrentThread.ExecutionContext);
            await Console.Out.WriteLineAsync("GetContentAsync thread ApartmentState: " + Thread.CurrentThread.ApartmentState);
            await Console.Out.WriteLineAsync("GetContentAsync thread IsBackground: " + Thread.CurrentThread.IsBackground);
            await Console.Out.WriteLineAsync("GetContentAsync thread IsAlive: " + Thread.CurrentThread.IsAlive);
            await Console.Out.WriteLineAsync("GetContentAsync thread IsThreadPoolThread: " + Thread.CurrentThread.IsThreadPoolThread);
            await Console.Out.WriteLineAsync("GetContentAsync thread Priority: " + Thread.CurrentThread.Priority);
            await Console.Out.WriteLineAsync("GetContentAsync thread ThreadState: " + Thread.CurrentThread.ThreadState);

            return content;
        }
    }

    public class Content
    {
        public string Site { get; set; }
        public int Length { get; set; }
    }
}

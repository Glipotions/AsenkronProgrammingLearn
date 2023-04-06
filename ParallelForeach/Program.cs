// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Drawing;
Stopwatch sw = new();

#region MultiThread
sw.Start();
string picturePath = "";

var files = Directory.GetFiles(picturePath);

Parallel.ForEach(files, (item) =>
{
    Console.WriteLine("thread no: " + Thread.CurrentThread.ManagedThreadId);

    Image img = new Bitmap(item);

    var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

    thumbnail.Save(Path.Combine(picturePath, "thumbnail", Path.GetFileName(item)));
});

sw.Stop();
Console.WriteLine("İşlem bitti: " + sw.ElapsedMilliseconds);
#endregion

sw.Reset();

#region SingleThread

sw.Start();

files.ToList().ForEach(x =>
{
    Console.WriteLine("thread no: " + Thread.CurrentThread.ManagedThreadId);

    Image img = new Bitmap(x);

    var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

    thumbnail.Save(Path.Combine(picturePath, "thumbnail", Path.GetFileName(x)));
});

sw.Stop();
Console.WriteLine("İşlem bitti: " + sw.ElapsedMilliseconds);


#endregion



#region ThreadSafe- SharedData

int total = 0;

Parallel.ForEach(Enumerable.Range(1, 100).ToList(), () => 0, (x, loop, subtotal) =>
{
    subtotal += x;
    return subtotal;
}, (y) => Interlocked.Add(ref total, y));

#endregion
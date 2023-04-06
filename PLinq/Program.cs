// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var array = Enumerable.Range(1, 100).ToList();

var newPlinQArray = array.AsParallel().Where(x => x % 2 == 0);


//newPlinQArray.ToList().ForEach(x =>
//{
//    Console.WriteLine(x);
//});

/// ForAll paralel for yapmayı sağlar
newPlinQArray.ForAll(x =>
{
    Console.WriteLine(x);
});
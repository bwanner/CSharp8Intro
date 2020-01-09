using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace CSharp8Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            NullableTypes();

            //UsingStatement();

            //RangeAndIndex();

            //AsyncEnumerable().Wait();

            Console.ReadKey();
        }

        private static async Task AsyncEnumerable()
        {
            // System.Linq.Async is a 3rd party package.
            await foreach(var data in ProduceData().Where(i => i % 2 == 0).Select(x => $"Received input {x}"))
            {
                Console.WriteLine(data);
            }
        }

        private static async IAsyncEnumerable<int> ProduceData()
        {
            for (int i = 1; i <= 20; i++)
            {
                await Task.Delay(1000);//Simulate waiting for data to come through. 
                yield return i;
            }
        }

        private static void RangeAndIndex()
        {
            // Range
            var myArray = Enumerable.Range(0, 5).Select(i => $"string number {i}").ToArray();
            var mySlice = myArray[1..^1];
            Console.WriteLine(string.Join(", ", mySlice));

            mySlice[1] = "Changed in the ranged array"; // Copy or not copy? :)
            Console.WriteLine(string.Join(", ", mySlice));
            Console.WriteLine(string.Join(", ", myArray));

            var mySegment = new ArraySegment<string>(myArray, 1, myArray.Length - 1);
            mySegment[1] = "Changed in the segment";
            Console.WriteLine(string.Join(", ", mySegment));
            Console.WriteLine(string.Join(", ", myArray));
        }

        private static void UsingStatement()
        {
            using var disposeMe = new MyDisposableResource();
            Console.WriteLine("At end of method");
        }

        private static void NullableTypes()
        {
            var article = new NewsArticle()
            {
                //Content = null,
                TitlePicture = new Uri("http://bing.com/image.jpg")
            };

            Console.WriteLine(article.Content);

            // Not null - in this case :)
            //Console.WriteLine(article.TitlePicture.ToString());

            // Null - in this case :) - gives compiler warning
            //article.TitlePicture = null;
            //Console.WriteLine(article.TitlePicture.ToString());

            // Null but no compiler warning
            //article.TitlePicture = new Uri("http://bing.com/image.jpg");
            //typeof(NewsArticle).GetProperty(nameof(NewsArticle.TitlePicture))!.GetSetMethod()!.Invoke(article, new object?[] { null });
            //Console.WriteLine(article.TitlePicture.ToString());

            // Highlighting intent throws
            //var property = typeof(NewsArticle).GetProperty("abc")!.GetGetMethod();

            // MyList may be null, each element is not allowed to be null
            //List<string>? myList = new List<string>();
            //myList.Add(null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

#nullable enable
namespace CSharp8Intro
{
    public class NewsArticle
    {
        //public NewsArticle()
        //{
        //    Content = "Abc";
        //}

        //public NewsArticle(string foo) { }

        public string Content { get; set; } = default!;

        public Uri? TitlePicture { get; set; }
    }
}
#nullable disable

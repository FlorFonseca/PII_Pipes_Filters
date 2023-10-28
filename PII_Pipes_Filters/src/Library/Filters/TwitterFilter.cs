using System;
using System.Drawing;
using CompAndDel;
using Ucu.Poo.Twitter;

namespace CompAndDel.Filters
{
    public class TwitterFilter: IFilter
    {
        public IPicture Filter (IPicture picture)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Mira la imagen editada", @"LukeEditado.jpg"));
            return picture;
        }
    }
}
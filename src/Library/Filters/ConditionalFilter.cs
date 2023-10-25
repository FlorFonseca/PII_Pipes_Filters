using System;
using System.Drawing;
using CompAndDel;
using CompAndDel.Pipes;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    public class ConditionalFilter 
    {
        public bool face { get; set; }

        public bool Filter(IPicture picture)
        {
            this.face = false;
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(picture, @"temporal.jpg");
            CognitiveFace cognitiveFace = new CognitiveFace(true, Color.YellowGreen);
            cognitiveFace.Recognize(@"temporal.jpg");
            this.face = cognitiveFace.FaceFound;
            return this.face;
        }
    }
}
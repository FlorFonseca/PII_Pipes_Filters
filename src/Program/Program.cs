using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;
using System.Diagnostics.Contracts;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        // EJERCICIO 1
        // {
        //     PictureProvider provider = new PictureProvider();
        //     IPicture image = provider.GetPicture(@"luke.jpg");

        //     IPipe pipenull = new PipeNull ();
        //     image = pipenull.Send(image);
        //     IFilter blur = new FilterNegative();
            
        //     IPipe pipeserial1 = new PipeSerial(blur, pipenull);
        //     image = pipeserial1.Send(image);
        //     IFilter negative = new FilterGreyscale();

        //     IPipe pipeserial2 = new PipeSerial(negative, pipeserial1);
        //     image = pipeserial1.Send(image);

        //     provider.SavePicture(image, @"luke.jpg");
        // }

        // EJERCICIO 2
        // {
        //     PictureProvider provider = new PictureProvider();
        //     IPicture image = provider.GetPicture(@"luke.jpg");

        //     IPipe pipenull = new PipeNull ();
        //     image = pipenull.Send(image);
        //     IFilter blur = new FilterBlurConvolution();
            
        //     IPipe pipeserial1 = new PipeSerial(blur, pipenull);
        //     image = pipeserial1.Send(image);
        //     IFilter negative = new FilterNegative();

        //     IPipe pipeserial2 = new PipeSerial(negative, pipeserial1);
        //     image = pipeserial1.Send(image);

        //     PictureProvider p = new PictureProvider();
        //     p.SavePicture(image, "LukeEditado.jpg");



        // }
        {
            PictureProvider provider = new PictureProvider();
            IPicture image = provider.GetPicture(@"luke.jpg");

            IPipe pipenull = new PipeNull ();
            image = pipenull.Send(image);
            IFilter blur = new FilterBlurConvolution();
            
            IPipe pipeserial1 = new PipeSerial(blur, pipenull);
            image = pipeserial1.Send(image);
            IFilter negative = new FilterNegative();

            IPipe pipeserial2 = new PipeSerial(negative, pipeserial1);
            image = pipeserial2.Send(image);

            provider.SavePicture(image, "LukeEditado.jpg");

            IPicture Post = provider.GetPicture(@"LukeEditado.jpg");
            TwitterImage twitter = new TwitterImage();
            //twitter.PublishToTwitter("Mira esta imágen!",@"LukeEditado.jpg");
            Console.WriteLine(twitter.PublishToTwitter("Mira esta imágen!",@"LukeEditado.jpg"));

            
        }
    }
}

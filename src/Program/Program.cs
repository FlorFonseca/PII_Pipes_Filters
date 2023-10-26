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

        //  EJERCICIO 3
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
        //     image = pipeserial2.Send(image);

        //     provider.SavePicture(image, "LukeEditado.jpg");


        //     TwitterFilter twitterFilter = new TwitterFilter();
        //     twitterFilter.Filter(image);
        //}

        //  EJERCICIO 4
        {
            PictureProvider provider = new PictureProvider();
            IPicture image = provider.GetPicture(@"beer.jpg");
            ConditionalFilter conditionalFilter = new ConditionalFilter();
            TwitterFilter twitterFilter = new TwitterFilter();

            IPipe pipenull = new PipeNull ();

            IFilter blur = new FilterBlurConvolution();
            IPipe pipeserial1 = new PipeSerial(twitterFilter, pipenull);

            IFilter negative = new FilterNegative();
            IPipe pipeserial2 = new PipeSerial(negative, pipenull);
            

            IPipe pipeFork = new PipeFork(conditionalFilter, pipeserial1, pipeserial2);
            image = pipeFork.Send(image);
            

            provider.SavePicture(image, "BeerEditado.jpg");


            
        }
    }
}

using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        //Ejercicio 1
        {
            PictureProvider provider = new PictureProvider();
            IPicture image = provider.GetPicture(@"luke.jpg");

            IPipe pipenull = new PipeNull ();
            image = pipenull.Send(image);
            IFilter blur = new FilterNegative();
            
            IPipe pipeserial1 = new PipeSerial(blur, pipenull);
            image = pipeserial1.Send(image);
            IFilter negative = new FilterGreyscale();

            IPipe pipeserial2 = new PipeSerial(negative, pipeserial1);

            provider.SavePicture(image, @"luke.jpg");
        }
    }
}

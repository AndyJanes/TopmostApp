using System;
using System.Threading;

namespace TopmostApp
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Thread thread = new(() =>
            {
                var app = new App();
                app.Run();
            });

            //If you launch directly from the host bridge it won't be STA.
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}

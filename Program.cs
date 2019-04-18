using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var wait_response = true;

        var client = new UdpSocket((byte[] buf) =>
        {
            wait_response = false;
            Console.WriteLine("recv message: {0}", ASCIIEncoding.UTF8.GetString(buf));
        });

        client.Connect("localhost", 13377);
        client.SendUTF8("Hello KCP.");

        while (wait_response)
        {
            client.Update();
            System.Threading.Thread.Sleep(10);
        }
    }
}


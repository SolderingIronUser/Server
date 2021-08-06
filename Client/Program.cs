using System;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    const string IpAddresGlobal = "5.188.139.74";
                    const string IpAddresLocal = "127.0.0.1";
                    TcpClient client = new TcpClient(IpAddresGlobal, 7000);
                    Console.WriteLine("Connected");

                    NetworkStream stream = client.GetStream();

                    Console.WriteLine("Enter your message");
                    string request = Console.ReadLine()+" "+"Random Number " + DiffiHellman();
                    byte[] bytesWrite = Encoding.ASCII.GetBytes(request);
                    stream.Write(bytesWrite, 0, bytesWrite.Length);
                    stream.Flush();
                    Console.WriteLine("Client sent request");

                    byte[] bytesRead = new byte[3000];
                    int lenght = stream.Read(bytesRead, 0, bytesRead.Length);
                    string answer = Encoding.ASCII.GetString(bytesRead, 0, lenght);
                    //Console.WriteLine(answer);

                    //client.Close();
                    //Console.Write("Disconnected");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                //Console.ReadLine();
            }
        }

        static int DiffiHellman()
        {
            Random rand=new Random();
            int number = rand.Next(250);
            return number;
        }
    }
}

using System;
using System.Net.Sockets;
using System.Text;
using System.Net;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpListener serverSocket = new TcpListener(IPAddress.Any, 7000);
                Console.WriteLine("Server Started");
                serverSocket.Start();

                while (true)
                {
                    TcpClient clientSocket = serverSocket.AcceptTcpClient();
                    NetworkStream stream = clientSocket.GetStream();

                    byte[] bytes = new byte[3000];
                    int lenght = stream.Read(bytes, 0, bytes.Length);
                    string request = Encoding.ASCII.GetString(bytes, 0, lenght);
                    Console.WriteLine("Get request: " + request);

                    string message = "Lenght of your request: " + request.Length;
                    bytes = Encoding.ASCII.GetBytes(message);
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();

                    Console.WriteLine("Send message: " + message);
                    //clientSocket.Close();
                }
                //serverSocket.Stop();
                //Console.WriteLine("Server Stoped");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.ReadKey();

        }

    }
}

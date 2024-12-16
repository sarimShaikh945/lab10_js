using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ServerSide
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(888);
            server.Start();
            Console.Write("Server Started!! ");
            Console.WriteLine("Waiting for Clients");

            Socket clientsdoor = server.AcceptSocket();

            if (clientsdoor.Connected)
            {
                
                NetworkStream ns = new NetworkStream(clientsdoor);
                StreamWriter sw = new StreamWriter(ns);
		Console.WriteLine("server >> WELCOME CLIENT!!!");
                sw.WriteLine("Welcome Client");
                sw.Flush();

               while (true) //(!sr.EndofStream)
                {
		    StreamReader sr = new StreamReader(ns);
                    Console.WriteLine("Client " + sr.ReadLine());
                    
                }
                sw.Close();
                sr.Close();
                ns.Close();
            }
            clientsdoor.Close();

        }

    }

}

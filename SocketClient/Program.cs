using SocketClient.Requests;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


public class Request
{
    public static int Main(String[] args)
    {
        Meniu();
        return 0;
    }


    public static void Meniu()
    {
        IHttpRequest request;
        int choice = 0;

        do
        {

            Console.WriteLine("============================");
            Console.WriteLine("1 - www.w3.org");
            Console.WriteLine("2 - local-host");
            Console.WriteLine("0 - EXIT");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Enter your Choice:");


            

            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("============================");


            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    request = new HttpRequest("GET / HTTP/1.1\r\nHost: www.w3.org\r\nConnection: keep-alive\r\nAccept: text/html\r\nUser-Agent: CSharpTests\r\n\r\n");
                    request.CreateHttpGetRequest();
                    break;
                case 2:
                    request = new HttpRequest("GET / HTTP/1.1\r\nHost: localhost\r\nConnection: keep-alive\r\nAccept: text/html\r\nUser-Agent: CSharpTests\r\n\r\n");
                    request.CreateHttpGetRequest();
                    break;
                default:
                    Console.WriteLine("incorrect choice");
                    break;
            }


            if (choice.Equals(1))
            {
                request = new HttpRequest("GET / HTTP/1.1\r\nHost: www.w3.org\r\nConnection: keep-alive\r\nAccept: text/html\r\nUser-Agent: CSharpTests\r\n\r\n");
                request.CreateHttpGetRequest();
            }

        } while (!choice.Equals(0));

        Console.WriteLine("End");

    }
}

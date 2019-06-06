using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


public class SocketClient
{
    public static int Main(String[] args)
    {
        Meniu();
        //StartClient();
        return 0;
    }


    public static void Meniu()
    {

        int choice = 0;

        do
        {

            Console.WriteLine("============================");
            Console.WriteLine("1 - www.w3.org");
            Console.WriteLine("0 - EXIT");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Enter your Choice:");


            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("============================");

            if (choice.Equals(1)) CreateHttpGetRequest();

        } while (!choice.Equals(0));

        Console.WriteLine("End");

    }

    public static void CreateHttpGetRequest()
    {
        byte[] bytes = new byte[1024];

        try
        {
            IPHostEntry host = Dns.GetHostEntry("www.w3.org");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 80);

            Socket sender = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                Console.WriteLine("CLIENT");
                sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());


                byte[] msg = Encoding.ASCII.GetBytes("GET / HTTP/1.1\r\nHost: www.w3.org\r\nConnection: keep-alive\r\nAccept: text/html\r\nUser-Agent: CSharpTests\r\n\r\n");

                int bytesSent = sender.Send(msg);

                int bytesRec = sender.Receive(bytes);


                Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();


            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}

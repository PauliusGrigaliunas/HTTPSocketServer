using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


public class SocketClient
{
    public static int Main(String[] args)
    {
        StartClient();
        return 0;
    }


    public static void StartClient()
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

                /*byte[] msg = Encoding.ASCII.GetBytes("GET / hello.htm HTTP / 1.1 \r\n" +
                    "User-Agent: Mozilla / 4.0(compatible; MSIE5.01; Windows NT) \r\n" +
                    "Host: www.tutorialspoint.com\r\n" +
                    "Accept-Language: en - us \r\n" +
                    "Accept-Encoding: gzip, deflate \r\n" +
                    "Connection: Keep-Alive\r\n" +
                    "\r\n");*/


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

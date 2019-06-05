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
            IPHostEntry host = Dns.GetHostEntry("w3schools.com"); 
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 80);

            Socket sender = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                Console.WriteLine("CLIENT");
                sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                byte[] msg = Encoding.ASCII.GetBytes("GET /test/demo_form.php?name1=value1&name2=value2 \r\n" +
                    "Host: w3schools.com\r\n" +
                    "Content-Length: 0\r\n" +
                    "\r\n");



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

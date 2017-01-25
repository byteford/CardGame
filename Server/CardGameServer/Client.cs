using System;
using System.Net.Sockets;
using System.Text;
namespace CardGameServer
{
	public class Client
	{
		TcpClient _client;
        public Client (TcpClient client)
		{
			_client = client;
			Console.WriteLine ("Client connected" + _client.Client.AddressFamily);
            SendMessage("welcome to the server");
            SendMessage("You are player 1");
            
		}
        public void SendMessage(string message)
        {
            _client.Client.Send(Encoding.ASCII.GetBytes(message));
        }
	}
}


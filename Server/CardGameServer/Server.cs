using System;
using System.Net.Sockets;
using System.Collections.Generic;
namespace CardGameServer
{
	public class Server
	{
		TcpListener _Listener;
		int _port;
		List<Client> _clients;
		public Server (int port)
		{
			_port = port;
			_clients = new List<Client> ();
			_Listener = new TcpListener (System.Net.IPAddress.Any, _port);
			_Listener.Start ();
			addClient ();

		}
		public void addClient(){
			TcpClient temp = _Listener.AcceptTcpClient ();
            
			_clients.Add(new Client(temp));
			Console.WriteLine ("Client connected");
		}

		public void ShutDown(){
			Console.WriteLine ("Shutting down");
			_Listener.Stop ();
		}

	}
}


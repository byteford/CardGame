using System;

namespace CardGameServer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Starting server");
			Server temp = new Server (5260);
            Console.WriteLine("press enter to shutdown");
            string tempstr = Console.ReadLine();
			//temp.ShutDown ();
		}
	}
}

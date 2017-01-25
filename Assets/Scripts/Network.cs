using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using System.Text;
using System.Threading;

public class Network : MonoBehaviour {
	TcpClient _client;
    Thread reciveThread;
	// Use this for initialization
	void Start () {
		_client = new TcpClient ("localhost", 5260);
        Debug.Log("connected");
        reciveThread = new Thread(new ThreadStart(Recive));
        reciveThread.Start();
	}
	// Update is called once per frame
	void Update () {

	}
    
    public string byteToString(Byte[] bytes)
    {
        return Encoding.ASCII.GetString(bytes);
    }
    void Recive()
    {
        try
        {
            Byte[] bytes = new Byte[1024];
            _client.Client.Receive(bytes);
            Debug.Log(byteToString(bytes));
        }
        catch(Exception e)
        {
            Debug.Log(e.ToString());
        }
        Recive();
        
    }
}

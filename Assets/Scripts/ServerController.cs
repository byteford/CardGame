using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ServerController : NetworkBehaviour {
	public GameObject playerPref;
	public GameObject UI;
	// Use this for initialization
	void Start () {
		if (!isServer)
			Destroy (gameObject);
		if (isClient) {
			CmdSpawnPlayer ();
			Instantiate (UI);
		}
	}
	void Update(){
		
	}
	[Command]
	void CmdSpawnPlayer(){
		GameObject temp = Instantiate (playerPref);
		NetworkServer.SpawnWithClientAuthority (playerPref, connectionToClient);
	}

}

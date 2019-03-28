using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{

    [SyncVar]
    public string username = "Username";

    [Command]
    void CmdSetUsername(string user)
    {
        username = user;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        string myUsername = string.Format("Player {0}", netId.Value);
        CmdSetUsername(myUsername);
    }
}

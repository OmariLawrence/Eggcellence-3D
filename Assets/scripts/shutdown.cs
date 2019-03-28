using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class shutdown : MonoBehaviour
{
    public NetworkLobbyManager nlm = null;
    public NetworkManagerHUD hud = null;


    // Start is called before the first frame update
    void Start()
    {
        if(nlm!=null && hud != null)
        {
            nlm.enabled = true;
            hud.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (nlm != null && hud != null)
            {
                nlm.enabled = false;
                hud.enabled = false;
            }
        }
        if(SceneManager.GetActiveScene().name.Contains("Lobby"))
        {
            nlm.enabled = true;
            hud.enabled = true;
        }
        else
        {
            nlm.enabled = false;
            hud.enabled = false;
        }
        
    }
}

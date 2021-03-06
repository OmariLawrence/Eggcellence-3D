﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    int maxHealth = 10;
    int currHealth;
    public Text info;
    //public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;

        if (isServer)
        {
            DeathMatch.addPlayer(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "FrittataForest" || SceneManager.GetActiveScene().name == "multiplayer_matchmaking")
        {
            takeDamage(100);
        }
    }

    public void takeDamage(int amount)
    {
        if(!isServer || currHealth <= 0)
        {
            return;
        }
        currHealth -= amount;

        if (currHealth <= 0)
        {
            currHealth = 0;

            RpcDied();

            if (DeathMatch.removePlayerAndCheckWinner(this))
            {
                Health player = DeathMatch.getWinner();
                player.RpcWon();

                Invoke("BackToLobby", 3f);
            }

            return;
        }
    }

    [ClientRpc]
    void RpcDied()
    {
        info = FindObjectOfType<Text>();
        if (isLocalPlayer)
        {
            info.text = "You Lose";
            GetComponent<playermoverment_net>().enabled = false;
            GetComponent<spawner>().enabled = false;
        }
    }

    [ClientRpc]
    public void RpcWon()
    {
        if (isLocalPlayer)
        {
            info = FindObjectOfType<Text>();
            info.text = "You Win";
        }
    }

    void BackToLobby()
    {
        FindObjectOfType<NetworkLobbyManager>().ServerReturnToLobby();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "projectile")
        {
            return;
        }

        if (this != null)
        {
            this.takeDamage(1);
        }

    }
}

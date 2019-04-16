using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DeathMatch : NetworkBehaviour
{
    static List<Health> players = new List<Health>();

    public static void addPlayer(Health h)
    {
        players.Add(h);
    }

    public static bool removePlayerAndCheckWinner(Health h)
    {
        players.Remove(h);

        if(players.Count == 1)
        {
            return true;
        }

        return false;
    }

    public static Health getWinner()
    {
        if(players.Count != 1)
        {
            return null;
        }

        Health winner = players[0];

        players = new List<Health>();

        return winner;
    }
}

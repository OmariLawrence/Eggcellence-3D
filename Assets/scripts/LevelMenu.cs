using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void Start()
    {
        
    }
    public void Level1()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Level2()
    {
        SceneManager.LoadScene("forestLobby");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}

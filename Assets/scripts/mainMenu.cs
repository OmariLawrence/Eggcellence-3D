using UnityEngine.SceneManagement;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void quitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}

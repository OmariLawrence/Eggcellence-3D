using UnityEngine.SceneManagement;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public void Start()
    {
        Resolution res = Screen.currentResolution;
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
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

using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void Mute()
    {
        Time.timeScale = 0;
    }


    public void Button_Restart()
    {
        string gameScene = "GameScene";

        SceneManager.LoadScene(gameScene);
    }


    public void Button_Menu()
    {
        string menuScene = "MenuScene";

        SceneManager.LoadScene(menuScene);
    }


    public void Button_Exit()
    {
        Application.Quit();
    }
}
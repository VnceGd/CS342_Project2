using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("House_ver02");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("House");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

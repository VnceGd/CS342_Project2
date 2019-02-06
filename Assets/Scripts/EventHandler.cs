using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EventHandler : MonoBehaviour
{
    public GameObject UIManager;
    private UIHandler UIHandler;

    public GameObject player;
    private LimbManager limbManager;

    public GameObject gameOverScreen;
    public GameObject victoryScreen;

    public TMPro.TextMeshProUGUI timerText;
    public float startTime = 6.0f;
    private float timeRemaining;
    private bool gameInProgress;

    public bool[] taskList = new bool[2];
    // Tasks:
    //   1. Eat cookie
    //   2. Go to bed
    public TextMeshProUGUI cookieTask;
    public TextMeshProUGUI bedTask;

    // Start is called before the first frame update
    public void Start()
    {
        UIHandler = UIManager.GetComponent<UIHandler>();
        limbManager = player.GetComponent<LimbManager>();

        timeRemaining = startTime;
        gameInProgress = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameInProgress)
        {
            if (timeRemaining > 0.0f)
            {
                timeRemaining -= Time.deltaTime;

                float minutes = Mathf.Floor(timeRemaining / 60.0f);
                if (minutes < 0.0f)
                {
                    minutes = 0.0f;
                }
                float seconds = timeRemaining % 60.0f;
                if (seconds < 0.0f)
                {
                    seconds = 0.0f;
                }
                string s = minutes.ToString("00:") +
                           seconds.ToString("00.00");
                timerText.text = s;
            }
            else
            {
                if (timeRemaining < 0.0f)
                {
                    timeRemaining = 0.0f;
                    UIHandler.BlackOut();
                }
            }
        }
    }

    public void CompleteTask(int index)
    {
        taskList[index] = true;
        switch (index)
        {
            case 0:
                cookieTask.fontStyle = FontStyles.Strikethrough;
                break;
            case 1:
                bedTask.fontStyle = FontStyles.Strikethrough;
                break;
        }
    }

    // Reload the current scene
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Show game over screen, prevent player movement
    public void GameOver(bool victory)
    {
        gameInProgress = false;
        limbManager.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        if (victory)
        {
            victoryScreen.SetActive(true);
        }
        else
        {
            gameOverScreen.SetActive(true);
        }
    }

    // Quit the game
    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public GameObject UIManager;
    private UIHandler UIHandler;

    public GameObject player;
    private LimbManager limbManager;

    public GameObject gameOverScreen;

    public Transform spawnPoint;

    public TMPro.TextMeshProUGUI timerText;
    public float startTime = 6.0f;
    private float timeRemaining;
    private bool gameOver;

    // Start is called before the first frame update
    public void Start()
    {
        UIHandler = UIManager.GetComponent<UIHandler>();
        limbManager = player.GetComponent<LimbManager>();

        timeRemaining = startTime;
        gameOver = false;

        //Instantiate(player, spawnPoint.transform);
    }

    // Update is called once per frame
    private void Update()
    {
        if(timeRemaining > 0.0f)
        {
            timeRemaining -= Time.deltaTime;

            float minutes = Mathf.Floor(timeRemaining / 60.0f);
            float seconds = timeRemaining % 60.0f;
            string s = minutes.ToString("00:") +
                       seconds.ToString("00.00");
            timerText.text = s;
        }
        else
        {
            if(timeRemaining < 0.0f)
            {
                timeRemaining = 0.0f;
                UIHandler.BlackOut();
            }
        }
    }

    public void NewGame()
    {
        timeRemaining = startTime;
        gameOver = false;
        player.GetComponentInChildren<Transform>().position = spawnPoint.transform.position;
        //Destroy(GameObject.FindWithTag("Player"));
        //Instantiate(player, spawnPoint.transform);
        UIHandler.Start();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GameOver()
    {
        gameOver = true;
        limbManager.enabled = false;
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}

using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject eventManager;
    private EventHandler eventHandler;

    public GameObject victoryScreen;

    public void Start()
    {
        eventHandler = eventManager.GetComponent<EventHandler>();
    }

    // Tell EventHandler to show victory screen
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            eventHandler.GameOver(true);
        }
    }
}

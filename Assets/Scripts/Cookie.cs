using UnityEngine;

public class Cookie : MonoBehaviour
{
    public GameObject door;
    private Door doorScript;

    public EventHandler eventHandler;

    // Start is called before the first frame update
    void Start()
    {
        eventHandler = GameObject.Find("EventManager").GetComponent<EventHandler>();
        door = GameObject.Find("KitchenDoor");
        doorScript = door.GetComponent<Door>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.tag == "Player")
        {
            if(obj.name == "Spine")
            {
                doorScript.ToggleDoorLock();
                eventHandler.CompleteTask(0); // Eat cookie task
                Destroy(gameObject);
            }
        }
    }
}

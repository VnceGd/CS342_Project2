using UnityEngine;

public class CookieJar : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if(other.tag == "Player")
        {
            if(other.name == "Head")
            {
                // Trigger one of the win conditions
                // (Check off "Eat cookie" on the list of tasks)
            }
        }
    }
}

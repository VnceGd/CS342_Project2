using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10.0f);
    }
}

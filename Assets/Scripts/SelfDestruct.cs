using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float lifetime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}

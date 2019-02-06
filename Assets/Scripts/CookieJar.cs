using UnityEngine;

public class CookieJar : MonoBehaviour
{
    public GameObject cookie;
    public GameObject smashParticles;

    private Rigidbody jarBody;

    public void Start()
    {
        jarBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Mathf.Abs(jarBody.velocity.x) > 1f || Mathf.Abs(jarBody.velocity.y) > 1f)
        {
            GameObject cookieClone = Instantiate(cookie, transform);
            GameObject particleClone = Instantiate(smashParticles, transform);
            cookieClone.transform.parent = null;
            particleClone.transform.parent = null;
            Destroy(gameObject);
        }
    }
}

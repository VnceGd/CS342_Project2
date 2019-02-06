using UnityEngine;

public class LimbFollowMouse : MonoBehaviour
{
    public float mouseSensitivity = 300.0f;
    public float torqueSensitivity = 5.0f;
    public float maxVelocity = 5.0f;
    public Rigidbody spine;

    private Rigidbody limbBody;
    private HingeJoint limbJoint;
    private bool colliding;
    private bool anchored;
    public GameObject throwable;
    public FixedJoint throwableJoint;
    public GameObject dynamic;

    // Start is called before the first frame update
    public void Start()
    {
        limbBody = GetComponent<Rigidbody>();
        limbJoint = GetComponent<HingeJoint>();
        colliding = false;
        anchored = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_y = Input.GetAxis("Mouse Y");
        Vector3 move_force = Vector3.zero;

        // Limit force
        if (mouse_x > 5.0f)
        {
            mouse_x = 5.0f;
        }
        else if (mouse_x < -5.0f)
        {
            mouse_x = -5.0f;
        }
        if (mouse_y > 5.0f)
        {
            mouse_y = 5.0f;
        }
        else if (mouse_y < -5.0f)
        {
            mouse_y = -5.0f;
        }

        if (Mathf.Abs(mouse_x) > 0.0f)
        {
            move_force += Vector3.right * mouse_x * Time.deltaTime * mouseSensitivity;
        }
        if (Mathf.Abs(mouse_y) > 0.0f)
        {
            move_force += Vector3.up * mouse_y * Time.deltaTime * mouseSensitivity;
        }
        if (!anchored)
        {
            if (limbBody.velocity.x < 5.0f && limbBody.velocity.y < 10.0f)
            {
                limbBody.AddForce(move_force);
            }
        }
        else
        {
            spine.AddForce(move_force * torqueSensitivity);
        }

        if (Input.GetButton("Fire1"))
        {
            if (colliding)
            {
                if (throwable == null)
                {
                    if (dynamic == null)
                    {
                        limbBody.constraints = RigidbodyConstraints.FreezePosition;
                    }
                    else
                    {
                        if (GetComponent<FixedJoint>() == null)
                        {
                            gameObject.AddComponent<FixedJoint>().connectedBody = dynamic.GetComponent<Rigidbody>();
                        }
                    }
                    anchored = true;
                }
                else
                {
                    if (throwableJoint == null)
                    {
                        throwableJoint = throwable.AddComponent<FixedJoint>();
                        throwableJoint.connectedBody = limbBody;
                    }
                }
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (throwable == null)
            {
                if (dynamic == null)
                {
                    limbBody.constraints = RigidbodyConstraints.None;
                }
                else
                {
                    Destroy(GetComponent<FixedJoint>());
                    dynamic = null;
                }
                anchored = false;
            }
            else
            {
                Destroy(throwableJoint);
                throwable = null;
            }
        }
    }

    // While colliding, check if other object is Throwable or Dynamic
    private void OnCollisionStay(Collision collision)
    {
        if (enabled && collision.gameObject.tag != "Player")
        {
            colliding = true;
            if (collision.gameObject.tag == "Throwable")
            {
                throwable = collision.gameObject;
            }
            else if (collision.gameObject.tag == "Dynamic")
            {
                dynamic = collision.gameObject;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }

    // While colliding with trigger, check if other object is Throwable or Dynamic
    private void OnTriggerStay(Collider other)
    {
        if (enabled)
        {
            colliding = true;
            if (other.gameObject.tag == "Throwable")
            {
                throwable = other.gameObject;
            }
            else if (other.gameObject.tag == "Dynamic")
            {
                dynamic = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
    }
}
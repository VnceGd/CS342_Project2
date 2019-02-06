using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked;

    private Rigidbody doorBody;
    private Material doorMaterial;

    // Start is called before the first frame update
    public void Start()
    {
        doorBody = GetComponent<Rigidbody>();
        doorMaterial = GetComponent<Renderer>().material;
        if (isLocked)
        {
            doorMaterial.color = Color.red;
            doorBody.constraints = RigidbodyConstraints.FreezeRotationY;
        }
    }

    public void ToggleDoorLock()
    {
        if(isLocked)
        {
            isLocked = false;
            doorMaterial.color = Color.green;
            doorBody.constraints = RigidbodyConstraints.None;
        }
        else
        {
            isLocked = true;
            doorMaterial.color = Color.red;
            doorBody.constraints = RigidbodyConstraints.FreezeRotationY;
        }
    }
}

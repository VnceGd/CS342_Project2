using UnityEngine;

public class LimbManager : MonoBehaviour
{
    public GameObject rightArm;
    public GameObject leftArm;
    public GameObject rightLeg;
    public GameObject leftLeg;
    public Material normalMaterial;
    public Material highlightMaterial;

    private LimbFollowMouse rightArmLimb;
    private LimbFollowMouse leftArmLimb;
    private LimbFollowMouse rightLegLimb;
    private LimbFollowMouse leftLegLimb;
    private bool cursorLocked;

    // Start is called before the first frame update
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = true;

        rightArmLimb = rightArm.GetComponent<LimbFollowMouse>();
        leftArmLimb = leftArm.GetComponent<LimbFollowMouse>();
        rightLegLimb = rightLeg.GetComponent<LimbFollowMouse>();
        leftLegLimb = leftLeg.GetComponent<LimbFollowMouse>();
        rightArmLimb.enabled = false;
        leftArmLimb.enabled = false;
        rightLegLimb.enabled = false;
        leftLegLimb.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (enabled)
        {
            // Enable limb based on keypress
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SelectLimb(1);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                SelectLimb(2);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                SelectLimb(3);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                SelectLimb(4);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Detach from static objects
                rightArm.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                leftArm.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                rightLeg.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                leftLeg.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                // Detach from dynamic objects
                FixedJoint rightArmJoint = rightArm.GetComponent<FixedJoint>();
                if(rightArmJoint != null)
                {
                    Destroy(rightArmJoint);
                    rightArmLimb.dynamic = null;
                }
                FixedJoint leftArmJoint = leftArm.GetComponent<FixedJoint>();
                if (leftArmJoint != null)
                {
                    Destroy(leftArmJoint);
                    leftArmLimb.dynamic = null;
                }
                FixedJoint rightLegJoint = rightLeg.GetComponent<FixedJoint>();
                if (rightLegJoint != null)
                {
                    Destroy(rightLegJoint);
                    rightLegLimb.dynamic = null;
                }
                FixedJoint leftLegJoint = leftLeg.GetComponent<FixedJoint>();
                if (leftLegJoint != null)
                {
                    Destroy(leftLegJoint);
                    leftLegLimb.dynamic = null;
                }

                // Detach throwable objects
                FixedJoint rightArmThrowable = rightArmLimb.throwableJoint;
                if(rightArmThrowable != null)
                {
                    Destroy(rightArmThrowable);
                    rightArmLimb.throwable = null;
                }
                FixedJoint leftArmThrowable = leftArmLimb.throwableJoint;
                if (leftArmThrowable != null)
                {
                    Destroy(leftArmThrowable);
                    leftArmLimb.throwable = null;
                }
                FixedJoint rightLegThrowable = rightLegLimb.throwableJoint;
                if (rightLegThrowable != null)
                {
                    Destroy(rightLegThrowable);
                    rightLegLimb.throwable = null;
                }
                FixedJoint leftLegThrowable = leftLegLimb.throwableJoint;
                if (leftLegThrowable != null)
                {
                    Destroy(leftLegThrowable);
                    leftLegLimb.throwable = null;
                }
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                if (cursorLocked)
                {
                    Cursor.lockState = CursorLockMode.None;
                    cursorLocked = false;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    cursorLocked = true;
                }
            }
        }
        else
        {
            DeselectLimbs();
        }
    }

    public void DeselectLimbs()
    {
        rightArmLimb.enabled = false;
        leftArmLimb.enabled = false;
        rightLegLimb.enabled = false;
        leftLegLimb.enabled = false;

        rightArm.GetComponent<MeshRenderer>().material = normalMaterial;
        leftArm.GetComponent<MeshRenderer>().material = normalMaterial;
        rightLeg.GetComponent<MeshRenderer>().material = normalMaterial;
        leftLeg.GetComponent<MeshRenderer>().material = normalMaterial;
    }

    public void SelectLimb(int limb)
    {
        DeselectLimbs();
        if (limb == 1)
        { // Left Arm
            leftArmLimb.enabled = true;
            leftArm.GetComponent<MeshRenderer>().material = highlightMaterial;
        }
        else if (limb == 2)
        { // Right Arm
            rightArmLimb.enabled = true;
            rightArm.GetComponent<MeshRenderer>().material = highlightMaterial;
        }
        else if (limb == 3)
        { // Left Leg
            leftLegLimb.enabled = true;
            leftLeg.GetComponent<MeshRenderer>().material = highlightMaterial;
        }
        else if (limb == 4)
        { // Right Leg
            rightLegLimb.enabled = true;
            rightLeg.GetComponent<MeshRenderer>().material = highlightMaterial;
        }
    }
}

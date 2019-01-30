using System.Collections;
using System.Collections.Generic;
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
                rightArmLimb.enabled = false;
                leftArmLimb.enabled = true;
                rightLegLimb.enabled = false;
                leftLegLimb.enabled = false;

                rightArm.GetComponent<MeshRenderer>().material = normalMaterial;
                leftArm.GetComponent<MeshRenderer>().material = highlightMaterial;
                rightLeg.GetComponent<MeshRenderer>().material = normalMaterial;
                leftLeg.GetComponent<MeshRenderer>().material = normalMaterial;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                rightArmLimb.enabled = true;
                leftArmLimb.enabled = false;
                rightLegLimb.enabled = false;
                leftLegLimb.enabled = false;

                rightArm.GetComponent<MeshRenderer>().material = highlightMaterial;
                leftArm.GetComponent<MeshRenderer>().material = normalMaterial;
                rightLeg.GetComponent<MeshRenderer>().material = normalMaterial;
                leftLeg.GetComponent<MeshRenderer>().material = normalMaterial;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                rightArmLimb.enabled = false;
                leftArmLimb.enabled = false;
                rightLegLimb.enabled = false;
                leftLegLimb.enabled = true;

                rightArm.GetComponent<MeshRenderer>().material = normalMaterial;
                leftArm.GetComponent<MeshRenderer>().material = normalMaterial;
                rightLeg.GetComponent<MeshRenderer>().material = normalMaterial;
                leftLeg.GetComponent<MeshRenderer>().material = highlightMaterial;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                rightArmLimb.enabled = false;
                leftArmLimb.enabled = false;
                rightLegLimb.enabled = true;
                leftLegLimb.enabled = false;

                rightArm.GetComponent<MeshRenderer>().material = normalMaterial;
                leftArm.GetComponent<MeshRenderer>().material = normalMaterial;
                rightLeg.GetComponent<MeshRenderer>().material = highlightMaterial;
                leftLeg.GetComponent<MeshRenderer>().material = normalMaterial;
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
            rightArmLimb.enabled = false;
            leftArmLimb.enabled = false;
            rightLegLimb.enabled = false;
            leftLegLimb.enabled = false;
        }
    }
}

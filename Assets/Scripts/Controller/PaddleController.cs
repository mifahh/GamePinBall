using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;
    public float springPower;

    public AudioManager audioManager;

    private HingeJoint paddleHingeJoint;
    private float pressPosition;
    private float releasePosition;

    // Start is called before the first frame update
    private void Start()
    {
        paddleHingeJoint = gameObject.GetComponent<HingeJoint>();

        pressPosition = paddleHingeJoint.limits.max;
        releasePosition = paddleHingeJoint.limits.min;
    }

    // Update is called once per frame
    private void Update()
    {
        ReadInput();
        MovePaddle();
    }

    void MovePaddle()
    {
        
    }

    private void ReadInput()
    {
        JointSpring jointSpring = paddleHingeJoint.spring;

        if (Input.GetKey(input))
        {
            if (Input.GetKeyDown(input))
            {
            audioManager.PlaySFX(transform.position, "PaddleSFX");
            }
            jointSpring.spring = pressPosition;
        } else
        {
            jointSpring.spring = releasePosition;
        }

        paddleHingeJoint.spring = jointSpring;
    }
}

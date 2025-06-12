using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxSpeed;

    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
     rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    private void Update()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}

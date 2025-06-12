using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoominController : MonoBehaviour
{
    public Collider BallCollider;
    public CameraController cameraController;
    public float length;

    private void OnTriggerEnter(Collider other)
    {
        if (other == BallCollider)
        {
            cameraController.FollowTarget(BallCollider.transform, length);
        }
    }
}

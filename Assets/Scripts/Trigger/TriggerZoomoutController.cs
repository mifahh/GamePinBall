using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomoutController : MonoBehaviour
{
    public CameraController cameraController;
    public Collider ballCollider;

    private void OnTriggerEnter(Collider other)
    {
        if(other == ballCollider)
        {
            cameraController.BackToDefault();
        }
    }
}

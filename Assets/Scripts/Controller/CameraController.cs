using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float returnTime;
    public float followSpeed;
    public Transform target;

    private Vector3 defaultPosition;
    private float length;

    public Boolean hasTarget { get { return target != null; } }

    // Start is called before the first frame update
    private void Start()
    {
        defaultPosition = transform.position;
        target = null;
    }

    // Update is called once per frame
    private void Update()
    {
        if (hasTarget)
        {
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetToCameraDirection * length);

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void FollowTarget(Transform targetTransform, float targetlength)
    {
        StopAllCoroutines();

        target = targetTransform;
        length = targetlength;
    }

    public void BackToDefault()
    {
        StopAllCoroutines();

        target = null;

        StartCoroutine(MoveToTarget(defaultPosition, returnTime));
    }

    private IEnumerator MoveToTarget(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        //mengubah posisi camera secara bertahap
        while (timer < time)
        {
            //mengubahnya dengan LinearInterpolation yang diubah ke SmoothStep
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer / time)); //(nilai awal, nilai maks, persentase terhadap Perpindahan)

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        //menetapkan posisi akhir setelah perpindahan selesai
        transform.position = target;
    }
}

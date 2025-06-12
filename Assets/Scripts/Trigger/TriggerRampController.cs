using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRampController : MonoBehaviour
{
    public float ScoreAddition;
    public Collider ballCollider;
    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other == ballCollider)
        {
            scoreManager.AddScore(ScoreAddition);
        }
    }
}

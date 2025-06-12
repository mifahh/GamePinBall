using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameOver : MonoBehaviour
{
    public Collider ballCollider;
    public GameObject GameOverUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other == ballCollider)
        {
            GameOverUI.SetActive(true);
        }
    }
}

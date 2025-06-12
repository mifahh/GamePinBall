using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider ball;
    public float multiplier;
    public Color color;

    public AudioManager audioManager;
    public VFXManager vFXManager;

    public float scoreAddition;
    public ScoreManager scoreManager;

    private Renderer bumperRenderer;
    private Animator bumperAnimator;

    // Start is called before the first frame update
    private void Start()
    {
        bumperRenderer = gameObject.GetComponent<Renderer>();
        bumperAnimator = gameObject.GetComponent<Animator>();
        bumperRenderer.material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == ball)
        {
            Rigidbody ballRig = ball.GetComponent<Rigidbody>();

            scoreManager.AddScore(scoreAddition);
            ballRig.velocity *= multiplier;

            audioManager.PlaySFX(collision.transform.position, "BumperSFX");
            vFXManager.PlayVFX(collision.transform.position, "BumperVFX");

            bumperAnimator.SetTrigger("Hit");
        }
    }
}

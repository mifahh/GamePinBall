using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Collider ball;
    public Material isOffMaterial;
    public Material isOnMaterial;

    public AudioManager audioManager;
    public VFXManager vFXManager;
    
    public ScoreManager scoreManager;
    public float scoreAddition;

    private Renderer switchRenderer;
    private SwitchState switchState = SwitchState.Off; //default state

    // Start is called before the first frame update
    private void Start()
    {
        switchRenderer = gameObject.GetComponent<Renderer>();
        setActive(false);
        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == ball)
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        scoreManager.AddScore(scoreAddition);
        if (switchState == SwitchState.On)
        {
            setActive(false);
        }
        else
        {
            setActive(true);
        }
    }
    private void setActive(bool isActive)
    {
        if (isActive == true)
        {
            switchState = SwitchState.On;
            switchRenderer.material = isOnMaterial;
            audioManager.PlaySFX(transform.position, "SwitchSFX");
            vFXManager.PlayVFX(transform.position, "SwitchVFX");
            StopAllCoroutines();
        }
        else
        {
            switchState = SwitchState.Off;
            switchRenderer.material = isOffMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private IEnumerator BlinkTimerStart(float times)
    {
        yield return new WaitForSeconds(times);
        StartCoroutine(Blink(2));
    }
    private IEnumerator Blink(int times)
    {
        switchState = SwitchState.Blink;
        for (int i = 0; i < times; i++)
        {
            switchRenderer.material = isOnMaterial;
            audioManager.PlaySFX(transform.position, "SwitchSFX");
            yield return new WaitForSeconds(0.5f);
            switchRenderer.material = isOffMaterial;
            audioManager.PlaySFX(transform.position, "SwitchSFX");
            yield return new WaitForSeconds(0.5f);
        }
        switchState = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(5));
    }

}

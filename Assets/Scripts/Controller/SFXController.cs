using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    private AudioSource SFXAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        SFXAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //menghapus GameObject sfx ini saat tidak diplay lagi setelah playOnAwake
        if (SFXAudioSource.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}

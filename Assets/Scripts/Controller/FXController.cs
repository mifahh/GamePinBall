using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXController : MonoBehaviour
{
    private ParticleSystem vfxParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        vfxParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //menghapus GameObject sfx ini saat tidak diplay lagi setelah playOnAwake
        if (vfxParticleSystem.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}

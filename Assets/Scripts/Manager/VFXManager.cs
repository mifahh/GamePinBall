using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    private enum VFXName
    {
        BumperVFX = 0,
        SwitchVFX = 1
    }

    public GameObject[] vfxSource;

    //fungsi menjalankan SFX dari script lain
    public void PlayVFX(Vector3 spawnPosition, string name)
    {
        Enum.TryParse<VFXName>(name, out VFXName vfxName);
        int vfxIndex = (int) vfxName;

        Instantiate(vfxSource[vfxIndex], spawnPosition, vfxSource[vfxIndex].transform.rotation);
    }
}

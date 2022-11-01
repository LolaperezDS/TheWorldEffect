using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PtController : MonoBehaviour
{
    private ParticleSystem pt;
    void Start()
    {
        pt = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        pt.playbackSpeed = TimeCustom.multiplayer;
    }
}

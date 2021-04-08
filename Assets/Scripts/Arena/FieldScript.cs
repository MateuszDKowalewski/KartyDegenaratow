using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FieldScript : MonoBehaviour
{
    public ParticleSystem goOnFieldParticle;
    public float scale;

    public void StartParticle()
    {
        goOnFieldParticle.Play();
    }

    public void EndParticle()
    {
        goOnFieldParticle.Pause();
        goOnFieldParticle.Clear();
    }
}

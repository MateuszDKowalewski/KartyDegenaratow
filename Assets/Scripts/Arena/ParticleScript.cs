using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    void Start()
    {
        ParticleSystem particleSystem = this.GetComponent(typeof(ParticleSystem)) as ParticleSystem;
        if (particleSystem)
        {
            particleSystem.Stop();
            particleSystem.Clear();
        }
    }

}

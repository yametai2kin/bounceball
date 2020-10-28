using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEffect : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        var systems = GetComponentsInChildren<ParticleSystem>();
        foreach( ParticleSystem system in systems )
        {
            if( !system.isStopped )
            {
                return;
            }
        }
        Destroy( this.gameObject );
    }

}

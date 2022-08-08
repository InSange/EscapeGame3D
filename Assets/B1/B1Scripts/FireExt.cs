using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExt : MonoBehaviour
{
    public ParticleSystem waterParticle;

    public void GetFireExt()
    {
        gameObject.SetActive(false);
        Player.player.fireExt = true;
    }

    public void shoot()
    {
        waterParticle.Play();
    }
    public void shootStop()
    {
        waterParticle.Stop();
    }
}

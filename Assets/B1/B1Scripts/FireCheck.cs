using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCheck : MonoBehaviour
{
    float delayOff = 0;
    void OnParticleCollision(GameObject other)
    {
        delayOff = delayOff + Time.deltaTime;
        //Debug.Log(delayOff);
        if (delayOff >= 1.5f)
        {
            Debug.Log(this.gameObject.name + other.name);
            gameObject.SetActive(false);
        }
    }
}

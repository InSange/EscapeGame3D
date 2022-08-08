using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;
    private Player p;

    private void Awake()
    {
        p = FindObjectOfType<Player>();
        p.gameObject.SetActive(false);
        if(startPoint == p.currentMapName)
        {
            p.transform.position = this.transform.position;
        }
        p.gameObject.SetActive(true);
    }
}

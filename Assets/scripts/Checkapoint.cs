using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkapoint : MonoBehaviour
{
    private gameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            gm.lastcheckpointpos = transform.position;
        }
    }
}

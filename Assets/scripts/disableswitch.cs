using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableswitch : MonoBehaviour
{
    private WorldSwitcher playerswitchscript;

    private void Start()
    {
        playerswitchscript = GameObject.FindGameObjectWithTag("Player").GetComponent<WorldSwitcher>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Debug.Log("LOCKED!");
            playerswitchscript.isunlocked = false;
        }
    }
}

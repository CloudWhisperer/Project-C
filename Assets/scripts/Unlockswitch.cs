using UnityEngine;

public class Unlockswitch : MonoBehaviour
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
            Debug.Log("UNLOCKED");
            playerswitchscript.isunlocked = true;
        }
    }

}

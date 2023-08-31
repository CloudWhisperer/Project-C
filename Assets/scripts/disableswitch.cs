using UnityEngine;

public class disableswitch : MonoBehaviour
{
    private WorldSwitcher playerswitchscript;
    public static bool lockondeath = false;

    private void Start()
    {
        playerswitchscript = GameObject.FindGameObjectWithTag("Player").GetComponent<WorldSwitcher>();

        if(lockondeath == true)
        {
            if (playerswitchscript.isunlocked)
            {
                playerswitchscript.isunlocked = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Debug.Log("LOCKED!");
            playerswitchscript.isunlocked = false;
            lockondeath = true;
        }
    }
}

using UnityEngine;

public class Unlockswitch : MonoBehaviour
{
    private WorldSwitcher playerswitchscript;
    public GameObject blockage1;
    public static bool unlockondeath = false;

    private void Start()
    {
        playerswitchscript = GameObject.FindGameObjectWithTag("Player").GetComponent<WorldSwitcher>();

        if(unlockondeath == true)
        {
            playerswitchscript.isunlocked = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Debug.Log("UNLOCKED");
            blockage1.SetActive(true);
            playerswitchscript.isunlocked = true;
            unlockondeath = true;
        }
    }

}

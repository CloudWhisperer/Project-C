using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class endingspam : MonoBehaviour
{

    private WorldSwitcher switchscript;
    private JumpSwitchmechanic jumpscript;
    private Color defaultColor = new Color(1f, 1f, 1f, 1);
    private Color nearlyTransparent = new Color(1f, 1f, 1f, 0.5f);
    private Color nearlyTransparent2 = new Color(1f, 1f, 1f, 0.35f);
    private Color gone = new Color(1f, 1f, 1f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        switchscript = GameObject.FindGameObjectWithTag("Player").GetComponent<WorldSwitcher>();
        jumpscript = GameObject.FindGameObjectWithTag("jumpscript").GetComponent<JumpSwitchmechanic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerDialogueColl"))
        {
            switchscript.isunlocked = false;
            jumpscript.startmechanic = false;
            switchscript.isfakeworld = !switchscript.isfakeworld;

            if (switchscript.isfakeworld == true)
            {
                switchscript.Enable_fake_world();
            }

            else
            {
                switchscript.Disable_fake_world();
            }
        }
    }
}

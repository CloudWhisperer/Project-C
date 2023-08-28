using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class JumpSwitchmechanic : MonoBehaviour
{
    private WorldSwitcher switchscript;
    private bool startmechanic = false;

    private Color defaultColor = new Color(1f, 1f, 1f, 1);
    private Color nearlyTransparent = new Color(1f, 1f, 1f, 0.5f);
    private Color nearlyTransparent2 = new Color(1f, 1f, 1f, 0.35f);
    private Color gone = new Color(1f, 1f, 1f, 0f);

    private void Start()
    {
        switchscript = GameObject.FindGameObjectWithTag("Player").GetComponent<WorldSwitcher>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerDialogueColl"))
        {
            startmechanic = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && startmechanic == true)
        {
            switchscript.isfakeworld = !switchscript.isfakeworld;

            if (switchscript.isfakeworld == true)
            {
                Debug.Log("on");

                switchscript.Blueworldlight.intensity = 0.2f;

                switchscript.realworldtilemap.color = nearlyTransparent2;
                switchscript.fakeworldtilemap.color = defaultColor;
                switchscript.realworldbackground.color = gone;
                switchscript.fakeworldbackground.color = nearlyTransparent2;

                switchscript.fakeworldcolliders.enabled = true;
                switchscript.realworldcolliders.enabled = false;

                switchscript.r_world_death_colliders.SetActive(false);
                switchscript.f_world_death_colliders.SetActive(true);
            }

            else
            {
                Debug.Log("off");

                switchscript.Blueworldlight.intensity = 0f;

                switchscript.realworldtilemap.color = defaultColor;
                switchscript.fakeworldtilemap.color = nearlyTransparent;

                switchscript.realworldbackground.color = defaultColor;
                switchscript.fakeworldbackground.color = gone;

                switchscript.fakeworldcolliders.enabled = false;
                switchscript.realworldcolliders.enabled = true;

                switchscript.r_world_death_colliders.SetActive(true);
                switchscript.f_world_death_colliders.SetActive(false);
            }
        }
    }
}

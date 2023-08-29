using UnityEngine;

public class JumpSwitchmechanic : MonoBehaviour
{
    private CharacterController2D controller;
    private playermovement movementscript;
    private WorldSwitcher switchscript;
    public bool startmechanic = false;

    private void Start()
    {
        switchscript = GameObject.FindGameObjectWithTag("Player").GetComponent<WorldSwitcher>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        movementscript = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerDialogueColl"))
        {
            startmechanic = true;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && startmechanic == true && controller.m_Grounded == true
         || (Input.GetButtonDown("Jump") && startmechanic == true && movementscript.iswallsliding == true))
        {
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

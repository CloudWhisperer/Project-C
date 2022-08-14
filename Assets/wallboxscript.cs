using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallboxscript : MonoBehaviour
{

    public playermovement playerscript;
    public BoxCollider2D box;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            playerscript.canwalljump = true;
            Debug.Log("touch");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            playerscript.canwalljump = false;
            Debug.Log("exit");
        }
    }

}

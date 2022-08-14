using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    public CircleCollider2D circlecoll;
    public PhysicsMaterial2D slippery;
    public PhysicsMaterial2D friction;
    public Rigidbody2D rigid;

    public float horizontalmove = 0;
    bool jump = false;
    bool crouch = false;
    public float runspeed = 40f;
    public bool canslide = true;
    public bool canwalljump = true;

    [Header("Wall Jump")]
    public LayerMask groundlayer;
    public float walljumptime = 0.2f;
    public float wallslidespeed = 0.3f;
    public float walldistance = 0.5f;
    public bool iswallsliding = false;
    RaycastHit2D wallcheckhit;
    float jumptime;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        // walljumping

            if (horizontalmove > 0.1)
            {
                wallcheckhit = Physics2D.Raycast(transform.position, new Vector2(walldistance, 0), walldistance, groundlayer);
                Debug.DrawRay(transform.position, new Vector2(walldistance, 0), Color.blue);
            }

            else
            {
                wallcheckhit = Physics2D.Raycast(transform.position, new Vector2(-walldistance, 0), walldistance, groundlayer);
                Debug.DrawRay(transform.position, new Vector2(-walldistance, 0), Color.blue);
            }



        if (wallcheckhit == true && canwalljump && !controller.m_Grounded && horizontalmove != 0)
        {
            iswallsliding = true;
            jumptime = Time.time + walljumptime;
            controller.m_JumpForce = 2200f;
            canwalljump = false;
        }

        else if (jumptime < Time.time)
        {
            iswallsliding = false;
            canwalljump = false;
            anim.SetBool("isonwall", false);
            controller.m_JumpForce = 1800f;
        }

        if (iswallsliding == true)
        {
            anim.SetBool("isonwall", true);
            anim.SetBool("isjumping", false);
            rigid.velocity = new Vector2(rigid.velocity.x, Mathf.Clamp(rigid.velocity.y, wallslidespeed, float.MaxValue));
        }

    }

    // Update is called once per frame
    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;
        anim.SetFloat("speed", Mathf.Abs(horizontalmove));

        if (Input.GetButtonDown("Jump") && !controller.topcover)
        {
            jump = true;
            anim.SetBool("isjumping", true);
        }

        if (Input.GetButtonDown("Jump") && iswallsliding  && Input.GetButtonDown("Jump") && horizontalmove < -0.0001)
        {
            jump = true;
            anim.SetBool("isjumping", true);
            rigid.AddForce(Vector2.left * 3500);
            StartCoroutine("aircontrolcooldown");
        }

        if (Input.GetButtonDown("Jump") && iswallsliding  && Input.GetButtonDown("Jump") && horizontalmove > 0.0001)
        {
            jump = true;
            anim.SetBool("isjumping", true);
            rigid.AddForce(Vector2.right * 3500);
            StartCoroutine("aircontrolcooldown");
        }

        if (Input.GetButtonDown("Crouch") && canslide && controller.m_Grounded)
        {
            GetComponent<CircleCollider2D>().sharedMaterial = slippery;
            Performslide();
        }
    }

    public void Performslide()
    {
        canslide = false;
        crouch = true;
        runspeed = 0f;
        anim.SetBool("iscrouching", true);
        anim.SetBool("duck", false);

        if (horizontalmove < -0.001)
        {
            StartCoroutine("Addleft");
        }

        else if (horizontalmove > 0.001)
        {
            StartCoroutine("Addright");
        }

            StartCoroutine("stopslide");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            canwalljump = true;
            Debug.Log("touch");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            canwalljump = false;
            Debug.Log("exit");
        }
    }

    private IEnumerator aircontrolcooldown()
    {
        controller.m_AirControl = false;
        yield return new WaitForSeconds(0.5f);
        controller.m_AirControl = true;
    }

    private IEnumerator stopslide()
    {
        yield return new WaitForSeconds(0.7f);
        crouch = false;
        anim.SetBool("iscrouching", false);
        runspeed = 40f;

        if (controller.topcover == true)
        {
            anim.SetBool("duck", true);
            crouch = true;
        }
        else if (controller.topcover == false)
        {
            anim.SetBool("duck", false);
        }

        else
        {
            controller.topcover = false;
        }

        yield return new WaitForSeconds(0.25f);
        canslide = true;
    }

    private IEnumerator Addleft()
    {

        for (int i = 0; i < 18; i++)
        {
            rigid.AddForce(Vector2.left * 1000);
            yield return new WaitForSeconds(0.03f);
        }
    }

    private IEnumerator Addright()
    {
        for (int i = 0; i < 18; i++)
        {
            rigid.AddForce(Vector2.right * 1000);
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void Onlanding ()
    {
        anim.SetBool("isjumping", false);
    }

}

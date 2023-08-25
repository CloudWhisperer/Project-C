using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public CircleCollider2D m_CircleCollider;
    public GameObject deathparticle;
    private Animator anim;
    public Animator transition;
    public float transition_time;
    private playermovement playermovescript;
    private CharacterController2D charactercontroller;
    private WorldSwitcher worldSwitcher;
    private SpriteRenderer playersprite;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playersprite = GetComponent<SpriteRenderer>();
        worldSwitcher = GameObject.FindGameObjectWithTag("Player").GetComponent<WorldSwitcher>();
        charactercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        playermovescript = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Spike"))
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        playermovescript.enabled = false;
        charactercontroller.enabled = false;
        worldSwitcher.isunlocked = false;
        rb.simulated = false;


        Debug.Log("dead lol");
        deathparticle.SetActive(true);
        anim.Play("player_dead");
        yield return new WaitForSecondsRealtime(0.24f);
        playersprite.enabled = false;

        yield return new WaitForSecondsRealtime(1.1f);
        transition.SetTrigger("start");
        yield return new WaitForSecondsRealtime(transition_time);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

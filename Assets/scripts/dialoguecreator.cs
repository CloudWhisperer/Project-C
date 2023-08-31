using System.Collections;
using TMPro;
using UnityEngine;

public class dialoguecreator : MonoBehaviour
{
    private playermovement movescript;
    public Animator playeranim;
    public GameObject Dialogue;
    private Animator dialogueanim;
    public TextMeshProUGUI text;
    [SerializeField]
    [TextArea]
    private string[] lines;
    public float textspeed;
    private int index;
    private BoxCollider2D dialogue_trigger;
    private bool triggered = false;
    public GameObject next_dialogue_trigger;
    public AudioSource click;
    public AudioSource textscroll;
    private Rigidbody2D playerrigid;
    private CharacterController2D charcontroller;

    void Start()
    {
        playerrigid = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        movescript = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();
        charcontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        text.text = string.Empty;
        dialogueanim = Dialogue.GetComponent<Animator>();
        dialogue_trigger = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (triggered)
            {
                textscroll.Stop();

                if (text.text == lines[index])
                {
                    nextline();
                }
                else
                {
                    StopAllCoroutines();
                    text.text = lines[index];
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerDialogueColl"))
        {
            triggered = true;
            Dialogue.SetActive(true);
            dialogueanim.SetBool("out", false);

            if(charcontroller.m_Grounded)
            {
                Debug.Log("ALREADY GROUNDEDDDDD");
                movescript.enabled = false;
                playerrigid.simulated = false;
                playeranim.SetFloat("speed", 0f);
            }
            else
            {
                StartCoroutine(checkifgrounded());
            }


            dialogue_trigger.enabled = false;
            startdialog();
        }
    }

    private IEnumerator checkifgrounded()
    {
        while(charcontroller.m_Grounded != true)
        {
            Debug.Log("waiting");
            yield return null;
        }

        Debug.Log("ISGROUNDED!!!");
        movescript.enabled = false;
        playerrigid.simulated = false;
        playeranim.SetFloat("speed", 0f);
    }

    void startdialog()
    {
        if (triggered)
        {
            index = 0;
            StartCoroutine(typingline());
        }
    }

    IEnumerator typingline()
    {
        //delay for animation
        yield return new WaitForSeconds(0.6f);
        textscroll.Play();

        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textspeed);
        }

        textscroll.Stop();
    }

    void nextline()
    {
        click.Play();
        textscroll.Stop();

        if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(typingline());
        }

        //do the ending here
        else
        {
            StartCoroutine(closedialoguebox());
        }
    }

    IEnumerator closedialoguebox()
    {
        triggered = false;
        dialogueanim.SetBool("out", true);
        movescript.enabled = true;
        playerrigid.simulated = true;
        yield return new WaitForSeconds(1);
        next_dialogue_trigger.SetActive(true);
        dialoguemanaging.How_many_viewed += 1;
        Debug.Log(dialoguemanaging.How_many_viewed);
        gameObject.SetActive(false);
    }
}

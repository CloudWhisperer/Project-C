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

    void Start()
    {
        movescript = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();
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
            playeranim.SetFloat("speed", 0f);
            triggered = true;
            Dialogue.SetActive(true);
            dialogueanim.SetBool("out", false);
            movescript.enabled = false;
            dialogue_trigger.enabled = false;
            startdialog();
        }
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

        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void nextline()
    {
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
        yield return new WaitForSeconds(1);
        next_dialogue_trigger.SetActive(true);
        dialoguemanaging.How_many_viewed += 1;
        Debug.Log(dialoguemanaging.How_many_viewed);
        gameObject.SetActive(false);
    }
}

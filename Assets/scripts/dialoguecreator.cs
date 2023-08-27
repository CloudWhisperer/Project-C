using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dialoguecreator : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private string mytext;
    public GameObject Dialogue;
    private Animator dialogueanim;
    public TextMeshProUGUI text;
    public string[] lines;
    public float textspeed;
    private int index;
    private BoxCollider2D dialogue_trigger;
    private bool triggered = false;

    void Start()
    {
        text.text = string.Empty;
        dialogueanim = Dialogue.GetComponent<Animator>();
        dialogue_trigger = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;

        if (Dialogue.activeInHierarchy == false)
        {
            Dialogue.SetActive(true);
        }

        dialogueanim.SetTrigger("pop_in");
        dialogue_trigger.enabled = false;
        startdialog();
        //text.text = mytext;
    }

    void startdialog()
    {
        if(triggered)
        {
            index = 0;
            StartCoroutine(typingline());
            triggered = false;
        }
    }

    IEnumerator typingline()
    {
        //delay for animation
        yield return new WaitForSeconds(0.6f);

        foreach(char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

}

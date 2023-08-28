using System.Collections;
using UnityEngine;

public class dialoguemanaging : MonoBehaviour
{
    public static int How_many_viewed = 0;
    public GameObject[] DialogueTriggers;

    IEnumerator turnoff()
    {
        for (int i = 0; i < DialogueTriggers.Length; i++)
        {
            DialogueTriggers[i].SetActive(false);
        }
        yield return new WaitForSeconds(0.2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        switch (How_many_viewed)
        {
            case 1:
                StartCoroutine(turnoff());
                DialogueTriggers[1].SetActive(true);
                break;

            case 2:
                StartCoroutine(turnoff());
                DialogueTriggers[2].SetActive(true);
                break;

            case 3:
                StartCoroutine(turnoff());
                DialogueTriggers[3].SetActive(true);
                break;

            case 4:
                StartCoroutine(turnoff());
                DialogueTriggers[4].SetActive(true);
                break;

            case 5:
                StartCoroutine(turnoff());
                DialogueTriggers[5].SetActive(true);
                break;

            case 6:
                StartCoroutine(turnoff());
                DialogueTriggers[6].SetActive(true);
                break;

            case 7:
                StartCoroutine(turnoff());
                DialogueTriggers[7].SetActive(true);
                break;

            case 8:
                StartCoroutine(turnoff());
                DialogueTriggers[8].SetActive(true);
                break;

            case 9:
                StartCoroutine(turnoff());
                DialogueTriggers[9].SetActive(true);
                break;

            case 10:
                StartCoroutine(turnoff());
                DialogueTriggers[10].SetActive(true);
                break;

            case 11:
                StartCoroutine(turnoff());
                DialogueTriggers[11].SetActive(true);
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            How_many_viewed = 0;
        }

    }
}

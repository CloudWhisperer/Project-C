using System.Collections;
using UnityEngine;

public class fadetoend : MonoBehaviour
{
    public GameObject whitefade;
    public Animator whiteanim;
    public GameObject player;
    public GameObject endspawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(endgame());
    }

    IEnumerator endgame()
    {
        whitefade.SetActive(true);
        yield return new WaitForSeconds(1f);
        whiteanim.SetTrigger("whitefadeout");
        yield return new WaitForSeconds(0.3f);
        player.transform.position = endspawn.transform.position;
    }
}

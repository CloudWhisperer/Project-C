using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public CircleCollider2D m_CircleCollider;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Spike"))
        {
            Debug.Log("dead lol");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

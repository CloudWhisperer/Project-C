using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerpos : MonoBehaviour
{
    private gameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        transform.position = gm.lastcheckpointpos;
    }
}

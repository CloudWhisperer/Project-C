using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroyothermusic : MonoBehaviour
{
    public static dontdestroyonload instance;
    private GameObject othermusic;

    private void Start()
    {
        othermusic = GameObject.FindGameObjectWithTag("Music");
        Destroy(othermusic);
    }

}

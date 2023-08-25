using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class WorldSwitcher : MonoBehaviour
{
    private bool isfakeworld;
    public bool isunlocked;
    public Light2D Blueworldlight;

    public TilemapCollider2D realworldcolliders;
    public TilemapCollider2D fakeworldcolliders;

    public Tilemap realworldtilemap;
    public Tilemap fakeworldtilemap;

    public Tilemap realworldbackground;
    public Tilemap fakeworldbackground;

    private Color defaultColor = new Color(1f,1f,1f,1);
    private Color nearlyTransparent = new Color(1f,1f,1f, 0.5f);
    private Color nearlyTransparent2 = new Color(1f, 1f, 1f, 0.35f);
    private Color gone = new Color(1f, 1f, 1f, 0f);

    public GameObject r_world_death_colliders;
    public GameObject f_world_death_colliders;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch") && isunlocked == true)
        {
            isfakeworld = !isfakeworld;

            if (isfakeworld == true)
            {
                Debug.Log("on");

                Blueworldlight.intensity = 0.2f;

                realworldtilemap.color = nearlyTransparent2;
                fakeworldtilemap.color = defaultColor;
                realworldbackground.color = gone;
                fakeworldbackground.color = nearlyTransparent2;

                fakeworldcolliders.enabled = true;
                realworldcolliders.enabled = false;

                r_world_death_colliders.SetActive(false);
                f_world_death_colliders.SetActive(true);
            }

            else
            {
                Debug.Log("off");

                Blueworldlight.intensity = 0f;

                realworldtilemap.color = defaultColor;
                fakeworldtilemap.color = nearlyTransparent;

                realworldbackground.color = defaultColor;
                fakeworldbackground.color = gone;

                fakeworldcolliders.enabled = false;
                realworldcolliders.enabled = true;

                r_world_death_colliders.SetActive(true);
                f_world_death_colliders.SetActive(false);
            }
        }
    }
}

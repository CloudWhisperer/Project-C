using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldSwitcher : MonoBehaviour
{
    private bool isfakeworld;

    public TilemapCollider2D realworldcolliders;
    public TilemapCollider2D fakeworldcolliders;

    public Tilemap realworldtilemap;
    public Tilemap fakeworldtilemap;

    private Color defaultColor = new Color(1f,1f,1f,1);
    private Color nearlyTransparent = new Color(1f,1f,1f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            isfakeworld = !isfakeworld;

            if (isfakeworld == true)
            {
                Debug.Log("on");

                realworldtilemap.color = nearlyTransparent;
                fakeworldtilemap.color = defaultColor;

                fakeworldcolliders.enabled = true;
                realworldcolliders.enabled = false;
            }

            else
            {
                Debug.Log("off");

                realworldtilemap.color = defaultColor;
                fakeworldtilemap.color = nearlyTransparent;

                fakeworldcolliders.enabled = false;
                realworldcolliders.enabled = true;
            }
        }
    }
}

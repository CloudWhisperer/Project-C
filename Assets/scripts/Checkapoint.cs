using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Checkapoint : MonoBehaviour
{
    private gameMaster gm;
    private SpriteRenderer spriterenderer;
    public Sprite torchsprite;
    private Animator torchanim;
    private Light2D torchlight;
    public AudioSource torchsound;
    private bool istouched = false;

    private void Start()
    {
        torchlight = GetComponent<Light2D>();
        torchanim = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player") && istouched == false)
        {
            gm.lastcheckpointpos = transform.position;
            spriterenderer.sprite = torchsprite;
            torchanim.enabled = true;
            torchlight.intensity = 1;
            torchsound.Play();
            istouched = true;
        }
    }
}

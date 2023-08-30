using UnityEngine;
using UnityEngine.Audio;

public class musicmixercontroller : MonoBehaviour
{
    [SerializeField]
    private AudioMixer musicaudiomixer;
    [SerializeField]
    private AudioMixer sfxaudiomixer;

    public void setvolumemusic(float slidervalue)
    {
        musicaudiomixer.SetFloat("Musicmastervolume", Mathf.Log10(slidervalue) * 20);
    }

    public void setvolumesfx(float slidervalue)
    {
        sfxaudiomixer.SetFloat("Sfxmastervolume", Mathf.Log10(slidervalue) * 20);
    }

}

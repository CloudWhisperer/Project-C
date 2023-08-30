using UnityEngine;
using UnityEngine.SceneManagement;

public class dontdestroyonload : MonoBehaviour
{
    public AudioSource m_AudioSource;

    public static dontdestroyonload instance;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.buildIndex == 0)
        {
            Debug.Log("lolasdh asdh asjdhas");
            m_AudioSource.Stop();
        }
    }

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene.buildIndex == 0)
        {
            Debug.Log("lolasdh asdh asjdhas");
            m_AudioSource.Stop();
        }

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            m_AudioSource.Play();
        }
        DontDestroyOnLoad(this.gameObject);
    }

}

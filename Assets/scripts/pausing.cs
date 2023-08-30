using UnityEngine;
using UnityEngine.SceneManagement;

public class pausing : MonoBehaviour
{
    public GameObject pausemenu;
    public Animator transition;
    private playermovement movescript;
    private WorldSwitcher worldscript;

    private void Start()
    {
        movescript = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();
        worldscript = GameObject.FindGameObjectWithTag("Player").GetComponent<WorldSwitcher>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pausegame();
        }
    }

    private void pausegame()
    {
        movescript.enabled = false;
        worldscript.enabled = false;
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void unpause()
    {
        movescript.enabled = true;
        worldscript.enabled = true;
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void returnmainmneu()
    {
        movescript.enabled = true;
        worldscript.enabled = true;
        transition.SetTrigger("start");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}

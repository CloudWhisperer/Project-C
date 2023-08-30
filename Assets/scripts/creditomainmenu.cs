using UnityEngine;
using UnityEngine.SceneManagement;

public class creditomainmenu : MonoBehaviour
{
    public Animator transition;


    void fadeblack()
    {
        transition.SetTrigger("start");
    }

    void mainmenu()
    {
        Debug.Log("main menu now");
        SceneManager.LoadScene(0);
    }
}

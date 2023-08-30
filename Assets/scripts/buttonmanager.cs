using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonmanager : MonoBehaviour
{

    public void Startgame()
    {
        Debug.Log("startin game");
        SceneManager.LoadScene(1);
    }

    public void optionsbuitton()
    {
        Debug.Log("options menu");
    }

    public void exitgame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}

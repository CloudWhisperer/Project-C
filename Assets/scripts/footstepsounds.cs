using UnityEngine;

public class footstepsounds : MonoBehaviour
{
    public AudioSource f1, f2, f3, f4, f5, f6, f7, f8;

    void footstepsoundgenerator()
    {
        int randomnumber = Random.Range(1, 9);
        Debug.Log(randomnumber);

        switch (randomnumber)
        {
            case 1:
                f1.Play();
                break;

            case 2:
                f2.Play();
                break;

            case 3:
                f3.Play();
                break;

            case 4:
                f4.Play();
                break;

            case 5:
                f5.Play();
                break;

            case 6:
                f6.Play();
                break;

            case 7:
                f7.Play();
                break;

            case 8:
                f8.Play();
                break;

            default:
                break;
        }

    }
}
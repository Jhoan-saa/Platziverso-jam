using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void toIntro()
    {
        SceneManager.LoadScene("Intro");
        Invoke("toGame", 10f);
    }

    public void toCredits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public static void toGame()
    {
        Debug.Log("toGame");
        SceneManager.LoadScene("GameScene");
    }

    public static void toMenu()
    {
        SceneManager.LoadScene("PantallaInicio");
    }
}

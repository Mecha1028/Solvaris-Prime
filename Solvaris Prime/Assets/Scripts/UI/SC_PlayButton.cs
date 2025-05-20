using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SC_PlayButton : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("SC_Main");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator InroAnim;
    [SerializeField] GameObject canvas;
    public void Play()
    {
        InroAnim.SetTrigger("In");
        Destroy(canvas);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

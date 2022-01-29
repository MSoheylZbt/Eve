using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator InroAnim;
    [SerializeField] GameObject canvas;
    BG_Manager bG_Manager;
    public void Play()
    {
        InroAnim.SetTrigger("In");

        if(SceneManager.GetActiveScene().name == "GraveScene Final")
        {
            bG_Manager = FindObjectOfType<BG_Manager>();
            bG_Manager.currentIndex = -1;
            bG_Manager.PlayNextMusic();
        }

        Destroy(canvas);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] List<Pinkly> pinklies;
    [SerializeField] List<Sprite> dialogueSprites;

    [SerializeField] SpriteRenderer dialoguBox;
    [SerializeField] float dialogueTimer = 2f;

    
    int currentIndex = 0;

    

    private void Start()
    {
        Initials();
        ShowNextDialogue();
    }

    private void Initials()
    {
        foreach (Pinkly temp in pinklies)
        {
            temp.SetManagerRef(this);
        }
    }

    public void ActiveNextPinkly()
    {
        pinklies[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        pinklies[currentIndex].gameObject.SetActive(true);

        ShowNextDialogue();
    }


    private void ShowNextDialogue()
    {
        dialoguBox.gameObject.SetActive(true);
        dialoguBox.sprite = dialogueSprites[currentIndex];
        StartCoroutine(DialogueTimer());
    }

    private IEnumerator DialogueTimer()
    {
        float elapsedTime = 0f;

        while(elapsedTime <= dialogueTimer)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        dialoguBox.gameObject.SetActive(false);
    }
}

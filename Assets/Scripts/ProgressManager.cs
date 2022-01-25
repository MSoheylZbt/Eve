using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] List<Pinkly> pinklies;
    [SerializeField] List<Sprite> dialogueSprites;
    [SerializeField] List<GameObject> levelPrefabs;
    [SerializeField] EndButton endButton;

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

    public void DoProgress()
    {
        ActiveLevelNextPrefab();
        ActiveNextPinkly();
        ShowNextDialogue();
    }

    private void ActiveNextPinkly()
    {
        pinklies[currentIndex].gameObject.SetActive(false);

        currentIndex++; //Side-effect

        if (currentIndex >= pinklies.Count)
        {
            endButton.gameObject.SetActive(true);
            return;
        }


        pinklies[currentIndex].gameObject.SetActive(true);
    }

    private void ShowNextDialogue()
    {
        if (currentIndex >= dialogueSprites.Count)
            return;

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

    private void ActiveLevelNextPrefab()
    {
        if (currentIndex >= levelPrefabs.Count)
            return;
        levelPrefabs[currentIndex].SetActive(true);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    [Header("Depression Level")]
    [SerializeField] bool isDepressed = false;
    [SerializeField] Transform teleportPos;
    [SerializeField] SpriteRenderer dialogueBox;
    [SerializeField] Sprite dialogueSprite;

    [Header("White Parameters")]
    [SerializeField] GameObject white;
    [SerializeField] float whiteMoveSpeed;
    [SerializeField] Transform whiteNextPos;


    [SerializeField] int nextSceneIndex;
    [SerializeField] GameObject wall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wall.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(MoveWhite());
        }
    }


    private IEnumerator MoveWhite()
    {
        while( (whiteNextPos.transform.position - white.transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            white.transform.position = Vector2.MoveTowards(white.transform.position, whiteNextPos.transform.position, whiteMoveSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        if(isDepressed)
        {
            yield return new WaitForSeconds(2f);
            white.transform.position = new Vector3(teleportPos.position.x,teleportPos.position.y,0);
            dialogueBox.sprite = dialogueSprite;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(nextSceneIndex);
        }

    }
}

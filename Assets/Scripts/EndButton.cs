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
    [SerializeField] float blockFadeTime;
    [SerializeField] Transform whiteNextPos;


    [SerializeField] int nextSceneIndex;
    [SerializeField] GameObject wall;
    private Animator wallAnimator;

    [SerializeField] Animator levelAnimator;
    [SerializeField] Animator nextLevelAnimator;


    private void Start()
    {
        wallAnimator = wall.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Out");
            levelAnimator.SetTrigger("Out");
            if (!isDepressed) nextLevelAnimator.SetTrigger("In");
            StartCoroutine(MoveWhite());
            StartCoroutine(BlockFade());
            
        }
    }

    private IEnumerator BlockFade()
    {
        yield return new WaitForSeconds(blockFadeTime);
        wallAnimator.SetTrigger("FadeOut");
    }

    private IEnumerator MoveWhite()
    {
         
        while( (whiteNextPos.transform.position - white.transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            white.transform.position = Vector2.MoveTowards(white.transform.position, whiteNextPos.transform.position, whiteMoveSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);

        if (isDepressed)
        {
            yield return new WaitForSeconds(2f);
            white.transform.position = new Vector3(teleportPos.position.x,teleportPos.position.y,0);
            dialogueBox.sprite = dialogueSprite;
        }
        else
        {
            
            //SceneManager.LoadScene(nextSceneIndex);
        }

    }
}

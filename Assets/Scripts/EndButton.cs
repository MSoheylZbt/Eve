using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    [SerializeField] int nextSceneIndex;
    [SerializeField] float speed;
    [SerializeField] GameObject wall;
    [SerializeField] Transform whiteNextPos;
    [SerializeField] GameObject white;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wall.SetActive(false);

            StartCoroutine(MoveWhite());
        }
    }


    private IEnumerator MoveWhite()
    {
        while( (whiteNextPos.transform.position - white.transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            white.transform.position = Vector2.MoveTowards(white.transform.position, whiteNextPos.transform.position, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(nextSceneIndex);
    }
}

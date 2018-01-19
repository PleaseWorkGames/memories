using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerController>().setDialogue("Oh yeah!  Now I remember");
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(doFade());
        }
    }

    IEnumerator doFade()
    {
        var canvasGroup = GameObject.FindGameObjectWithTag("Fader").GetComponent<CanvasGroup>();
        
        while (canvasGroup.alpha < 1) {
            var increment = Time.deltaTime / 2;
            canvasGroup.alpha += increment;
            yield return null;
        }

        canvasGroup.interactable = false;
        yield return null;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmTrigger : MonoBehaviour
{
    public float fadeOutSec;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Warm"))
        {
            StartCoroutine(DeactiveAction(collision.gameObject));
        }
    }

    IEnumerator DeactiveAction(GameObject gameObject)
    {
        yield return new WaitForSeconds(fadeOutSec);

        Destroy(gameObject);
    }
}

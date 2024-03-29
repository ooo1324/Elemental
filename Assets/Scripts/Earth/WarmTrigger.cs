using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmTrigger : MonoBehaviour
{
    public float fadeOutSec;
    public int goodScore;
    public int badScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Warm"))
        {     
            //점수제어
            GameManager.instance.PlusScore(GamePanelManager.EElementalType.earth, gameObject.transform.position);
            EarthSoundManager.instance.PlayCorrectSound();
            StartCoroutine(DeactiveAction(collision.gameObject));
        }
        else if (collision.gameObject.CompareTag("Mole"))
        {
            //점수 제어
            GameManager.instance.MinusSocre(GamePanelManager.EElementalType.earth, gameObject.transform.position);
            EarthSoundManager.instance.PlayIncorrectSound();
            StartCoroutine(DeactiveAction(collision.gameObject));
        }
    }

    IEnumerator DeactiveAction(GameObject gameObject)
    {
        yield return new WaitForSeconds(fadeOutSec);

        Destroy(gameObject);
    }
}

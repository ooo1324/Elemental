using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public Text scoreText;
    public Image image;
    public float moveSpeed;
    private Vector3 movePos;

    private void OnEnable()
    {
        movePos = gameObject.transform.position + Vector3.up * 50;
        scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, 1);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        StartCoroutine(Action());
    }

    private void OnDisable()
    {
        StopCoroutine(Action());
    }


    IEnumerator Action()
    {
        while (transform.position != movePos)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, movePos, moveSpeed * Time.deltaTime);
            scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, scoreText.color.a - 0.02f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.02f);
            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
    }
}
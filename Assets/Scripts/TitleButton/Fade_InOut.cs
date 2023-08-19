using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade_InOut : MonoBehaviour
{
    public Image fadeImg; // fade�� �� �̹���
    public float fadeTime; //ȭ���� ���� �ð�

    IEnumerator FadeIn()
    {
        Color tempColor = fadeImg.color;
        tempColor.a = 0f;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeTime;
            fadeImg.color = tempColor;

            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
                SceneManager.LoadScene("MainScene");
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
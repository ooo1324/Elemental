using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage : MonoBehaviour
{
    public Image[] Bars;
    public float[] Value;
    public float[] Reduce;

    private void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            Bars[i].fillAmount = Value[i]/100;
        }

        StartCoroutine(Bar_Manager());
    }

    IEnumerator Bar_Manager()
    {
        while(true)
        {
            for (int i = 0; i < 4; i++)
            {
                Value[i] -= Reduce[i] * 0.1f;
                Bars[i].fillAmount = Value[i]/100;

                if (Bars[i].fillAmount <= 0)
                {
                    Value[i] = 0;
                  //  Debug.Log("Game Over");
                }
                else if (Bars[i].fillAmount >= 1)
                {
                    Value[i] = 100;
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Timer_Slider : MonoBehaviour
{
    private float cooltime = 0.0f;       //���� ���� �ð�

    private float cooltime_max = 300.0f;	//��Ÿ��

    public Image disable;	//���� �ð��� ǥ���� �̹���

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoolTimeFunc());
    }

    IEnumerator CoolTimeFunc()
    {
        while (cooltime < cooltime_max)
        {
            cooltime += Time.deltaTime;

            //��Ÿ�� �̹���
            disable.fillAmount = cooltime / cooltime_max;


            yield return new WaitForFixedUpdate();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Timer_Slider : MonoBehaviour
{
    private float cooltime = 0.0f;       //���� ���� �ð�

    public float time_max_sec = 300.0f;	//��Ÿ��

    public Image disable;	//���� �ð��� ǥ���� �̹���

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoolTimeFunc());
    }

    IEnumerator CoolTimeFunc()
    {
        while (cooltime < time_max_sec)
        {
            cooltime += Time.deltaTime;

            Management.Instance.level = 1 + (int)((float)cooltime / 60.0);

            //��Ÿ�� �̹���
            disable.fillAmount = cooltime / time_max_sec;


            yield return new WaitForFixedUpdate();
        }
    }
}

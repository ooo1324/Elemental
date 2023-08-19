using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Timer_Slider : MonoBehaviour
{
    private float cooltime = 0.0f;       //현재 남은 시간

    private float cooltime_max = 300.0f;	//쿨타임

    public Image disable;	//남은 시간을 표시할 이미지

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

            //쿨타임 이미지
            disable.fillAmount = cooltime / cooltime_max;


            yield return new WaitForFixedUpdate();
        }
    }
}

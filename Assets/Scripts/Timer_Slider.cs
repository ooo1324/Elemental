using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Timer_Slider : MonoBehaviour
{
    private float cooltime = 0.0f;       //현재 남은 시간

    public float time_max_sec = 300.0f;	//쿨타임

    public Image disable;	//남은 시간을 표시할 이미지

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

            //쿨타임 이미지
            disable.fillAmount = cooltime / time_max_sec;


            yield return new WaitForFixedUpdate();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeManager : MonoBehaviour
{
    [SerializeField]
    public List<ElementData> elementDataList;

    public float delaySec;

    public GameObject warning;


    private void Start()
    {
        for (int i = 0; i < elementDataList.Count; i++)
        {
            ElementData curdata = elementDataList[i];

            curdata.barImg.fillAmount = curdata.value / 100;
        }

        StartCoroutine(GaugeManage());
    }

    IEnumerator GaugeManage()
    {
        while (true)
        {
            bool isCheckWarning = false;
            //if (!Management.Instance.isStartGame) break;
            for (int i = 0; i < elementDataList.Count; i++)
            { 
                ElementData curdata = elementDataList[i];

                curdata.value -= curdata.reduce * 0.1f;

                curdata.barImg.fillAmount = curdata.value / 100;

                if (curdata.barImg.fillAmount <= 0)
                {
                    curdata.value = 0;
                    warning.SetActive(false);

                    GameManager.instance.GameOver();

                    StopAllCoroutines();
                    yield return null;
                }
                else if (curdata.barImg.fillAmount <= 0.2)
                {
                    isCheckWarning = true;
                }
                else if (curdata.barImg.fillAmount >= 1)
                {
                    curdata.value = 100;
                }
            }
 
            if (isCheckWarning)
            {
                if (!warning.activeSelf)
                    warning.SetActive(true);         
            }
            else
            {
                if (warning.activeSelf)
                    warning.SetActive(false);
            }
            yield return new WaitForSeconds(delaySec);
        }  
    }

}

[Serializable]
public class ElementData
{

    public Image barImg;

    public float value;

    public float reduce;
}



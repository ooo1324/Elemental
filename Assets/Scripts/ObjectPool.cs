using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> objectList;

    [HideInInspector]
    public GameObject prefab;

    private void Awake()
    {
        objectList = new List<GameObject>();
    }

    public GameObject GetObject()
    {
        GameObject select = null;
        for (int i = 0; i < objectList.Count; i++)
        {
            if (!objectList[i].activeSelf)
            {
                select = objectList[i];
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(prefab, gameObject.transform);
            objectList.Add(select);
        }

        return select;
    }

    public void AllPoolItemDeactive()
    {
        if (objectList == null) return;
   
        for (int i = 0; i < objectList.Count; i++)
        {
            if (!objectList[i].activeSelf)
            {
                objectList[i].SetActive(false);
            }
        }
    }
}

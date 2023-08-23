using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> objectList;

    public GameObject prefab;

    public Transform parent;

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
                objectList[i].SetActive(true);
                select = objectList[i];
            }
        }

        if (select == null)
        {
            select = Instantiate(prefab, parent);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> XtransList;

    public List<Transform> YtransList;
    public Transform parent;

    public GameObject xWarmPrefab;
    public GameObject yWarmPrefab;
    public GameObject xmolePrefab;
    public GameObject ymolePrefab;

    [Range(0, 1)]
    public float wramSpawnRatio;

    public float delayRate;

    private void OnEnable()
    {
        StartCoroutine(spawn());
    }
    private void OnDisable()
    {
        StopCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            int ranPosIdx = Random.Range(0, XtransList.Count);
            float ranRatio = Random.Range(0f, 1f);
            GameObject obj;

            if (ranRatio <= wramSpawnRatio)
            {
                //Warm Spawn
                if (ranRatio <= wramSpawnRatio / 2)
                {
                    obj = Instantiate(xWarmPrefab, parent);
                    obj.transform.position = XtransList[ranPosIdx].position;
                }
                else
                {
                    obj = Instantiate(yWarmPrefab, parent);
                    obj.transform.position = YtransList[ranPosIdx].position;
                }
            }
            else
            {
                //Mole Spawn
                if (ranRatio - wramSpawnRatio <= (1 - wramSpawnRatio) / 2)
                {
                    obj = Instantiate(xmolePrefab, parent);
                    obj.transform.position = XtransList[ranPosIdx].position;
                }
                else
                {
                    obj = Instantiate(ymolePrefab, parent);
                    obj.transform.position = YtransList[ranPosIdx].position;
                }
            }

            yield return new WaitForSeconds(delayRate);
        } 
    }
}

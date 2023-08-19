using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> transList;

    public List<GameObject> prefabs;

    public float delayRate;

    private void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            int ranPosIdx = Random.Range(0, transList.Count);
            int ranPrefabIdx = Random.Range(0, prefabs.Count);


            yield return new WaitForSeconds(delayRate);
        } 
    }
}

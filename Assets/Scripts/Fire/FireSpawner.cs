using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public float spawnSec;

    public List<GameObject> fireList;

    private int currCount;

    private void Start()
    {
        StartCoroutine(FireSpawn());
    }

    IEnumerator FireSpawn()
    {
        while (true)
        {
            while (true)
            {
                if (currCount >= fireList.Count)
                    break;

                int ranIdx = RandomRange();

                if (!fireList[ranIdx].activeSelf)
                {
                    fireList[ranIdx].SetActive(true);
                    currCount++;
                    break;
                }

                yield return new WaitForSeconds(0.01f);
               // Debug.Log($"ranidx : {ranIdx}");
            }

          //  Debug.Log($"fire ���� : {currCount}");
            yield return new WaitForSeconds(spawnSec);
        }
        // fireSpawn
    
    }

    public void decreaseFireCount()
    {
        currCount--;
    }

    int RandomRange()
    {
        return Random.Range(0, fireList.Count);
    }
}

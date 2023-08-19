using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawn : MonoBehaviour
{
    public GameObject[] Cars;
    public float SpawnTime;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            int Car_Num = Random.Range(0, 4);

            Cars[Car_Num].SetActive(true);
            Cars[Car_Num].GetComponent<Car_Move>().Broke = Random.Range(0, 2);

            yield return new WaitForSeconds(SpawnTime);
        }
    }
}

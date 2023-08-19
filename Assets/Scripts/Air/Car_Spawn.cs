using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawn : MonoBehaviour
{
    public GameObject[] Cars;
    public int Spawn_Time;

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

            if (Random.Range(0, 2) == 0)
                Cars[Car_Num].GetComponent<Car_Move>().Broke = true;
            else
                Cars[Car_Num].GetComponent<Car_Move>().Broke = false;

            yield return new WaitForSeconds(Spawn_Time);
        }
    }
}

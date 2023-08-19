using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawn : MonoBehaviour
{
    public GameObject Prefab_Car;
    public float Spawn_Time;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            int Car_Num = Random.Range(0, 4);

            GameObject Car = Instantiate(Prefab_Car, Vector2.zero, Quaternion.identity);
            Car.transform.parent = this.transform;
            Car.transform.localPosition = new Vector2(-4.3f + 2.8f * Car_Num, 6.5f);

            Car.GetComponent<Car_Move>().Broke = Random.Range(0, 2);

            yield return new WaitForSeconds(Spawn_Time);
        }
    }
}

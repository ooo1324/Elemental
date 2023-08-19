using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawn : MonoBehaviour
{
    List<int> CarList = new List<int>();

    public Transform parentObj;
    public Sprite[] SP;
    public Vector2[] Spawn_direction;

    public GameObject Prefab_Car;
    public float Spawn_Time;
    public bool Break;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int Car_Num = Random.Range(0, 4);
            CreateUnDuplicateRandom(0, 4, Car_Num);

            List<GameObject>Car = new List<GameObject>();

            for (int i = 0; i < Car_Num; i++)
            {
                Car.Add(Instantiate(Prefab_Car, parentObj));
                Car[i].transform.localPosition = Spawn_direction[i];
                Car[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = SP[Random.Range(0, SP.Length)];
                Car[i].GetComponent<Car_Move>().Speed = Random.Range(3, 9);

                if (!Break)
                {
                    int Broke = Random.Range(0, 2);
                    Car[i].GetComponent<Car_Move>().Broke = Broke;

                    if (Broke == 1)
                        Break = true;

                    if(i == Car_Num - 1 && !Break)
                    {
                        if(Random.Range(0, 100) < 40)
                            Car[Random.Range(0, Car_Num)].GetComponent<Car_Move>().Broke = 1;
                    }
                }
            }

            Break = false;
            CarList.RemoveRange(0, CarList.Count);

            yield return new WaitForSeconds(Spawn_Time * Management.Instance.level);
        }
    }

    void CreateUnDuplicateRandom(int min, int max, int count)
    {
        int currentNumber = Random.Range(min, max);

        for (int i = 0; i < count;)
        {
            if (CarList.Contains(currentNumber))
            {
                currentNumber = Random.Range(min, max);
            }
            else
            {
                CarList.Add(currentNumber);
                i++;
            }
        }
    }
}

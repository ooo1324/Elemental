using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    public int rotateAngle;

    public CarObjPoolManager poolManager;

    private void Awake()
    {
       
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnCar());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(poolManager.spawnRate);
            GameObject carObj =  poolManager.carObjPool.GetObject();
            carObj.transform.position = gameObject.transform.position;
            carObj.transform.localEulerAngles = new Vector3(0, 0, rotateAngle);
            Car car = carObj.GetComponent<Car>();
            car.isExhaust = Random.Range(0f, 1f) <= poolManager.carExhaustRatio;
            car.moveSpeed = Random.Range(poolManager.speedMin, poolManager.speedMax);
            car.carRenderer.sprite = poolManager.carSprites[Random.Range(0, poolManager.carSprites.Length)];         
        }
        // 만약 차가 정체되어 쌓여있는 차가 있다면 기다렸다가 ~ 생성
    }
}

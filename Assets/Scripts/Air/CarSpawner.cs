using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    public int rotateAngle;

    public CarObjPoolManager poolManager;

    [SerializeField]
    public string layerName;

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
            yield return new WaitForSeconds(Random.Range(poolManager.spawnRate - 0.3f, poolManager.spawnRate));
            
            GameObject carObj =  poolManager.carObjPool.GetObject();
            carObj.transform.position = gameObject.transform.position;
            carObj.transform.localEulerAngles = new Vector3(0, 0, rotateAngle);
            carObj.layer = LayerMask.NameToLayer(layerName);

            Car car = carObj.GetComponent<Car>();
            car.isExhaust = Random.Range(0f, 1f) <= poolManager.carExhaustRatio;
            car.moveSpeed = Random.Range(poolManager.speedMin, poolManager.speedMax);
            car.carRenderer.sprite = poolManager.carSprites[Random.Range(0, poolManager.carSprites.Length)];
            carObj.SetActive(true);
            //yield return new WaitForSeconds(Random.Range(poolManager.spawnRate - 1, poolManager.spawnRate)); 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public List<GameObject> bombList;


    private void Start()
    {
        
    }

    public void BombSpawn(int idx)
    {
        //���� ����
        FireManager.instance.currBomb = Instantiate(bombList[idx], gameObject.transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public List<GameObject> bombList;

    public void BombSpawn(int idx)
    {
        //추후 수정
        FireManager.instance.currBomb = Instantiate(bombList[idx], gameObject.transform);
    }
}

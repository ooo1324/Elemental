using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int score;

    public FireSpawner spawner;

    private void OnMouseDown()
    {
        if (FireManager.instance.currBombType == FireManager.EBombType.water)
        {
            FireManager.instance.AddScore(score);
            spawner.decreaseFireCount();
            gameObject.SetActive(false);
        }
        else if (FireManager.instance.currBombType == FireManager.EBombType.oil)
        {
            FireManager.instance.AddScore(-score);
            //spawner.decreaseFireCount();
            //gameObject.SetActive(false);
        }
    }
}

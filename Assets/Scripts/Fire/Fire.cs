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
            GameManager.instance.PlusScore(GamePanelManager.EElementalType.fire);
            FireManager.instance.AddScore(score);
            spawner.decreaseFireCount();
            gameObject.SetActive(false);
        }
        else if (FireManager.instance.currBombType == FireManager.EBombType.oil)
        {
            GameManager.instance.MinusSocre(GamePanelManager.EElementalType.fire);
        }
    }
}

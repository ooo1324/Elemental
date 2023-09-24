using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fire : MonoBehaviour
{
    public int score;

    public FireSpawner spawner;

    private void OnMouseDown()
    {
        if (Management.Instance.Stop) return;
        if (FireManager.instance.currBombType == FireManager.EBombType.water)
        {
            GameObject obj = FireManager.instance.pool.GetObject();
            obj.transform.position = gameObject.transform.position;
            obj.SetActive(true);

            GameManager.instance.PlusScore(GamePanelManager.EElementalType.fire, gameObject.transform.position);
            FireManager.instance.AddScore(score);
            spawner.decreaseFireCount();
            gameObject.SetActive(false);
        }
        else if (FireManager.instance.currBombType == FireManager.EBombType.oil)
        {
            GameManager.instance.MinusSocre(GamePanelManager.EElementalType.fire, gameObject.transform.position);
            FireManager.instance.MinusScore();
        }
    }
}

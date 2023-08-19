using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move : MonoBehaviour
{
    public int Speed;
    public int Broke;

    public SpriteRenderer Sp;
    public GameObject Gas;

    void Start()
    {
        Gas.SetActive(true);

        if (Broke == 0)
        {
            Gas.transform.localPosition = new Vector3(0, 0.7f, 0);
            Gas.transform.localScale = new Vector3(0.25f, 0.25f, 0);
        }
        else
        {
            Gas.transform.localPosition = new Vector3(0, 0.9f, 0);
            Gas.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        }
    }

    void Update()
    {
        if (transform.position.y > -6.45f)
            transform.Translate(new Vector3(0, -Speed * Time.deltaTime * Management.Instance.level, 0));
        else
        {
            if (Broke == 1)
                GameManager.instance.MinusSocre(GamePanelManager.EElementalType.air);

            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (Broke == 0)
        {
            Sp.color = Color.red;

            Gas.transform.localPosition = new Vector3(0, 0.9f, 0);
            Gas.transform.localScale = new Vector3(0.5f, 0.5f, 0);

            GameManager.instance.MinusSocre(GamePanelManager.EElementalType.air);

            Broke = 1;
        }
        else
        {
            GameManager.instance.PlusScore(GamePanelManager.EElementalType.air);

            Gas.transform.localPosition = new Vector3(0, 0.7f, 0);
            Gas.transform.localScale = new Vector3(0.25f, 0.25f, 0);

            Broke = 0;
        }

        GetComponent<BoxCollider2D>().enabled = false;
    }
}

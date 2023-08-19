using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move : MonoBehaviour
{
    public int Speed;
    public int Broke;
    public int fire;

    public GameObject[] Gas;
    public Gage gage;

    void Start()
    {
        gage = GameObject.FindObjectOfType<Gage>();

        if (Broke == 0)
            fire = 1;
        else 
            fire = 2;
    }

    void Update()
    {
        for (int i = 0; i < 6 * fire; i++)
        {
            Gas[i].transform.Translate(new Vector3(0, 0.01f, 0));
            Gas[i].SetActive(true);
        }

        if (transform.position.y > -6)
            transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
        else
            Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (Broke == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            gage.Value[3] -= 15;
        }
        else
        {
            gage.Value[3] += 10;
        }

        GetComponent<BoxCollider2D>().enabled = false;
    }
}

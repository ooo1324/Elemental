using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move : MonoBehaviour
{
    public int Speed;
    public int Broke;

    public SpriteRenderer Sp;
    public GameObject Gas;
    //public Gage gage;

    void Start()
    {
       // gage = GameObject.FindObjectOfType<Gage>();
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
            if(Broke == 1)
               //gage.Value[3] -= 10;

            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (!Management.Instance.Stop)
        {
            if (Broke == 0)
            {
                Sp.color = Color.red;

                Gas.transform.localPosition = new Vector3(0, 0.9f, 0);
                Gas.transform.localScale = new Vector3(0.5f, 0.5f, 0);

                //gage.Value[3] -= 15;

                Broke = 1;
            }
            else
            {
                //gage.Value[3] += 10;

                Gas.transform.localPosition = new Vector3(0, 0.7f, 0);
                Gas.transform.localScale = new Vector3(0.25f, 0.25f, 0);

                Broke = 0;
            }

            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

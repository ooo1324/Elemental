using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move : MonoBehaviour
{
    public int Speed;
    public int Broke;

    void Update()
    {
        if (transform.position.y > -6.4f)
            transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
        else
        {
            transform.position = new Vector3(transform.position.x, 6.4f);
            gameObject.SetActive(false);
            Broke = 0;
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnMouseDown()
    {
        if (Broke == 0)
            Debug.Log("정답");
        else
            Debug.Log("오답");

        GetComponent<BoxCollider2D>().enabled = false;
    }
}

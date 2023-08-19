using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move : MonoBehaviour
{
    public int Speed;
    public bool Broke;

    void Update()
    {
        if (transform.position.y >= -4.45f)
            transform.Translate(0, -Speed*Time.deltaTime, 0);
        else
        {
            this.transform.position = new Vector2(this.transform.position.x, 4.45f);
            this.gameObject.SetActive(false);
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnMouseDown()
    {
        if (Broke)
            Debug.Log("정답");
        else
            Debug.Log("오답");

        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}

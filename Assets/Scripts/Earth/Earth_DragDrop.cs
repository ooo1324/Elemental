using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_DragDrop : MonoBehaviour
{
    private bool isDrag = false;
    private SpriteRenderer renderer;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (!Management.Instance.Stop)
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0.3f);
    }

    private void OnMouseDrag()
    {
        if (!Management.Instance.Stop)
        {
            if (!isDrag)
                isDrag = true;

            Vector3 objPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            transform.position = new Vector3(objPosition.x, objPosition.y, 0);
        }
    }

    private void OnMouseUp()
    {
        if (!Management.Instance.Stop)
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);
            if (isDrag)
            {

                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDrag = false;

    private void OnMouseDown()
    {
        Debug.Log("Mouse down");
    }
    private void OnMouseDrag()
    {
        if (!isDrag) 
            isDrag = true;

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        transform.position = new Vector3(objPosition.x, objPosition.y, 0);
    }

    private void OnMouseUp()
    {
        if (isDrag)
        {
            FireManager.instance.CheckBomb();
            Destroy(gameObject);
        }      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;

    public bool isExhaust 
    {
        get { return isExhaust; }
        set { isExhaust = value; } 
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * 
            Management.Instance.level);
    }

    private void OnMouseDown()
    {
        if (!Management.Instance.Stop)
        {
            
        }
    }
}

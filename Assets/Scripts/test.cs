using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Management.Instance.level = 1;
        if (Input.GetKeyDown(KeyCode.S))
            Management.Instance.level = 1.5f;
        if (Input.GetKeyDown(KeyCode.D))
            Management.Instance.level = 2;

        if (Input.GetKeyDown(KeyCode.Q))    // ∏ÿ√„
        {
            Management.Instance.Stop = true;
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))    // Ω√¿€
        {
            Management.Instance.Stop = false;
            Time.timeScale = 1;
        }
    }
}

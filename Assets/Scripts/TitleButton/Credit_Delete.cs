using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Credit_Delete : MonoBehaviour, IPointerDownHandler
{
    public GameObject gameObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
        // ²ô±â 
        gameObj.SetActive(false);
    }
}

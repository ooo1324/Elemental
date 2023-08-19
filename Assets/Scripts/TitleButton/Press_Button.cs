using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Press_Button : MonoBehaviour,
    IPointerDownHandler ,IPointerUpHandler
{
    // Start is called before the first frame update
    Image img_Renderer;
    public Sprite sprite01;
    public Sprite sprite02;


    public GameObject gameObj;

    void Start()
    {
        img_Renderer = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
 
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
        img_Renderer.sprite = sprite01; //눌린이미지 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Exit");
        img_Renderer.sprite = sprite02; // 올라온이미지 

        gameObj.SetActive(true);
    }


}

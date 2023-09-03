using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject textPrefab;

    public Sprite[] elementImgs;


    public void FloatingText(GamePanelManager.EElementalType type, Vector3 pos, int score)
    {
        GameObject textObj = Instantiate(textPrefab, gameObject.transform);
        textObj.transform.position = Camera.main.WorldToScreenPoint(pos) + Vector3.up * 50;
        FloatingText flotText = textObj.GetComponent<FloatingText>();
        flotText.scoreText.text = score.ToString();
        flotText.image.sprite = elementImgs[(int)type];
        flotText.scoreText.color = score >= 0 ? Color.white : Color.red;
        textObj.SetActive(true);
    }
}

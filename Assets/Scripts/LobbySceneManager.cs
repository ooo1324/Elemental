using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeInPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartBtClick()
    {
        StartCoroutine(FadeInAction());
    }

    IEnumerator FadeInAction()
    {
        fadeInPanel.SetActive(true);
        yield return new WaitForSeconds(1.4f);

        SceneManager.LoadScene("MainScene");
    }
}

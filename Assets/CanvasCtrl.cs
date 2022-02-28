using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCtrl : MonoBehaviour
{
	private RectTransform rectTransform;
	private GameObject clearTxt;
	private GameObject gameOverTxt;
	private Text clearComponent;
	private Text gameOverComponent;
    // Start is called before the first frame update
    void Start()
    {
        clearTxt = GameObject.Find("Clear");
        clearComponent = clearTxt.GetComponent<Text>();
        gameOverTxt = GameObject.Find("GameOver");
        gameOverComponent = gameOverTxt.GetComponent<Text>();
        clearComponent.enabled = false;
        gameOverComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

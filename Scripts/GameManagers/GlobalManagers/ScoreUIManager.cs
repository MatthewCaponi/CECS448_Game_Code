using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    public static ScoreUIManager instance = null;
    private GameObject scoreCanvas;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI comboText;
    private float score;
    private float scoreMultiplier;
    private float combo;
    private float prevScoreMultiplier = 1;


    
    
    GameObject missTemplate;
    GameObject okayTemplate;
    GameObject goodTemplate;
    GameObject perfectTemplate;
    [SerializeField] float textOffset = .2f;
    private TextMeshProUGUI missText;
    private bool pulsing;
    private Color currentColor;
    private Vector3 currentPos;

    public float ScoreMultiplier { get => scoreMultiplier; set => scoreMultiplier = value; }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreCanvas = GameObject.Find("ScoreCanvas");
        missTemplate = (GameObject)Instantiate(Resources.Load("MISS"), scoreCanvas.transform, true);
        missTemplate.transform.localScale = new Vector3(.02f, .02f, .02f);
        missTemplate.GetComponent<ScoreItem>().enabled = false;

        okayTemplate = (GameObject)Instantiate(Resources.Load("OKAY"), scoreCanvas.transform, true);
        okayTemplate.transform.localScale = new Vector3(.02f, .02f, .02f);
        okayTemplate.GetComponent<ScoreItem>().enabled = false;

        goodTemplate = (GameObject)Instantiate(Resources.Load("GOOD"), scoreCanvas.transform, true);
        goodTemplate.transform.localScale = new Vector3(.02f, .02f, .02f);
        goodTemplate.GetComponent<ScoreItem>().enabled = false;

        perfectTemplate = (GameObject)Instantiate(Resources.Load("Perfect"), scoreCanvas.transform, true);
        perfectTemplate.transform.localScale = new Vector3(.02f, .02f, .02f);
        perfectTemplate.GetComponent<ScoreItem>().enabled = false;

        score = 0;
        ScoreMultiplier = 1.0f;
        comboText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void UpdateCombo()
    {
        if (combo < 5)
            ScoreMultiplier = 1.0f;
        else if (combo >= 4 && combo < 8)
            ScoreMultiplier = 2;
        else if (combo >= 8 && combo < 16)
            ScoreMultiplier = 4;
        else if (combo >= 16 && combo < 32)
            ScoreMultiplier = 8;
        else if (combo >= 32 && combo < 64)
            ScoreMultiplier = 16;
        else if (combo >= 64 && combo < 128)
            ScoreMultiplier = 32;
        else if (combo >= 128 && combo < 256)
            ScoreMultiplier = 64;
        else if (combo >= 256 && combo < 512)
            ScoreMultiplier = 128;

    }

    private void UpdateComboText()
    {
        UpdateCombo();
        
        if (combo >= 1)
            comboText.text = "X" + ScoreMultiplier;
        else if (combo <= 0)
            comboText.text = "";

        if (prevScoreMultiplier != ScoreMultiplier)
        {
            PulseCombo();
            prevScoreMultiplier = ScoreMultiplier;
        }

    }

    public void ScoreHit(int scoreType, Vector2 position)
    {
        if (scoreType == 1)
        {

            GameObject miss = Instantiate(missTemplate, scoreCanvas.transform, true);
            miss.transform.position = position + new Vector2(.5f, .5f);
            miss.transform.localScale = new Vector3(.02f, .02f, .02f);
            miss.GetComponentInParent<Canvas>().sortingOrder = 15;
            miss.GetComponent<ScoreItem>().enabled = true;
            miss.GetComponent<ScoreItem>().TimeDestruction();
            score += 0;
            combo = 0;
            scoreText.text = "Score: " + (score * ScoreMultiplier);
            UpdateComboText();
        }
        else if (scoreType == 2)
        {
            GameObject okay = Instantiate(okayTemplate, scoreCanvas.transform, true);
            okay.transform.position = position + new Vector2(.5f, .5f);
            okay.transform.localScale = new Vector3(.02f, .02f, .02f);
            okay.GetComponentInParent<Canvas>().sortingOrder = 15;
            okay.GetComponent<ScoreItem>().enabled = true;
            okay.GetComponent<ScoreItem>().TimeDestruction();
            score += (float)(10 * ScoreMultiplier);
            combo++;
            scoreText.text = "Score: " + score;
            UpdateComboText();
        }
        else if (scoreType == 3)
        {
            GameObject good = Instantiate(goodTemplate, scoreCanvas.transform, true);
            good.transform.position = position + new Vector2(.5f, .5f);
            good.transform.localScale = new Vector3(.02f, .02f, .02f);
            good.GetComponentInParent<Canvas>().sortingOrder = 15;
            good.GetComponent<ScoreItem>().enabled = true;
            good.GetComponent<ScoreItem>().TimeDestruction();
            score += (float)(20 * ScoreMultiplier);
            combo++;
            scoreText.text = "Score: " + score ;
            UpdateComboText();

        }
        else if (scoreType == 4)
        {
            GameObject perfect = Instantiate(perfectTemplate, scoreCanvas.transform, true);
            perfect.transform.position = position + new Vector2(.5f, .5f);
            perfect.transform.localScale = new Vector3(.02f, .02f, .02f);
            perfect.GetComponentInParent<Canvas>().sortingOrder = 15;
            perfect.GetComponent<ScoreItem>().enabled = true;
            perfect.GetComponent<ScoreItem>().TimeDestruction();
            score += (float)(30 * ScoreMultiplier);
            combo++;
            scoreText.text = "Score: " + score;
            UpdateComboText();
        }
        //Debug.Log(score);
    }

    private void PulseCombo()
    {
        if (!pulsing)
        {
            pulsing = true;
            comboText.transform.localScale *= 2;
            currentColor = comboText.color;
            comboText.color = Color.yellow;
            currentPos = comboText.rectTransform.localPosition;
            comboText.rectTransform.localPosition = new Vector3(comboText.rectTransform.localPosition.x, comboText.rectTransform.localPosition.y + 10, 0);
            Invoke("StopPulsing", .2f);
        }
        
    }

    private void StopPulsing()
    {
        comboText.transform.localScale /= 2;
        comboText.color = currentColor;
        comboText.rectTransform.localPosition = currentPos;
        pulsing = false;
    }

   
}

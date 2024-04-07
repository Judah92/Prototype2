using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Presets;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;
using System;
using System.Linq;//needed this (Language Integrated Query) to call .Any


public class Tile : MonoBehaviour
{
    public Sprite originalSprite;
    public Text textComponent;
    public bool IsCorrectAnswer = false;//bool for checking tile answer
    public ManageCards manageCards; //allows me to access the ManageCards function through the gameManager object

    

    void Start()
    {
        manageCards = FindObjectOfType<ManageCards>();
        if (manageCards == null)
        {
            Debug.LogError("ManageCards instance not found.");
        }

        Canvas childCanvas = GetComponentInChildren<Canvas>();
        if (childCanvas != null)
        {
            textComponent = childCanvas.GetComponentInChildren<Text>();
        }

    }

    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        string trimmedText = textComponent.text.Trim();
        bool isCorrect = LevelManager.Instance.correctAnswers.Any(answer => string.Equals(answer, trimmedText, StringComparison.OrdinalIgnoreCase));
        //Checking if clicked text is the correct answer

        if (isCorrect)
        {
            //Debug.Log("Correct");//Testing Console answer clicks
            manageCards.ShowCorrectAnswerPopup(); // Show the "correct" popup
        }
        else
        {
            //Debug.Log("Wrong");//Testing Console answer clicks
            manageCards.ShowWrongAnswerPopup(); // Show the "wrong" popup
        }

    }

    public void SetOriginalSprite(Sprite newSprite) 
    { 
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void SetText(string text)//setting text component on tile
    {
        if (textComponent != null)
        {
            textComponent.text = text;
        }
    }
}

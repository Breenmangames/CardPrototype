using UnityEngine;
using System.Collections;   
using System.Collections.Generic;
using eoghanBreenGames;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card cardData;
    // Reference to the Card ScriptableObject

    public Image cardImage; // UI Image component to display the card art   
    public TMP_Text nameText; // UI Text component to display the card name
    public TMP_Text healthText; // UI Text component to display the card health
    public TMP_Text damageText; // UI Text component to display the card attack
    public Image[] typeImages; // UI Image components to display the card type

    private Color[] cardColors =
    {
        Color.red, //red
        Color.blue, //blue
        Color.green, //green 
        Color.yellow, //white
        
    };

    private Color[] typeColors =
   {
        Color.red, //red
        Color.blue, //blue
        Color.green, //green 
        Color.yellow, //white
        
    };

    void Start()
    {
      updateCardDisplay();
    }
    public void updateCardDisplay()
    {
        cardImage.color = cardColors[(int)cardData.cardType];
        if (cardData != null)
        {
            nameText.text = cardData.cardName;
            healthText.text = cardData.health.ToString();
            damageText.text = cardData.attack.ToString();
            // Update type images based on card type
            for (int i = 0; i < typeImages.Length; i++)
            {
                if (i < (int)cardData.cardType)
                {
                    typeImages[i].enabled = true; // Enable image for each type
                    typeImages[i].color = cardColors[i]; // Set color based on type
                    typeImages[i].gameObject.SetActive(true);
                }
               
              
            }
        }
    }

}

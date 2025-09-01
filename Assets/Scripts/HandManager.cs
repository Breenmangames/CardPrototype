using UnityEngine;
using System.Collections;   
using System.Collections.Generic;   
using eoghanBreenGames; 

public class HandManager : MonoBehaviour
{
    public DeckManager deckManager; // Reference to the DeckManager
    public GameObject cardPrefab;
    public Transform handTransform;
    public float fanspread = 0.52f;
    public List<GameObject> cardsInHand = new List<GameObject>();  // List to hold card GameObjects in hand
    public float cardSpacing = 127f; // Spacing between cards
    public float VerticalSpacing = -10.6f; // Vertical spacing for fanned effect
    void Start()
    {
     

    }

    public void addCardToHand(Card cardData)
    {
        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity,handTransform);
        cardsInHand.Add(newCard);

        // set card data here   
        newCard.GetComponent<CardDisplay>().cardData = cardData;
        UpdateHandVisuals();
    }

    void Update()
    {
        UpdateHandVisuals();
    }
    private void UpdateHandVisuals()
    {
        int cardCount = cardsInHand.Count;

        if (cardCount == 1)
        {
            cardsInHand[0].transform.localPosition = new Vector3(0f, 0f, 0f);
            cardsInHand[0].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            return; // No need to fan out a single card
        }
        float angleStep = fanspread / Mathf.Max(cardCount - 1, 1); // Calculate angle step based on number of cards
        float startAngle = -fanspread / 2; // Start angle to center the fan
        for (int i = 0; i < cardCount; i++)
        {
            float rotationAngle = (fanspread * i - (cardCount + 1) / 2f); // Calculate rotation angle for each card
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0, 0, rotationAngle);

            float normalizedPosition = (2f * i / (cardCount - 1) - 1f); // Normalize position between -1 and 1

            float horizontalOffset = (i - (cardCount - 1) / 2f) * cardSpacing; // Calculate horizontal offset
            float verticalOffset = VerticalSpacing * (1 - normalizedPosition * normalizedPosition); ; // Calculate vertical offset for fanned effect
            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
    }
}

using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using eoghanBreenGames;
using Unity.VisualScripting.FullSerializer; // Ensure this matches your namespace


public class DeckManager : MonoBehaviour
{
    public List<Card> allCards = new List<Card>(); // List to hold all card ScriptableObjects

    private int currentIndex = 0; // Index to track the next card to draw


    void Start()
    {
        Card[] cards = Resources.LoadAll<Card>("Cards");
        allCards.AddRange(cards);

    }
    public void DrawCard(HandManager handManager)
    {
        if (allCards.Count == 0)
        {
            Debug.LogWarning("Deck is empty! Cannot draw a card.");
            return;
        }
        // Draw the next card and increment the index
        Card nextCard = allCards[currentIndex];
        currentIndex = (currentIndex + 1) % allCards.Count; // Wrap around if at the end of the list
        // Add the drawn card to the hand
        handManager.addCardToHand(nextCard);
    }
}
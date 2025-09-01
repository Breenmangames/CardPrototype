using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace eoghanBreenGames
{
    [CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
    public class Card : ScriptableObject
   {
    
        public enum CardType   // Enum for different card types
        {
         Creature,
         Spell,
         Artifact,
         Enchantment,
         Land
      }
      public enum Rarity   // Enum for card rarity
        {
         Common,
         Uncommon,
         Rare,
         Epic,
         Legendary
        }
        public enum damageType
        {
            Physical,
            Magical,
            True
        }
        // General card attributes
        public enum CardColor
        {
            Red,
            Blue,
            Green,
            White,
            Black
        }
        
        public string cardName;  
        public CardType cardType;
        public Rarity rarity;
        public int manaCost;
        public damageType dmgType;
        public CardColor cardColor;
        public string description;
      // Creature-specific attributes
      public int attack;
      public int health;
      // Method to display card information
      public void DisplayCardInfo()
      {
         Debug.Log($"Card Name: {cardName}");
         Debug.Log($"Card Type: {cardType}");
         Debug.Log($"Mana Cost: {manaCost}");
         Debug.Log($"Description: {description}");
         Debug.Log($"Rarity: {rarity}"); 
         Debug.Log($"Damage Type: {dmgType}");
            if (cardType == CardType.Creature)
         {
            Debug.Log($"Attack: {attack}");
            Debug.Log($"Health: {health}");
         }
      }
    }
}

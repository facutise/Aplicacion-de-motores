using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
//TP2-"Facundo Sebastian Tisera"
public interface IDisplayable
{
    
    void UpdateUiCardInfo();
    void ExecuteCardPassive();
}

public class CardDisplay : MonoBehaviour, IDisplayable
{
    private static Dictionary<string, Card> cardDictionary = new Dictionary<string, Card>();

    public Card Card;
    [SerializeField]
    private Text NameText;
    [SerializeField]
    private Text DescriptionText;
    [SerializeField]
    private Image Image;

    public Text AttackText;
    [SerializeField]
    private Deck ScriptDeck;
    [SerializeField]
    private int MySlot;

    public int thePLaceOfTheSkillInTheArray;

    public int AttackDamage;
   
    public StadisticPlayer StatsPlayerScript;

    private void Awake()
    {
        // Agregamos las cartas al diccionario cuando se crea cada objeto CardDisplay
        if (Card != null && !cardDictionary.ContainsKey(Card.name))
        {
            cardDictionary.Add(Card.name, Card);
        }
    }

    private void Start()
    {
        NameText.text = Card.name;
        DescriptionText.text = Card.description;
        Image.sprite = Card.image;
        AttackText.text = Card.attack.ToString();
    }

    public static Card GetCardByName(string name)
    {
        if (cardDictionary.ContainsKey(name))
        {
            return cardDictionary[name];
        }
        else
        {
            Debug.LogWarning($"No se encontró la carta con el nombre: {name}");
            return null;
        }
    }

   

    public int Thecarddmg()
    {
        AttackDamage = Card.attack;
        return AttackDamage;    
    }

    public void UpdateUiCardInfo()
    {
        NameText.text = Card.name;
        DescriptionText.text = Card.description;
        Image.sprite = Card.image;
        AttackText.text = Card.attack.ToString();
    }

    

    public virtual void ExecuteCardPassive()
    {
        thePLaceOfTheSkillInTheArray = Card.myPassiveInt;
        StatsPlayerScript.arrayOfCardPassives[thePLaceOfTheSkillInTheArray].MySkill();
    }
}
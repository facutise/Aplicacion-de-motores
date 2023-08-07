using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
//TPFINAL-"Facundo Sebastian Tisera"
public interface IDisplayable
{
    
    void UpdateUiCardInfo();
    void ExecuteCardPassive();
    

}

public interface Itext
{
    int thePLaceOfTheSkillInTheArrayRef { get; set; }
    VigorCards CardRef { get; set; }
    StadisticPlayer stadisticPlayerScriptRef { get; set; }
    public void textfunc()
    {
        thePLaceOfTheSkillInTheArrayRef = CardRef.myPassiveInt;
        stadisticPlayerScriptRef.arrayOfCardPassives[thePLaceOfTheSkillInTheArrayRef].MySkill();
    }
}

public class CardDisplay : MonoBehaviour, IDisplayable
{
    private static Dictionary<string, Card> cardDictionary = new Dictionary<string, Card>();

    public Card Card;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Image Image;

    public Text attackText;
    [SerializeField]
    private Deck scriptDeck;
   

    public int thePLaceOfTheSkillInTheArray;

    public int attackDamage;
   
    public StadisticPlayer stadisticPlayerScript;

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
        nameText.text = Card.name;
        descriptionText.text = Card.description;
        Image.sprite = Card.image;
        attackText.text = Card.attack.ToString();
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
        attackDamage = Card.attack;
        return attackDamage;    
    }

    public void UpdateUiCardInfo()
    {
        nameText.text = Card.name;
        descriptionText.text = Card.description;
        Image.sprite = Card.image;
        attackText.text = Card.attack.ToString();
    }

    

    public virtual void ExecuteCardPassive()
    {
        thePLaceOfTheSkillInTheArray = Card.myPassiveInt;
        stadisticPlayerScript.arrayOfCardPassives[thePLaceOfTheSkillInTheArray].MySkill();
    }
}
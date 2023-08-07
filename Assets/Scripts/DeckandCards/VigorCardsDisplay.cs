using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//TP2-"Facundo Sebastian Tisera"
public class VigorCardsDisplay : MonoBehaviour, IDisplayable, IPassible
{
    public VigorCards Card;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Image Image;
    [SerializeField]
    private Text vigorText;


    public int thevigorCostOfMyCard;

    public int thePLaceOfTheSkillInTheArray;

    [SerializeField]
    protected StadisticPlayer stadisticplayerScipt;

    private static Dictionary<string, VigorCards> VigorcardDictionary = new Dictionary<string, VigorCards>();

    private IPassible itextInterfaceVariable;

    public int thePLaceOfTheSkillInTheArrayRef { get => thePLaceOfTheSkillInTheArray; set => thePLaceOfTheSkillInTheArray = value; }
    public VigorCards CardRef { get => Card; set => Card = value; }
    public StadisticPlayer stadisticPlayerScriptRef { get => stadisticplayerScipt; set => stadisticplayerScipt = value; }


    private void Awake()
    {
        // Agregamos las cartas al diccionario cuando se crea cada objeto CardDisplay
        if (Card != null && !VigorcardDictionary.ContainsKey(Card.name))
        {
            VigorcardDictionary.Add(Card.name, Card);
        }
    }

    private IPassible PassibleFunc()
    {
        thePLaceOfTheSkillInTheArrayRef = thePLaceOfTheSkillInTheArray;
        CardRef = Card;
        stadisticPlayerScriptRef = stadisticplayerScipt;

        thePLaceOfTheSkillInTheArrayRef = CardRef.myPassiveInt;
        stadisticPlayerScriptRef.arrayOfCardPassives[thePLaceOfTheSkillInTheArrayRef].MySkill();

        return null;
    }


    public static VigorCards GetVigorCardByName(string name)
    {
        if (VigorcardDictionary.ContainsKey(name))
        {
            return VigorcardDictionary[name];
        }
        else
        {
            Debug.LogWarning($"No se encontró la carta con el nombre: {name}");
            return null;
        }
    }

   
    private void Start()
    {

        nameText.text = Card.name;
        descriptionText.text = Card.description;
        Image.sprite = Card.image;

        vigorText.text = Card.vigorcost.ToString();
        thevigorCostOfMyCard = Card.vigorcost;

    }
   
    public void UpdateUiCardInfo()
    {
        nameText.text = Card.name;
        descriptionText.text = Card.description;
        Image.sprite = Card.image;

        vigorText.text = Card.vigorcost.ToString();
    }
    public int TheVigorCostOfMyCard()
    {
        thevigorCostOfMyCard = Card.vigorcost;
        return (thevigorCostOfMyCard);
    }
    public virtual void ExecuteCardPassive()
    {
        //thePLaceOfTheSkillInTheArray = Card.myPassiveInt;
        //stadisticplayerScipt.arrayOfCardPassives[thePLaceOfTheSkillInTheArray].MySkill();

        PassibleFunc();


    }

}

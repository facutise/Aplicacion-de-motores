using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//TP2-"Facundo Sebastian Tisera"
public class VigorCardsDisplay : MonoBehaviour, IDisplayable
{
    public VigorCards Card;
    [SerializeField]
    private Text NameText;
    [SerializeField]
    private Text DescriptionText;
    [SerializeField]
    private Image Image;
    [SerializeField]
    private Text VigorText;

    [SerializeField]
    private int MySlot;

    public int thevigorCostOfMyCard;

    public int thePLaceOfTheSkillInTheArray;

    [SerializeField]
    protected StadisticPlayer stadisticplayerScipt;

    private static Dictionary<string, VigorCards> VigorcardDictionary = new Dictionary<string, VigorCards>();

    private void Awake()
    {
        // Agregamos las cartas al diccionario cuando se crea cada objeto CardDisplay
        if (Card != null && !VigorcardDictionary.ContainsKey(Card.name))
        {
            VigorcardDictionary.Add(Card.name, Card);
        }
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

        NameText.text = Card.name;
        DescriptionText.text = Card.description;
        Image.sprite = Card.image;

        VigorText.text = Card.vigorcost.ToString();
        thevigorCostOfMyCard = Card.vigorcost;

    }
   
    public void UpdateUiCardInfo()
    {
        NameText.text = Card.name;
        DescriptionText.text = Card.description;
        Image.sprite = Card.image;

        VigorText.text = Card.vigorcost.ToString();
    }
    public int TheVigorCostOfMyCard()
    {
        thevigorCostOfMyCard = Card.vigorcost;
        return (thevigorCostOfMyCard);
    }
    public virtual void ExecuteCardPassive()
    {
        thePLaceOfTheSkillInTheArray = Card.myPassiveInt;
        stadisticplayerScipt.arrayOfCardPassives[thePLaceOfTheSkillInTheArray].MySkill();
        


    }

}

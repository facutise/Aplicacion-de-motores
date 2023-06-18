using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class AnimacionCartas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialScale;

    public Image MySprite;
    [SerializeField]
    private Combat combatScript;
    public Button myButton;

    void Start()
    {
        MySprite.gameObject.SetActive(false);

        initialScale = transform.localScale; 
    }
    private void Update()
    {
        if (myButton.interactable == false)
        {
            MySprite.GetComponent<Image>().gameObject.SetActive(false);
        }
        else if (myButton.interactable == true)
        {
            MySprite.GetComponent<Image>().gameObject.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, initialScale * 1.2f, 0.2f);
        
        MySprite.transform.position = transform.position;

        if (myButton.interactable == false)
        {
            MySprite.GetComponent<Image>().gameObject.SetActive(false);
        }
        else if(myButton.interactable == true)
        {
            MySprite.GetComponent<Image>().gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, initialScale, 0.2f);

        MySprite.gameObject.SetActive(false);
    }
}

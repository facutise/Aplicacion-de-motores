using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP2-"Facundo Sebastian Tisera"
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite image;
    public int vigorcost;
    public int attack;
}

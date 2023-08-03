using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsPassives : MonoBehaviour
{
    //EL PLAN ES QUE ESTE SEA EL PADRE, TIRAR TODOS LOS HIJOS EN PLAYER, CREAR UN ARRAY DE LOS HIJOS DE CARDPASSIVES EN stadisticplayer Y QUE LOS CARD DISPLAY
    // ACCEDAN A ELLOS A TRAVES DEL ARRAY EN UNA FUNCIÓN QUE RECIBA COMO PARAMETRO UN NUEVO INT QUE VOY A CREAR EN CARD Y DEPENDIENDO DE CUAL, ES EL SCRIPT HIJO QUE SE EJECUTA
    // EJEMPLO DE CARDDISPLAY: public void ExecutePassive(int intdelcard)
    // {
    //    stadisticplayerscript.cardpassivesArray[intdelcard].MySkill;
    // }

    //LAS variables van en stadisticplayer y las llamamos desde los hijos
    [SerializeField]
    protected StadisticPlayer stadisticPlayerScript;
    
    
   
    public virtual void MySkill()
    {
        //cardDisplayScript.sacredFontParticles.Play(); //FUNCIONA
        //cardDisplayScript.DamageParticlesInTheCombats[0].Play(); // FUNCIONA
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

//TPFINAL - Santiago Andres Sanchez Barrio

public class PlayerSensor : MonoBehaviour
{
    [SerializeField] UnityEvent EV_OnPlayerEnter;
    [SerializeField] UnityEvent EV_OnPlayerExit;

    public float doorContador;
    public CinemachineVirtualCamera doorCamera;
    public Player player;
    public Collider playerColl;
    public Rigidbody playerRB;
    public List<CinemachineVirtualCamera> camarasDoor;
    public CinemachineVirtualCamera activeCamera;
    public MyCamera myCamera;

    public Light keyLight;

    public ParticleSystem particleKey;

    private void OnTriggerEnter(Collider other)
    {
        print("Se encontró una llave.");
        if (IsPlayer(other))
        {
            SwitchCameraDoor(camarasDoor[1]);
            player.enabled = false;
            myCamera.canMoveCamera = false;
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
            EV_OnPlayerEnter.Invoke();
            playerColl.enabled = false;
            keyLight.enabled = false;
            particleKey.Stop();
            StartCoroutine(CameraTransation());
        }
    }

    
   
    public void SwitchCameraDoor(CinemachineVirtualCamera Door)
    {
        Door.Priority = 10;
        activeCamera = Door;

        foreach (CinemachineVirtualCamera c in camarasDoor)
        {
            if (c != Door && c.Priority != 0)
            {
                c.Priority = 0;
            }
        }


    }
    bool IsPlayer(Collider col)
    {
        Player c = col.GetComponent<Player>();
        if (c == GameManager.instance.Player())
        {
            return true;
        }
        return false;
    }

    IEnumerator CameraTransation()
    {
        yield return new WaitForSeconds(doorContador);

        Transition();
        Invoke("Playerenabled", 2.5f);

        yield return null;
    }

    void Transition()
    {
        SwitchCameraDoor(camarasDoor[0]);
        EV_OnPlayerExit.Invoke();

    }
    void Playerenabled()
    {
        player.enabled = true;
        playerRB.constraints = RigidbodyConstraints.None;
        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
        myCamera.canMoveCamera = true;

    }
}

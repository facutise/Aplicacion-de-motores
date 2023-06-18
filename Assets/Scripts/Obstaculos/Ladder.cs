using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private float ladderSpeed = 3.0f; // La velocidad a la que sube o baja el jugador por la escalera
    [SerializeField] private Transform ladderTop; // La posici�n en la parte superior de la escalera
    [SerializeField] private Transform ladderBottom; // La posici�n en la parte inferior de la escalera

    [SerializeField] private bool isClimbing = false; // Indica si el jugador est� subiendo o bajando por la escalera
    private GameObject player; // Referencia al objeto del jugador
    private Rigidbody playerRigidbody; // Referencia al Rigidbody del jugador
    private Vector3 lastPosition; // �ltima posici�n conocida del jugador en la escalera

    private void Start()
    {
        // Obtiene la referencia al Rigidbody del jugador
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {

        if (isClimbing == true)
        {
            playerRigidbody.useGravity = false;
        }

        // Comprueba si el jugador est� en contacto con la escalera
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f, Quaternion.identity);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                player = collider.gameObject; // Obtiene la referencia al objeto del jugador
                isClimbing = true;
                break;
            }
        }

        // Si el jugador est� subiendo o bajando por la escalera
        if (isClimbing && player != null)
        {
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (verticalInput != 0)
            {
                lastPosition = player.transform.position; // Actualiza la �ltima posici�n conocida del jugador en la escalera

                Vector3 newPosition = lastPosition;
                Vector3 movement = new Vector3(0, verticalInput * ladderSpeed * Time.deltaTime, 0);
                newPosition = player.transform.position + movement;
                newPosition.x = ladderBottom.position.x;
                newPosition.z = ladderBottom.position.z;
                // Limita la posici�n del jugador a la escalera
                if (newPosition.y > ladderTop.position.y)
                {
                    newPosition.y = ladderTop.position.y;
                }
                else if (newPosition.y < ladderBottom.position.y)
                {
                    newPosition.y = ladderBottom.position.y;
                }

                // Actualiza la posici�n del jugador utilizando el Rigidbody
                playerRigidbody.MovePosition(newPosition);

                // Si el jugador llega a la parte superior o inferior de la escalera, desactiva el modo escalera
                if (newPosition.y == ladderTop.position.y || newPosition.y == ladderBottom.position.y)
                {
                    isClimbing = false;
                }
            }
            else if (lastPosition != Vector3.zero && player.transform.position != lastPosition && Input.GetAxisRaw("Vertical") == 0)
            {
                // Si el jugador no se mueve y ha dejado una �ltima posici�n conocida, y no hay entrada vertical, el jugador no se mueve
                playerRigidbody.MovePosition(lastPosition);
            }
        }
        else
        {
            // Si el jugador no est� en contacto con la escalera
            isClimbing = false;
            player = null;
            lastPosition = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRigidbody.useGravity = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRigidbody.useGravity = false;
            Debug.Log("esta");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRigidbody.useGravity = true;
        }
    }
}

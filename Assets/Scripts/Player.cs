using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _yVelocity;
    [SerializeField] private float _speed = 200f;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public float yVelocity
    {
        get { return _yVelocity; }
        set { _yVelocity = value; }
    }

    private Vector3 playerInput;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePLayer;
    Charview view;
    public MenuManager menumanagerscript;
    public float playerspeed;
    public int _maxhealth = 30; 
    public int vigorPoints = 40;

    public float _currenthealth; 


    private void Awake()
    {
        view = GetComponent<Charview>();
    }
    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            menumanagerscript.Restartscene();
        }

        camDirection();

        movePLayer = playerInput.x * camRight + playerInput.z * camForward;

        if(movePLayer.magnitude > 0.3f)
        {
            view.Isrunning(true);
        }
        else
        {
          view.Isrunning(false);
        }
    }

    
    
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

}

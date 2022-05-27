using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;

    InputMaster playerInputActions;
    private float xMin, xMax;

    private void Awake()
    { 
        playerInputActions = new InputMaster();
        playerInputActions.Enable();
    }

    void Start()
    {
        var camera = Camera.main;
        var cameraWidth = camera.orthographicSize * camera.aspect;
        xMin = -cameraWidth;
        xMax = cameraWidth;
    }

    void Update()
    {
        var moveInput = playerInputActions.Player.Movement.ReadValue<float>();
        if (moveInput != 0)
        {
            Move(moveInput);
        }
    }

    private void Move(float input)
    {
        var moveInput = input * moveSpeed * Time.deltaTime;
        var xValidPosition = Mathf.Clamp(transform.position.x + moveInput, xMin, xMax);
        transform.position = new Vector3(xValidPosition, transform.position.y, 0);
        transform.Rotate(Vector3.up * (rotationSpeed * -input * 100) * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meteor"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}

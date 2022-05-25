using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;

    private float xMin, xMax;

    // Start is called before the first frame update
    void Start()
    {
        var camera = Camera.main;
        var cameraWidth = camera.orthographicSize * camera.aspect;
        xMin = -cameraWidth;
        xMax = cameraWidth;
    }

    // Update is called once per frame
    void Update()
    {
        var moveInput = Input.GetAxis("Horizontal");
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

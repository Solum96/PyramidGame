using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(Input.GetAxis("Horizontal"));
    }

    private void Move(float input)
    {
        transform.position += new Vector3(input, 0, 0) * moveSpeed * Time.deltaTime;
    }
}
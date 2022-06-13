using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour, IPooledObject
{
    public float minFallSpeed;
    public float maxFallSpeed;
    public float minRotationSpeed;
    public float maxRotationSpeed;
    private float fallSpeed;
    private float rotationSpeed;
    public Rigidbody rigidbody;
    

    void Start()
    {
    }

    public void OnObjectSpawn()
    {
        fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        var xRot = Random.Range(-1, 1);
        var yRot = Random.Range(-1, 1);
        var zRot = Random.Range(-1, 1);
        var rotationVector = new Vector3(xRot, yRot, zRot) * rotationSpeed;

        if(rigidbody != null)
        {
            rigidbody.AddTorque(rotationVector);
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -fallSpeed / 2, 0) * Time.deltaTime; 
    }
}

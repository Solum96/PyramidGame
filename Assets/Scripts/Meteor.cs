using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private float fallSpeed;

    public void OnObjectSpawn()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -fallSpeed / 2, 0) * Time.deltaTime; 
    }
}

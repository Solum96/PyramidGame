using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    private ObjectPooler _objectPooler;
    public float spawnCooldown = 5;
    public float spawnWidth;
    private float countdown;
    // Start is called before the first frame update
    void Start()
    {
        _objectPooler = ObjectPooler.Instance;
        var camera = Camera.main;
        var cameraWidth = camera.orthographicSize * camera.aspect;
        spawnWidth = cameraWidth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(countdown <= 0f)
        {
            var spawnWidthVector = new Vector3(1, 0, 0) * Random.Range(-spawnWidth, spawnWidth);

            _objectPooler.SpawnFromPool("Meteor", transform.position + spawnWidthVector, Random.rotation);
            countdown = spawnCooldown;
        }
        else
        {
            countdown -= Time.fixedDeltaTime;
        }
    }
}

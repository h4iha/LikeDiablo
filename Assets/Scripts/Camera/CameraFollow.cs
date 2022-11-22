using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float y;
    [SerializeField] float z;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y + y, target.position.z + z);
       //transform.rotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
    }
}

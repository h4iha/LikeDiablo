using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FollowScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform follow;
    [SerializeField] float y;
    [SerializeField] float z;
    private void Awake()
    {
        foreach (CharacterController c in transform.GetComponentsInChildren<CharacterController>())
        {
            if (c != null) target = gameObject.GetComponentInChildren<CharacterController>().transform;
        }
        follow = gameObject.GetComponent<Transform>().Find("HP");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y + y, target.position.z + z);
        //transform.rotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
    }
}

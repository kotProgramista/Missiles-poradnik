using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(target)
        transform.LookAt(target);
    }
    private void Update()
    {
        if (!target)
            Destroy(gameObject);
    }
}

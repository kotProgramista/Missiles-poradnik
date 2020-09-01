using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public float followSpeed = 0.1f;
    private Vector2 velocity;
    private float positionX, positionY;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        positionX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x, followSpeed);
        positionY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity.x, followSpeed);

        transform.position = new Vector3(positionX, positionY, transform.position.z);
        transform.LookAt(target);
    }
}

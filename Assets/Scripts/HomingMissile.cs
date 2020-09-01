using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public ParticleSystem blowParticles;
    public float speed = 1f;
    public float rotationSpeed = 100f;
    public float hitForce = 1f;
    public float maxLifeTime = 10f;
    private float lifeTime = 0f;
    private Rigidbody2D rb;
    Vector2 direction;
    [SerializeField]
    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        lifeTime = 0f;
    }
    private void FixedUpdate()
    {
        direction = (Vector2)target.position - rb.position;
        direction.Normalize();

        float rotationValue = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotationValue * rotationSpeed;
        rb.velocity = transform.up * speed; 
    }
    private void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
            Destroy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(blowParticles, transform.position, transform.rotation);
        Destroy();
    }
    public void Destroy()
    {
        Instantiate(blowParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}

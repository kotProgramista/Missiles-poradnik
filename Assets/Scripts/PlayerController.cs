using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    float horizontal = 0f, vertical = 0f;
    public float HP = 10f;
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontal, vertical, 0f);              
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<HomingMissile>();
        if (enemy != null)
        {
            HitPlayer(enemy.hitForce);
        }
    }
    private void HitPlayer(float force)
    {
        HP -= force;
        Debug.Log("Player został trafiony. Aktualny HP: " + HP);
        PlayerStateControl();
    }
    private void PlayerStateControl()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public Vector2 GetRandomPositionInsideCircle(float range)
    {
        return UnityEngine.Random.insideUnitCircle.normalized * range + (Vector2)transform.position;
    }
}

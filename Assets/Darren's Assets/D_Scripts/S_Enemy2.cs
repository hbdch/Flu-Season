﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Enemy2 : MonoBehaviour
{
    public float Speed = .01f;
    public string Type;
    private int e_lives = 3;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        //Reposition();
    }

    void Reposition()
    {
        float randY = Random.Range(-5f, 5f);
        this.transform.position = new Vector3(-8, randY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        if (player != null)
            transform.position = Vector2.MoveTowards(transform.position, player.GetComponent<Transform>().position, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (e_lives == 1)
            {
                GameObject.FindGameObjectWithTag("LevelManager").GetComponent<D_SimpleLevelManager>().EnemyKill(3);
                Destroy(this.gameObject);
            }
            else
            {
                e_lives--;
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}

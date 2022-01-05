﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableWeapon : MonoBehaviour
{
	public float damage = 1f;
	public Vector2 direction;
	public bool hasHit = false;
	public float speed = 10f;
	// Update is called once per frame
    void FixedUpdate()
    {
	    if (!hasHit)
	    {
		    GetComponent<Rigidbody2D>().velocity = direction * speed;
	    }
			
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			collision.gameObject.SendMessage("ApplyDamage", damage);
			Destroy(gameObject);
		}
		else if (collision.gameObject.tag != "Player")
		{
			Destroy(gameObject);
		}
	}
}
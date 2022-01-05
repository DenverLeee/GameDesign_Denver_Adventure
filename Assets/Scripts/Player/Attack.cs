using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	public float dmgValue = 4;
	public GameObject throwableObject;
	public Transform attackCheck;
	private Rigidbody2D m_Rigidbody2D;
	public Animator animator;
	public bool canAttack = true;
	public bool isTimeToCheck = false;

	public GameObject cam;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.J) && canAttack)
		{
			canAttack = false;
			animator.SetBool("IsAttacking", true);
			DoDamage();
			StartCoroutine(AttackCooldown());
		}

		if (Input.GetKeyDown(KeyCode.L) && canAttack)
		{
			canAttack = false;
			GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f,2f), Quaternion.identity) as GameObject; 
			Vector2 direction = new Vector2(transform.localScale.x, 0);
			throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction; 
			throwableWeapon.name = "ThrowableWeapon";
			StartCoroutine(ThrowableAttackCooldown());
		}
	}
    
    //Set time between Melee Attack
	IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(0.7f);
		canAttack = true;
	}
	
	//Set time between Range Attack
	IEnumerator ThrowableAttackCooldown()
	{
		yield return new WaitForSeconds(0.7f);
		canAttack = true;
	}

	public void DoDamage()
	{
		dmgValue = Mathf.Abs(dmgValue);
		Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 1.3f);
		for (int i = 0; i < collidersEnemies.Length; i++)
		{
			if (collidersEnemies[i].gameObject.tag == "Enemy")
			{
				if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
				{
					dmgValue = -dmgValue;
				}
				collidersEnemies[i].gameObject.SendMessage("ApplyDamage", dmgValue);
				// TODO:Set a manager to manage this camshake
				cam.GetComponent<CameraFollow>().ShakeCamera();
			}
		}
	}
}

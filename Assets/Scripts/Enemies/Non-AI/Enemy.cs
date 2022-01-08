using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class Enemy : MonoBehaviour {

	public float life = 10;
	private bool isPlat;
	private bool isObstacle;
	private Transform fallCheck;
	private Transform wallCheck;
	public LayerMask turnLayerMask;
	private Rigidbody2D rb;
	public EnemyDrop drop;
	[SerializeField] public GameObject damageFloat;

	private bool facingRight = true;
	
	public float speed = 5f;

	public bool isInvincible = false;
	private bool isHitted = false;

	void Awake () {
		fallCheck = transform.Find("FallCheck");
		wallCheck = transform.Find("WallCheck");
		drop = GetComponent<EnemyDrop>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (life <= 0) {
			transform.GetComponent<Animator>().SetBool("IsDead", true);
			StartCoroutine(DestroyEnemy());
			// Destroy(gameObject);
		}
		

		isPlat = Physics2D.OverlapCircle(fallCheck.position, .2f, 1 << LayerMask.NameToLayer("Default"));
		isObstacle = Physics2D.OverlapCircle(wallCheck.position, .2f, turnLayerMask);

		if (!isHitted && life > 0 && Mathf.Abs(rb.velocity.y) < 0.5f)
		{
			if (isPlat && !isObstacle && !isHitted)
			{
				if (facingRight)
				{
					rb.velocity = new Vector2(-speed, rb.velocity.y);
				}
				else
				{
					rb.velocity = new Vector2(speed, rb.velocity.y);
				}
			}
			else
			{
				Flip();
			}
		}
	}

	void Flip (){
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void ApplyDamage(float damage) {
		if (!isInvincible) 
		{
			transform.GetComponent<Animator>().SetBool("Hit", true);
			GameObject gb  = Instantiate(damageFloat,gameObject.transform.position,quaternion.identity) as GameObject;
			gb.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
			float direction = damage / Mathf.Abs(damage);
			damage = Mathf.Abs(damage);
			life -= damage;
			rb.velocity = Vector2.zero;
			rb.AddForce(new Vector2(direction * 500f, 100f));
			StartCoroutine(HitTime());
		}
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && life > 0)
		{
			collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(1f, transform.position);
		}
	}

	IEnumerator HitTime()
	{
		isHitted = true;
		isInvincible = true;
		yield return new WaitForSeconds(0.1f);
		isHitted = false;
		isInvincible = false;
	}

	IEnumerator DestroyEnemy()
	{
		BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
		// CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
		// capsule.size = new Vector2(1f, 0.25f);
		// capsule.offset = new Vector2(0f, -0.8f);
		// capsule.direction = CapsuleDirection2D.Horizontal;
		boxCollider2D.size = new Vector2(1f, 0.25f);
		boxCollider2D.offset = new Vector2(0f, -0.8f);


		yield return new WaitForSeconds(0);
		rb.velocity = new Vector2(0, rb.velocity.y);
		yield return new WaitForSeconds(0.25f);
		drop.getOrange();
		// Destroy(gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class ChaseEnemy : MonoBehaviour,IDamageable
{
	[SerializeField] int hp = 10;
	Transform player;
	[SerializeField] float speed;
	[SerializeField] Vector2 attackSize = Vector2.one;
	[SerializeField] int damage = 1;
	[SerializeField] float timeToAttack = 2f;
	float attackTimer;
	Animator animator;
	public bool live;
	void Start()
	{
		animator = FindObjectOfType<Animator>();
		player = GameManager.instance.player.transform;
		attackTimer = Random.Range(0, timeToAttack);
		animator.SetBool("walk", true);
	}
	void Update()
	{
		transform.position = Vector3.MoveTowards(
			transform.position,
			player.position,
			speed = Time.deltaTime

			);
		
		Attack();
	}

	private void Attack()
	{
		attackTimer -= Time.deltaTime;

		if (attackTimer > 0f) { return; }

		attackTimer = timeToAttack;
		Collider2D[] targets = Physics2D.OverlapBoxAll(transform.position, attackSize, 0f);
		for (int i = 0; i < targets.Length; i++)
		{
			Damageable character = targets[i].GetComponent<Damageable>();
			if (character != null)
			{
				character.TakeDamage(damage);
			}
		}
	}

	public void CalculateDamage(ref int damage)
	{
		hp -= damage;
	}

	public void ApplyDamage(int damage)
	{
		damage = 5;
	}

	public void CheckState()
	{
		StartCoroutine(DieCoroutine());
		
	}

	IEnumerator DieCoroutine()
	{
		if (hp <= 0)
		{
			animator.SetBool("walk", false);

			yield return new WaitForSeconds(0.5f);
			Destroy(gameObject);
		}
	}
}

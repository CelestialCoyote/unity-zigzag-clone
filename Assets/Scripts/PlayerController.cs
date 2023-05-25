using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	public Transform rayStart;
	public GameObject crystalEffect;
    private Rigidbody rigidbody;
	private bool walkingRight = true;
	private Animator animator;
	private GameManager gameManager;

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		gameManager = FindObjectOfType<GameManager>();
	}

	private void FixedUpdate()
	{
		if (!gameManager.gameStarted)
			return;
		else
			animator.SetTrigger("gameStarted");

		rigidbody.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
		{
			Switch();
		}

		RaycastHit hit;

		if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
		{
			animator.SetTrigger("isFalling");
		}

		if (transform.position.y < -2)
			gameManager.EndGame();
    }

	private void Switch()
	{
		if (!gameManager.gameStarted)
			return;

		walkingRight = !walkingRight;

		if (walkingRight)
			transform.rotation = Quaternion.Euler(0, 45, 0);
		else
			transform.rotation = Quaternion.Euler(0, -45, 0);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Crystal")
		{
			GameObject effect = Instantiate(crystalEffect, rayStart.transform.position, Quaternion.identity);
			
			gameManager.IncreaseScore();
			
			Destroy(effect, 2);
			Destroy(other.gameObject);
		}	
	}
}

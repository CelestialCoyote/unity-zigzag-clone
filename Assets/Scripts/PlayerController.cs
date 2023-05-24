using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
	private bool walkingRight = true;
	public Transform rayStart;
	private Animator animator;

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}

	private void FixedUpdate()
	{
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
    }

	private void Switch()
	{
		walkingRight = !walkingRight;

		if (walkingRight)
			transform.rotation = Quaternion.Euler(0, 45, 0);
		else
			transform.rotation = Quaternion.Euler(0, -45, 0);
	}
}

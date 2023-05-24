using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
	private bool walkingRight = true;

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
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

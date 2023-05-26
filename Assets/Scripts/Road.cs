using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
	public GameObject roadPrefab;
	public float offset = 0.707f;
	public Vector3 lastPosition;

	private int roadCount = 0;

	public void StartBuilding()
	{
		InvokeRepeating("CreateRoadPart", 1.0f, 0.5f);
	}

    public void CreateRoadPart()
	{
		Vector3 spawnPosition = Vector3.zero;
		float chance = Random.Range(0, 100);

		if (chance < 50)
			spawnPosition = new Vector3(lastPosition.x + offset, lastPosition.y, lastPosition.z + offset);
		else
			spawnPosition = new Vector3(lastPosition.x - offset, lastPosition.y, lastPosition.z + offset);

		GameObject roadSection = Instantiate(roadPrefab, spawnPosition, Quaternion.Euler(0, 45, 0));

		lastPosition = roadSection.transform.position;

		roadCount++;
		if (roadCount % 5 == 0)
			roadSection.transform.GetChild(0).gameObject.SetActive(true);
	}
}

using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour {

	bool goRight;
	Vector2 moveOffset;
	public Transform platform;
	public Transform startPos;
	public Transform endPos;
	public int platformSpeed = 2;
	Transform destination;
	Vector2 direction;
	public float leeWay = 2;

	bool activePlatform = false;

	// Use this for initialization
	void Start () {
		//startPos = transform;
		setDestination (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (activePlatform)
					MovePlatform ();
	}

	public void MovePlatform()
	{
		Vector2 position = (Vector2)platform.transform.position;
		//Vector2 newPosition = position * direction * platformSpeed * Time.deltaTime
		platform.rigidbody2D.MovePosition (position + direction * platformSpeed * Time.deltaTime);
		if(Vector2.Distance(position, (Vector2)destination.position) < leeWay)
		   activePlatform = false;

	}

	public void switchOn()
	{
		activePlatform = true;

	}

	void OnDrawGizmo()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawSphere (startPos.position, 100);

		Gizmos.color = Color.red;
		Gizmos.DrawSphere (endPos.position, 100);
	}

	public void setDestination(bool start)
	{
		if (start)
				destination = startPos;
		else
				destination = endPos;
		direction = ((Vector2)destination.position - (Vector2)platform.position).normalized;  
	}


}

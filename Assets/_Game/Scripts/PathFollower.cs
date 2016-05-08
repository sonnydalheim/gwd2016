using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {

	public Transform[] path;
	public float speed = 5.0f;
	public float reachDist = 1.0f;
	public int currentPoint = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Moving our object towards the current point.
		Vector3 dir = path[currentPoint].position - transform.position;

		float dist  = Vector3.Distance(path[currentPoint].position, transform.position);
		transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);

		if (dist <= reachDist) {
			currentPoint++;
		}

		if (currentPoint >= path.Length) {
			currentPoint = 0;
		}

		transform.rotation = Quaternion.LookRotation(dir);
	}

	// Make the points on the path visible in the scene view.
	void OnDrawGizmos () {
		if (path.Length > 0) {
			for (int i = 0; i< path.Length; i++) {
				if (path != null) {
					Gizmos.DrawSphere(path[i].position, reachDist);
				}
			}
		}
	}
}

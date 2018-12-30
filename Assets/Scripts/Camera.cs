using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Camera : NetworkBehaviour {

	[SerializeField] Transform player;
	private Vector3 separation;
	// Use this for initialization
	void Start () {
		player = transform.parent.GetChild(0);
		separation = transform.position - player.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = player.position + separation;
	}
}

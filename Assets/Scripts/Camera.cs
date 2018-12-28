using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    [SerializeField] Transform player;
    private Vector3 separation;
	// Use this for initialization
	void Start () {
        separation = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position + separation;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    private float circleDiameter;

    [SerializeField] float speed;
    [SerializeField] float power;
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerCollision collisionTracker;

    private Vector3 lastPosition = new Vector3(0,0,0);
    private Vector3 currentVelocity = new Vector3(0,0,0);

    private float boostCooldown = 1.0f;
    private float boostTimeStamp;

	// Use this for initialization
	void Start () {
        collisionTracker = GetComponent<PlayerCollision>();
        rb = GetComponentInChildren<Rigidbody>();
        boostTimeStamp = Time.time;
        circleDiameter = 25f;
	}

    private void FixedUpdate()
    {
        // get current velocity for direction to boost if activated
        currentVelocity = (rb.transform.position - lastPosition) / Time.fixedDeltaTime;

        // Boost
        if (Input.GetAxis("Jump") > 0 && boostTimeStamp <= Time.time)
        {
            boostTimeStamp = Time.time + boostCooldown;
            boost(currentVelocity);
        }

        // Movement
        if (isLocalPlayer == true)
        {
            movementUpdate();
        }
        else 
        {
            Debug.Log("Not Local");
        }

        // Update last position for calculating current velocity
        lastPosition = rb.transform.position;

        // Knocked out?
        if (lastPosition.magnitude > circleDiameter/2f)
        {
            collisionTracker.knockedOutOfRing();
        }
    }

    // Update is called once per frame
    void Update () {

    }

    void boost (Vector3 direction)
    {
        rb.AddForce(direction * Time.deltaTime * power, ForceMode.Impulse);
    }

    void movementUpdate()
    {
        float translationX = Input.GetAxis("Horizontal") * speed;
        float translationZ = Input.GetAxis("Vertical") * speed;
        translationX *= Time.fixedDeltaTime;
        translationZ *= Time.fixedDeltaTime;
        Vector3 move = new Vector3(translationX, 0, translationZ);
        rb.MovePosition(rb.transform.position + move);
    }
    
    public string getName() 
    {
        return name;
    }
}

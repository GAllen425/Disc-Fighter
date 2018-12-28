using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float mass;
    [SerializeField] float power;
    [SerializeField] Rigidbody rb;

    private Vector3 lastPosition = new Vector3(0,0,0);
    private Vector3 currentVelocity = new Vector3(0,0,0);

    private float boostCooldown = 1.0f;
    private float boostTimeStamp;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        boostTimeStamp = Time.time;
	}

    private void FixedUpdate()
    {
        currentVelocity = (transform.position - lastPosition) / Time.fixedDeltaTime;

        float translationX = Input.GetAxis("Horizontal") * speed;
        float translationZ = Input.GetAxis("Vertical") * speed;

        /*if (Input.GetAxis("Horizontal") == 0.0f && Input.GetAxis("Vertical") == 0.0f)
        {
            rb.velocity = rb.velocity * 0.9f;
        }*/

        // Make it move 10 meters per second instead of 10 meters per frame...
        translationX *= Time.fixedDeltaTime;
        translationZ *= Time.fixedDeltaTime;


        // Move translation along the object's z-axis
        //transform.Translate(translationX, 0, translationZ);
        Vector3 move = new Vector3(translationX, 0, translationZ);
        rb.MovePosition(transform.position + move);
        //rb.AddForce(move,ForceMode.VelocityChange);

        if (Input.GetAxis("Jump") > 0 && boostTimeStamp <= Time.time)
        {
            Debug.Log("Boosting");
            boostTimeStamp = Time.time + boostCooldown;
            boost(currentVelocity);
        }


        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {


    }

    void boost (Vector3 direction)
    {
        rb.AddForce(direction * Time.deltaTime * power, ForceMode.Impulse);
    }
}

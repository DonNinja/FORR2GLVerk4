using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float timeBetweenShots = 2f;
    float timer;
    public Rigidbody playerball;
    public float playerSpeed;
    public float force;
    Vector3 lastposition = new Vector3();
    private bool finished;
    //public Camera main;

    private void Start()
    {
        Physics.sleepThreshold = 0.1f;
    }

    private void Update()
    {
        if (finished)
        {
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (playerSpeed == 0 || timer >= timeBetweenShots && Time.timeScale != 0)
            {
                playerball.AddForce(Camera.main.transform.forward * force);
            }
        }
        playerSpeed = (transform.position - lastposition).magnitude;
        lastposition = transform.position;
    }

    private void OnTriggerEnter(Collider finish)
    {
        if (finish.gameObject.tag == "Finish")
        {
            finished = true;
        }
    }
}

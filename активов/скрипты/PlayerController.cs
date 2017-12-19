using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    private Rigidbody rb;

    public int countCube;
    public int countCapsule;
    public int countCylinder;

    public Text countTextCube;
    public Text countTextCapsule;
    public Text countTextCylinder;
    public Text winText;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        countCube = 0;
        countCapsule = 0;
        countCylinder = 0;
        winText.text = "";
        setCountCube();
        setCountCapsule();
        setCountCylinder();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Cube")
        {
            Destroy(other.gameObject);
            countCube = countCube + 5;
            setCountCube();
        }
        if (other.tag == "Capsule")
        {
            Destroy(other.gameObject);
            countCapsule = countCapsule + 10;
            setCountCapsule();
        }
        if (other.tag == "Cylinder")
        {
            Destroy(other.gameObject);
            countCylinder = countCylinder + 15;
            setCountCylinder();
        }
	}

    void setCountCube ()
    {
        countTextCube.text = "Cubes: " + countCube.ToString ();
        if ((countCube == 20) && (countCapsule == 30) && (countCylinder == 75))
            winText.text = "You Win!";
    }

    void setCountCapsule ()
    {
        countTextCapsule.text = "Capsules: " + countCapsule.ToString();
        if ((countCube == 20) && (countCapsule == 30) && (countCylinder == 75))
            winText.text = "You Win!";
    }

    void setCountCylinder ()
    {
        countTextCylinder.text = "Cylinders: " + countCylinder.ToString();
        if ((countCube == 20) && (countCapsule == 30) && (countCylinder == 75))
            winText.text = "You Win!";
    }

}

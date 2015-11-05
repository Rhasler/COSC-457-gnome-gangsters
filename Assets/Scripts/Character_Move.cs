using UnityEngine;
using System.Collections;

public class Character_Move : MonoBehaviour {
	public Rigidbody rb;
	public float Speed = 10f;
	private float movex = 0f;
	private int jump_count = 1;
	//private float movey = 0f;

	// Use this for initialization
	void Start () {
		//change gravity value
		Physics.gravity = new Vector3 (0, -15.0f, 0);
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//A to move left
		if (Input.GetKey (KeyCode.A)) {
			movex = -1;
		//D to move right
		} else if (Input.GetKey (KeyCode.D)) {
			movex = 1;
		}  else {
			//player keeps moving if in air, otherwise stops
			if(rb.velocity.y == 0)
			{
				movex = 0;
			}
			//movey = 0;
		}
		//jump if not already in air
		if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0) {
			rb.AddForce (new Vector2 (0,400));
		}

	}

	void FixedUpdate()
	{
		//movex = Input.GetAxis ("Horizontal");
		//movey = Input.GetAxis ("Vertical");
		rb.velocity = new Vector2 (movex * Speed, rb.velocity.y);
		//rb.velocity = movex * Speed;
	}
}

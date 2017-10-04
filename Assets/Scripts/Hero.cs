using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	AudioSource audio;

	public float speed;
	public bool selected = false;
	public GameObject circle;

	private Vector3 goal;
	private Vector3 dir;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		goal = transform.position;
		circle.GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

		//Move
		transform.position = Vector2.MoveTowards (transform.position, goal, speed * Time.deltaTime);

		if (Vector2.Distance (transform.position, goal) == 0) {
			anim.SetBool ("is_running", false);
		}
			
		//Rotate the MOFO
		Vector3 moveDirection = this.transform.position - goal; 
		if (moveDirection != Vector3.zero) 
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
		}
	}

	public void player_move()
	{
		if (Input.GetMouseButtonDown (0))
		{			
			//Click Stuff
			Vector2 mousepos = Input.mousePosition;
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (mousepos), Vector2.zero);

			if (hit.collider != null)
			{
				if (hit.collider.name == "Map")
				{
					Debug.Log ("Moving Hero");
					//Move stuff
					goal = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					anim.SetBool ("is_running", true);
					audio.Play ();
				}
			}

		}
	}
}

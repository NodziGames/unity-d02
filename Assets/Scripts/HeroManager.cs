using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour {

	// Use this for initialization
	private List<GameObject> heroes;

	void Start ()
	{
		heroes = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			Vector2 mousepos = Input.mousePosition;
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (mousepos), Vector2.zero);

			if (hit.collider != null)
			{
				if (hit.collider.tag == "Hero")
				{
					if (!Input.GetKey (KeyCode.LeftControl))
					{
						for (int i = 0; i < heroes.Count; i++)
							heroes [i].GetComponent<Hero> ().circle.GetComponent<SpriteRenderer> ().enabled = false;
						heroes.Clear ();
					}
					hit.collider.gameObject.GetComponent<Hero> ().circle.GetComponent<SpriteRenderer> ().enabled = true;
					heroes.Add (hit.collider.gameObject);
				}
			}
		}

		for (int i = 0; i < heroes.Count; i++)
		{
			heroes[i].GetComponent<Hero>().player_move ();
		}

		if (Input.GetMouseButtonDown (1))
		{
			for (int i = 0; i < heroes.Count; i++)
				heroes [i].GetComponent<Hero> ().circle.GetComponent<SpriteRenderer> ().enabled = false;

			heroes.Clear ();
		}
	}
}

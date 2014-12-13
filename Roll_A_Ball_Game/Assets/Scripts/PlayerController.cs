using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	private int scoreCount;
	public GUIText scoreText;
	public GUIText winText;

	void Start()
	{
		scoreCount = 0;
		SetScoreCount ();
		winText.text = "";
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive (false);
			scoreCount += 1;
			SetScoreCount();
		}
	}

	void SetScoreCount()
	{
		scoreText.text = "Score: " + scoreCount.ToString ();

		if (scoreCount >= 13) 
		{
			winText.text = "YOU WIN!";
		}
	}
}

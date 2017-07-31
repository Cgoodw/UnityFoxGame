using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class move : MonoBehaviour {
	public float speed = 10f;
	public float jumpforce = 50f;
	private float  gravity = 700f;
	private Vector3 moves = Vector3.zero; 
	private Transform player;
	private Quaternion characterTargetRotation;
	private Vector3 characterTargetRot;
	private Quaternion smoothrot;
	private CharacterController Controller;
	public float XSensitivity = 1.0f;

	void Start () {
		player = transform;
		Controller =  gameObject.GetComponent<CharacterController>();
//		print ("rot " + player.rotation);
//		print ("local rot " +player.localRotation);
	}


	void Update () {
		

	
		moves = new Vector3 (Input.GetAxis("Horizontal"),0 ,(Input.GetAxis("Vertical")) );   moves = transform.TransformDirection(moves);
		moves *= speed;

		if (Input.GetButtonDown("Jump") && Controller.isGrounded) {
			moves.y = jumpforce *Time.deltaTime;
		}

		characterTargetRotation = Quaternion.Euler(0f, Input.GetAxis("Mouse X") * XSensitivity, 0f);
		//characterTargetRot.Set (Input.GetAxis("Mouse X"),0f, 0f);
		//characterTargetRotation.eulerAngles.x,
		if(moves != Vector3.zero){
			player.forward.Equals(characterTargetRotation.eulerAngles);
		}
		Controller.Move (moves * Time.deltaTime);
	}
}
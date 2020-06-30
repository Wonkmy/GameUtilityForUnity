using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public static CameraFollow instance;

	void Awake()
	{
		instance = this;
	}
	public Transform target;
	public Vector3 offset;
	private Vector3 cur_velo;
	void FixedUpdate () {
		transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref cur_velo, 0.5f);
	}
}

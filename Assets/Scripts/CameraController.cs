using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Vector2 mouseLook;
	private Vector2 smooth;
	private bool invertMouse;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;	

	private GameObject character;

	void Start () {
		character = this.transform.parent.gameObject;
	}
	

	void Update () {
		var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));
		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));

		smooth.x = Mathf.Lerp (smooth.x, md.x, 1f / smoothing);
		smooth.y = Mathf.Lerp (smooth.y, md.y, 1f / smoothing);

		mouseLook += smooth;

		mouseLook.y = Mathf.Clamp (mouseLook.y, -90.0f, 90.0f);

		if (invertMouse)
			transform.localRotation = Quaternion.AngleAxis (mouseLook.y, Vector3.right);
		else
			transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);
	}

	public void sensitivitySetting (float newSensitivity){
		sensitivity = newSensitivity;
	}

	public void setInvertMouse (bool isOn){
		invertMouse = isOn;
	}
}

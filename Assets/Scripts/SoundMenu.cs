using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour {

	public AudioClip click;
	public AudioClip hover;
	public AudioSource source;

	public void OnClick (){
		source.PlayOneShot (click);
	}

	public void OnHover (){
		source.PlayOneShot (hover);
	}


}

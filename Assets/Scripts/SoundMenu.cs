using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour {

	public AudioClip click;
	public AudioClip hover;
	public AudioSource menusource;


	public void OnClick (){
		menusource.PlayOneShot (click);
	}

	public void OnHover (){
		menusource.PlayOneShot (hover);
	}



}

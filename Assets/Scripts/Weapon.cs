using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {


	public enum WeaponType
	{
		Sword,
		Gun
	};

	public WeaponType weaponType;
	public Texture weaponLogo = null;
	public float dmg = 0;



}



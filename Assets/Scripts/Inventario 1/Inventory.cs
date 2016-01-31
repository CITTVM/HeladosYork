using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public Transform weaponPos = null;
	public void ChangeWeapon(Weapon newWeapon)
	{
		//si hay arma destruirla
		if(currentWeaponGO != null)
			Destroy (currentWeaponGO);

		//isntanciando una nueva arma
		currentWeaponGO = GameObject.Instantiate(newWeapon.gameObject,Vector3.zero,Quaternion.identity) as GameObject;

		currentWeaponGO.transform.parent = weaponPos;

		currentWeaponGO.transform.position = weaponPos.position;
		//turn weapon so it has right rotation ( not always needed )
		//currentWeaponGO.transform.localRotation = Quaternion.Euler(75f,75f,75f);
	}



	public List<Weapon> myWeaponList = null;
	public Weapon currentWeapon = null;
	//We set all the values in a rect to 0 by default and we will set them in the inspector. After that let's test out how it works.
	public Rect guiAreaRect = new Rect(0,0,0,0);

	void OnGUI()
	{
		//begin guilayout area
		GUILayout.BeginArea(guiAreaRect);
		//begin vertical group. This means that everything under this will go from up to down
		GUILayout.BeginVertical();
		//loop throught the list of out weapons
		foreach(Weapon weapon in myWeaponList)
		{
			//check if we find something
			if(weapon != null)
			{
				//Do a gui button for every weapon we found on our weapon list. And make them draw their weaponLogos.
				if(GUILayout.Button(weapon.weaponLogo,GUILayout.Width(50),GUILayout.Height(50)))
				{
					//if we clicked the button it will but that weapon to our selected(equipped) weapon
					currentWeapon = weapon;
					//we pass this function the value from our clicked button's weapon.
					ChangeWeapon(weapon);
					Debug.Log(currentWeapon);
				}
			}
		}
		//We need to close vertical gpr and gui area group.
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}




	public GameObject currentWeaponGO = null;

	List<KeyCode> numberss = new List<KeyCode>{ KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
		KeyCode.Alpha4, KeyCode.Alpha5};


	void Update()
	{
		ChangeWeaponWithNumbers();
	}

	public void ChangeWeaponWithNumbers()
	{
		//loop throught our keycode list
		for(int i =0;i<numberss.Count;i++)
		{
			//check if whichever index keycode we have pressed
			if(Input.GetKeyDown(numberss[i]))
			{
				//set our currentWeapon to be same in our inventory as it is in our keycode list.
				currentWeapon = myWeaponList[i];
				// call weapon spawn function with that weapon.
				ChangeWeapon(myWeaponList[i]);
			}
		}
	}
































}


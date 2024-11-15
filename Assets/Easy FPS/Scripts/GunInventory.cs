﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public enum MenuStyle{
	horizontal,vertical
}

public class GunInventory : MonoBehaviour {
	public GameObject player;
	public bool CanMove=false;
	[Tooltip("Current weapon gameObject.")]
	public GameObject currentGun;
	private Animator currentHAndsAnimator;
	private int currentGunCounter = 0;
	public bool Possible=true;
	[Tooltip("Put Strings of weapon objects from Resources Folder.")]
	public List<string> gunsIHave = new List<string>();
	[Tooltip("Icons from weapons.(Fetched when you run the game)*MUST HAVE ICONS WITH CORRESPONDING NAMES IN RESOUCES FOLDER*")]
	public Texture[] icons;

	[HideInInspector]
	public float switchWeaponCooldown;
	public GunInventory guninventory;
	public bool GunBool=false;
	public GunPick gunpick;
	public bool IfKey=false;
	public bool IfCard=false;
	public int Emp=0;
	public int FakeBody=0;
	public int HealKit=0;
	public TextMeshProUGUI UiText;
    public GameObject UiObject;
	public PlayerHp playerhp;
	public AudioSource HealKitSound;

	/*
	 * Calling the method that will update the icons of our guns if we carry any upon start.
	 * Also will spawn a weapon upon start.
	 */
	void Awake(){
		
		StartCoroutine("UpdateIconsFromResources");

		StartCoroutine ("SpawnWeaponUponStart");//to start with a gun

		if (gunsIHave.Count == 0)
			print ("No guns in the inventory");
	}

	/*
	*Waits some time then calls for a waepon spawn
	*/
	IEnumerator SpawnWeaponUponStart(){
		yield return new WaitForSeconds (0.5f);
		StartCoroutine("Spawn",0);
	}

	/* 
	 * Calculation switchWeaponCoolDown so it does not allow us to change weapons millions of times per second,
	 * and at some point we will change the switchWeaponCoolDown to a negative value so we have to wait until it
	 * overcomes 0.0f. 
	 */
	void Update(){
		Emp=player.GetComponent<PlayerMovementScript>().Emp;
		FakeBody=player.GetComponent<PlayerMovementScript>().FakeBody;
		HealKit=player.GetComponent<PlayerMovementScript>().HealKit;

		if(CanMove){
			player.GetComponent<MouseLookScript>().enabled = false;
        	player.GetComponent<PlayerMovementScript>().enabled = false;
			CanMove=true;
		}
		switchWeaponCooldown += 1 * Time.deltaTime;
		if(switchWeaponCooldown > 1.2f && Input.GetKey(KeyCode.LeftShift) == false){
			Create_Weapon();
		}

	}


	/*
	 * Grabing the icons from the Resources/Weapo_Icons/ -> gun name of the image.
	 * (!!!!!!!1!READ IMPORTANT) 
	 * the weapon image to respond the weapon must have the same name as the WEAPON  with the extension _img.
	 * So if the gun prefab is called "Sniper_Piper" the corresponding image must be located in the location form previous,
	 * with the name "Sniper_Piper_img".
	 */
	IEnumerator UpdateIconsFromResources(){
		yield return new WaitForEndOfFrame ();

		icons = new Texture[gunsIHave.Count];
		for(int i = 0; i < gunsIHave.Count; i++){
			icons[i] = (Texture) Resources.Load("Weap_Icons/" + gunsIHave[i].ToString() + "_img");
		}

	}

	/*
	 * If used scroll mousewheel or arrows up and down the player will change weapon.
	 * GunPlaceSpawner is child of Player gameObject, where the gun is going to spawn and transition to our
	 * gun properties value.
	 */
	void Create_Weapon(){

		/*
		 * Scrolling wheel waepons changing
		 */
		 /*
		if(Input.GetAxis("Mouse ScrollWheel") > 0){
			switchWeaponCooldown = 0;
			
			currentGunCounter++;
			if(currentGunCounter > gunsIHave.Count-1){
				currentGunCounter = 0;
				
			}
			StartCoroutine("Spawn",currentGunCounter);
		}
		if(Input.GetAxis("Mouse ScrollWheel") < 0){
			switchWeaponCooldown = 0;

			currentGunCounter--;
			if(currentGunCounter < 0){
				currentGunCounter = gunsIHave.Count-1;
			}
			StartCoroutine("Spawn",currentGunCounter);
		}
		*/
		/*
		 * Keypad numbers
		 */
		if(Input.GetKeyDown(KeyCode.Alpha1) ){
			switchWeaponCooldown = 0;
			currentGunCounter = 0;
			
			StartCoroutine("Spawn",currentGunCounter);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2) &&GunBool){
			switchWeaponCooldown = 0;
			currentGunCounter = 1;
			StartCoroutine("Spawn",currentGunCounter);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3) && currentGunCounter != 4&&Emp>0){
			switchWeaponCooldown = 0;
			currentGunCounter = 4;
			StartCoroutine("Spawn",currentGunCounter);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3) && currentGunCounter != 2&&IfKey){
			switchWeaponCooldown = 0;
			currentGunCounter = 2;
			StartCoroutine("Spawn",currentGunCounter);
		}
		if(Input.GetKeyDown(KeyCode.Alpha4) && currentGunCounter != 3&&IfCard){
			switchWeaponCooldown = 0;
			currentGunCounter = 3;
			StartCoroutine("Spawn",currentGunCounter);
		}
		if(Input.GetKeyDown(KeyCode.Alpha4) && currentGunCounter != 5&&FakeBody>0){
			switchWeaponCooldown = 0;
			currentGunCounter = 5;
			StartCoroutine("Spawn",currentGunCounter);
		}
		if(Input.GetKeyDown(KeyCode.Alpha5) &&HealKit>0){
			UiObject.SetActive(true);
			UiText.text="Hp회복!";
			StartCoroutine(ExecuteAfterDelayText(3f)); 
			HealKit-=1;
			player.GetComponent<PlayerMovementScript>().HealKit--;
			playerhp.PlayerCurHp+=300f;
			playerhp.UpdateHealth(0);
			HealKitSound.Play();
			
		}
		

	}
	private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiObject.SetActive(false);
        
    }
	public void ChangeWeapon1(){
		switchWeaponCooldown = 0;
		StartCoroutine("Spawn",0);
	}
	public void ChangeWeapon2(){
		switchWeaponCooldown = 0;
		currentGunCounter = 1;
		StartCoroutine("Spawn",currentGunCounter);
	}
	/*
	 * This method is called from Create_Weapon() upon pressing arrow up/down or scrolling the mouse wheel,
	 * It will check if we carry a gun and destroy it, and its then going to load a gun prefab from our Resources Folder.
	 */
	IEnumerator Spawn(int _redniBroj){
		
		if (weaponChanging)
			weaponChanging.Play ();
		else
			print ("Missing Weapon Changing music clip.");
		if(currentGun){
			if(currentGun.name.Contains("Gun")){

				currentHAndsAnimator.SetBool("changingWeapon", true);

				yield return new WaitForSeconds(0.8f);//0.8 time to change waepon, but since there is no change weapon animation there is no need to wait fo weapon taken down
				Destroy(currentGun);

				GameObject resource = (GameObject) Resources.Load(gunsIHave[_redniBroj].ToString());
				currentGun = (GameObject) Instantiate(resource, transform.position, /*gameObject.transform.rotation*/Quaternion.identity);
				AssignHandsAnimator(currentGun);
			}
			else if(currentGun.name.Contains("Hand")){
				
				yield return new WaitForSeconds(0.6f);//1
				Destroy(currentGun);

				GameObject resource = (GameObject) Resources.Load(gunsIHave[_redniBroj].ToString());
				currentGun = (GameObject) Instantiate(resource, transform.position, /*gameObject.transform.rotation*/Quaternion.identity);
				AssignHandsAnimator(currentGun);
			}
			else if(currentGun.name.Contains("Key")){
				
				yield return new WaitForSeconds(0.6f);//1
				Destroy(currentGun);

				GameObject resource = (GameObject) Resources.Load(gunsIHave[_redniBroj].ToString());
				currentGun = (GameObject) Instantiate(resource, transform.position, /*gameObject.transform.rotation*/Quaternion.identity);
				AssignHandsAnimator(currentGun);
			}
			else if(currentGun.name.Contains("Card")){
				
				yield return new WaitForSeconds(0.6f);//1
				Destroy(currentGun);

				GameObject resource = (GameObject) Resources.Load(gunsIHave[_redniBroj].ToString());
				currentGun = (GameObject) Instantiate(resource, transform.position, /*gameObject.transform.rotation*/Quaternion.identity);
				AssignHandsAnimator(currentGun);
			}
			else if(currentGun.name.Contains("Emp")){
				
				yield return new WaitForSeconds(0.6f);//1
				Destroy(currentGun);

				GameObject resource = (GameObject) Resources.Load(gunsIHave[_redniBroj].ToString());
				currentGun = (GameObject) Instantiate(resource, transform.position, /*gameObject.transform.rotation*/Quaternion.identity);
				AssignHandsAnimator(currentGun);
			}
			else if(currentGun.name.Contains("FakeBody")){
				
				yield return new WaitForSeconds(0.6f);//1
				Destroy(currentGun);

				GameObject resource = (GameObject) Resources.Load(gunsIHave[_redniBroj].ToString());
				currentGun = (GameObject) Instantiate(resource, transform.position, /*gameObject.transform.rotation*/Quaternion.identity);
				AssignHandsAnimator(currentGun);
			}
		}
		else{
			GameObject resource = (GameObject) Resources.Load(gunsIHave[_redniBroj].ToString());
			currentGun = (GameObject) Instantiate(resource, transform.position, /*gameObject.transform.rotation*/Quaternion.identity);

			AssignHandsAnimator(currentGun);
		}


	}
	public bool currneguniskey(){return currentGun.name.Contains("Key");}
	public void PositiveKey(){IfKey=true;}
	public void NegativeKey(){IfKey=false;}
	public bool ReturnKey(){return IfKey;}
	public bool currneguniscard(){return currentGun.name.Contains("Card");}
	public void PositiveCard(){IfCard=true;}
	public void NegativeCard(){IfCard=false;}
	public bool ReturnCard(){return IfCard;}
	public bool IfHand(){
		if(currentGun){return currentGun.name.Contains("Hand");}
		else{return false;}
		
	}
	public bool IfGun(){return currentGun.name.Contains("Gun");}

	/*
	* Assigns Animator to the script so we can use it in other scripts of a current gun.
	*/
	void AssignHandsAnimator(GameObject _currentGun){
		if(_currentGun.name.Contains("Gun")){
			currentHAndsAnimator = currentGun.GetComponent<GunScript>().handsAnimator;
		}
	}

	/*
	 * Unity buil-in method to draw GUI.
	 * From here I am listing thourhg guns I have and drawing corresponding images on the sceen.
	 */
	void OnGUI(){

		if(currentGun){
			for(int i = 0; i < gunsIHave.Count; i++){
				DrawCorrespondingImage(i);
			}
		}

	}

	[Header("GUI Gun preview variables")]
	[Tooltip("Weapon icons style to pick.")]
	public MenuStyle menuStyle = MenuStyle.horizontal;
	[Tooltip("Spacing between icons.")]
	public int spacing = 10;
	[Tooltip("Begin position in percetanges of screen.")]
	public Vector2 beginPosition;
	[Tooltip("Size of icon in percetanges of screen.")]
	public Vector2 size;
	/*
	 * Passing the image number and gun list have the same sort,
	 * so it will fitthe gun image to our current gun or guns we have.
	 * The curent gun selected image has their image slightly enlared for some value.
	 */
	void DrawCorrespondingImage(int _number){
		/*
		string deleteCloneFromName = currentGun.name.Substring(0,currentGun.name.Length - 7);
		
		if(menuStyle == MenuStyle.horizontal){
			if(deleteCloneFromName == gunsIHave[_number]){
				GUI.DrawTexture(new Rect(vec2(beginPosition).x +(_number*position_x(spacing)),vec2(beginPosition).y,//position variables
					vec2(size).x, vec2(size).y),//size
					icons[_number]);
			}
			else{			
				GUI.DrawTexture(new Rect(vec2(beginPosition).x +(_number*position_x(spacing) + 10),vec2(beginPosition).y + 10,//position variables
					vec2(size).x - 20, vec2(size).y- 20),//size
					icons[_number]);
			}
		}
		else if(menuStyle == MenuStyle.vertical){
			if(deleteCloneFromName == gunsIHave[_number]){
				GUI.DrawTexture(new Rect(vec2(beginPosition).x,vec2(beginPosition).y +(_number*position_y(spacing)),//position variables
					vec2(size).x, vec2(size).y),//size
					icons[_number]);
			}
			else{			
				GUI.DrawTexture(new Rect(vec2(beginPosition).x,vec2(beginPosition).y + 10  +(_number*position_y(spacing)),//position variables
					vec2(size).x - 20, vec2(size).y- 20),//size
					icons[_number]);
			}
		}

*/

	}

	/*
	 * Call this method when player dies.
	 */
	public void DeadMethod(){
		Destroy (currentGun);
		Destroy (this);
	}


	//#####		RETURN THE SIZE AND POSITION for GUI images
	//(we pass in the percentage and it returns some number to appear in that percentage on the sceen) ##################
	private float position_x(float var){
		return Screen.width * var / 100;
	}
	private float position_y(float var)
	{
		return Screen.height * var / 100;
	}
	private float size_x(float var)
	{
		return Screen.width * var / 100;
	}
	private float size_y(float var)
	{
		return Screen.height * var / 100;
	}
	private Vector2 vec2(Vector2 _vec2){
		return new Vector2(Screen.width * _vec2.x / 100, Screen.height * _vec2.y / 100);
	}
	//######################################################

	/*
	 * Sounds
	 */
	[Header("Sounds")]
	[Tooltip("Sound of weapon changing.")]
	public AudioSource weaponChanging;
}

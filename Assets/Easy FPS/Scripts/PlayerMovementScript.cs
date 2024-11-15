﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementScript : MonoBehaviour {
	
	public int Emp=0;
	public int FakeBody=0;
	public int HealKit=0;
	public bool Upgrade=false;
	public bool Short=false;
	public int ChipInt=0;
	public float speed;
	Rigidbody rb;
	public GameObject player;
	public bool running=false;
	public bool runbool=false;
	public bool walking=false;
	public bool CanMove=false;
	[Tooltip("Current players speed")]
	public float currentSpeed;
	[Tooltip("Assign players camera here")]
	[HideInInspector]public Transform cameraMain;
	[Tooltip("Force that moves player into jump")]
	public float jumpForce = 500;
	[Tooltip("Position of the camera inside the player")]
	[HideInInspector]public Vector3 cameraPosition;
	public bool IfCross=false;
	public GameObject EmpUi;
	private bool pressing=false;
	public GameObject HealKitUi;
	public GameObject FakeBodyUi;
	
	/*
	 * Getting the Players rigidbody component.
	 * And grabbing the mainCamera from Players child transform.
	 */
	void Awake(){
		rb = GetComponent<Rigidbody>();
		cameraMain = transform.Find("Main Camera").transform;
		bulletSpawn = cameraMain.Find ("Attack").transform;
		ignoreLayer = 1 << LayerMask.NameToLayer ("Player");

	}
	private Vector3 slowdownV;
	private Vector2 horizontalMovement;
	/*
	* Raycasting for meele attacks and input movement handling here.
	*/
	void FixedUpdate(){
		RaycastForMeleeAttacks ();

		PlayerMovementLogic ();
	}
	/*
	* Accordingly to input adds force and if magnitude is bigger it will clamp it.
	* If player leaves keys it will deaccelerate
	*/
	void PlayerMovementLogic(){
		float horizontalInput = 0f;
		float verticalInput = 0f;
		float upSpeed=rb.velocity.y;
		
		if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))&&!pressing)
    	{
			
			
			if(!runbool){
				
				runbool=true;
			}else{
				
				runbool=false;
			}
			pressing=true;
		}else if((Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))&&pressing){
			
			pressing=false;
		}
		
		if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.right * -5;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * 5;
        }
		if (Input.GetKey(KeyCode.W))
        {
            
			if(runbool){running=true;speed=10f;}
			else{speed=5f;running=false;}
			rb.velocity = transform.forward * speed;
        }else{running=false;}
		if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = transform.forward * -5;
        }
		if (Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.A)){
			rb.velocity = (transform.forward*5+transform.right*-5);
		}
		if (Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.D)){
			rb.velocity = (transform.forward*5+transform.right*5);
		}
		if (Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.A)){
			rb.velocity = (transform.forward*-5+transform.right*-5);
		}
		if (Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.D)){
			rb.velocity = (transform.forward*-5+transform.right*5);
		}
		
		if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.W)){walking=true;}
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y,0);
			walking=false;
        }
		rb.velocity = new Vector3(rb.velocity.x, upSpeed,rb.velocity.z);
		
		if(running){
			if (!_runSound.isPlaying) {
				_walkSound.Stop ();
				_runSound.Play ();
			}
				
		}
		else if(walking){
			if (!_walkSound.isPlaying) {
							_walkSound.Play ();
							_runSound.Stop ();
			}
		}else{
			_walkSound.Stop();
			_runSound.Stop();
		}
		
	}
	public bool IfJumping=false;
	 private IEnumerator JumpSound()
    {
        JumpUp.Play();
		yield return new WaitForSeconds(0.1f);
        IfJumping=true;
		
		
	}
	void Jumping(){
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			rb.AddRelativeForce (Vector3.up * jumpForce);
			if (_jumpSound)
				StartCoroutine(JumpSound());
			else
				print ("Missig jump sound.");
			_walkSound.Stop ();
			_runSound.Stop ();
		}
	}
	/*
	* Update loop calling other stuff
	*/
	void Update(){
		if(Emp!=0){EmpUi.SetActive(true);}
		if(HealKit!=0){HealKitUi.SetActive(true);}
		if(FakeBody!=0){FakeBodyUi.SetActive(true);}

		/*
		if(CanMove){
			CanMove=false;
			player.GetComponent<MouseLookScript>().enabled = true;
            player.GetComponent<PlayerMovementScript>().enabled = true;
		}*/
		if(IfJumping){if(grounded==true){JumpDown.Play();IfJumping=false;}}

		Jumping ();

		Crouching();

		WalkingSound ();


	}//end update

	/*
	* Checks if player is grounded and plays the sound accorindlgy to his speed
	*/
	void WalkingSound(){
		/*
		if (_walkSound && _runSound) {
			if (RayCastGrounded ()) { //for walk sounsd using this because suraface is not straigh			
				if (currentSpeed > 1) {
					//				print ("unutra sam");
					if (maxSpeed == 3) {
						//	print ("tu sem");
						if (!_walkSound.isPlaying) {
							//	print ("playam hod");
							//_walkSound.Play ();
							_runSound.Stop ();
						}					
					} else if (maxSpeed == 10) {
						//	print ("NE tu sem");

						if (!_runSound.isPlaying) {
							_walkSound.Stop ();
							_runSound.Play ();
						}
					}
				} else {
					_walkSound.Stop ();
					_runSound.Stop ();
				}
			} else {
				_walkSound.Stop ();
				_runSound.Stop ();
			}
		} else {
			print ("Missing walk and running sounds.");
		}
	*/
	}
	/*
	* Raycasts down to check if we are grounded along the gorunded method() because if the
	* floor is curvy it will go ON/OFF constatly this assures us if we are really grounded
	*/
	private bool RayCastGrounded(){
		RaycastHit groundedInfo;
		if(Physics.Raycast(transform.position, transform.up *-1f, out groundedInfo, 1, ~ignoreLayer)){
			Debug.DrawRay (transform.position, transform.up * -1f, Color.red, 0.0f);
			if(groundedInfo.transform != null){
				//print ("vracam true");
				return true;
			}
			else{
				//print ("vracam false");
				return false;
			}
		}
		//print ("nisam if dosao");

		return false;
	}

	/*
	* If player toggle the crouch it will scale the player to appear that is crouching
	*/
	void Crouching(){
		
	}


	[Tooltip("The maximum speed you want to achieve")]
	public int maxSpeed;
	[Tooltip("The higher the number the faster it will stop")]
	public float deaccelerationSpeed = 15.0f;


	[Tooltip("Force that is applied when moving forward or backward")]
	public float accelerationSpeed = 50000.0f;


	[Tooltip("Tells us weather the player is grounded or not.")]
	public bool grounded;
	/*
	* checks if our player is contacting the ground in the angle less than 60 degrees
	*	if it is, set groudede to true
	*/
	void OnCollisionStay(Collision other){
		foreach(ContactPoint contact in other.contacts){
			if(Vector2.Angle(contact.normal,Vector3.up) < 60){
				grounded = true;
			}
		}
	}
	/*
	* On collision exit set grounded to false
	*/
	void OnCollisionExit ()
	{
		grounded = false;
	}
	public void UpChip(){ChipInt+=1;}
	

	RaycastHit hitInfo;
	private float meleeAttack_cooldown;
	private string currentWeapo;
	[Tooltip("Put 'Player' layer here")]
	[Header("Shooting Properties")]
	private LayerMask ignoreLayer;//to ignore player layer
	Ray ray1, ray2, ray3, ray4, ray5, ray6, ray7, ray8, ray9;
	private float rayDetectorMeeleSpace = 0.15f;
	private float offsetStart = 0.05f;
	[Tooltip("Put BulletSpawn gameobject here, palce from where bullets are created.")]
	[HideInInspector]
	public Transform bulletSpawn; //from here we shoot a ray to check where we hit him;
	/*
	* This method casts 9 rays in different directions. ( SEE scene tab and you will see 9 rays differently coloured).
	* Used to widley detect enemy infront and increase meele hit detectivity.
	* Checks for cooldown after last preformed meele attack.
	*/


	public bool been_to_meele_anim = false;
	private void RaycastForMeleeAttacks(){




		if (meleeAttack_cooldown > -5) {
			meleeAttack_cooldown -= 1 * Time.deltaTime;
		}


		if (GetComponent<GunInventory> ().currentGun) {
			if (GetComponent<GunInventory> ().currentGun.GetComponent<GunScript> ()) 
				currentWeapo = "gun";
		}

		//middle row
		ray1 = new Ray (bulletSpawn.position + (bulletSpawn.right*offsetStart), bulletSpawn.forward + (bulletSpawn.right * rayDetectorMeeleSpace));
		ray2 = new Ray (bulletSpawn.position - (bulletSpawn.right*offsetStart), bulletSpawn.forward - (bulletSpawn.right * rayDetectorMeeleSpace));
		ray3 = new Ray (bulletSpawn.position, bulletSpawn.forward);
		//upper row
		ray4 = new Ray (bulletSpawn.position + (bulletSpawn.right*offsetStart) + (bulletSpawn.up*offsetStart), bulletSpawn.forward + (bulletSpawn.right * rayDetectorMeeleSpace) + (bulletSpawn.up * rayDetectorMeeleSpace));
		ray5 = new Ray (bulletSpawn.position - (bulletSpawn.right*offsetStart) + (bulletSpawn.up*offsetStart), bulletSpawn.forward - (bulletSpawn.right * rayDetectorMeeleSpace) + (bulletSpawn.up * rayDetectorMeeleSpace));
		ray6 = new Ray (bulletSpawn.position + (bulletSpawn.up*offsetStart), bulletSpawn.forward + (bulletSpawn.up * rayDetectorMeeleSpace));
		//bottom row
		ray7 = new Ray (bulletSpawn.position + (bulletSpawn.right*offsetStart) - (bulletSpawn.up*offsetStart), bulletSpawn.forward + (bulletSpawn.right * rayDetectorMeeleSpace) - (bulletSpawn.up * rayDetectorMeeleSpace));
		ray8 = new Ray (bulletSpawn.position - (bulletSpawn.right*offsetStart) - (bulletSpawn.up*offsetStart), bulletSpawn.forward - (bulletSpawn.right * rayDetectorMeeleSpace) - (bulletSpawn.up * rayDetectorMeeleSpace));
		ray9 = new Ray (bulletSpawn.position -(bulletSpawn.up*offsetStart), bulletSpawn.forward - (bulletSpawn.up * rayDetectorMeeleSpace));

		Debug.DrawRay (ray1.origin, ray1.direction, Color.cyan);
		Debug.DrawRay (ray2.origin, ray2.direction, Color.cyan);
		Debug.DrawRay (ray3.origin, ray3.direction, Color.cyan);
		Debug.DrawRay (ray4.origin, ray4.direction, Color.red);
		Debug.DrawRay (ray5.origin, ray5.direction, Color.red);
		Debug.DrawRay (ray6.origin, ray6.direction, Color.red);
		Debug.DrawRay (ray7.origin, ray7.direction, Color.yellow);
		Debug.DrawRay (ray8.origin, ray8.direction, Color.yellow);
		Debug.DrawRay (ray9.origin, ray9.direction, Color.yellow);

		if (GetComponent<GunInventory> ().currentGun) {
			if (GetComponent<GunInventory> ().currentGun.GetComponent<GunScript> ().meeleAttack == false) {
				been_to_meele_anim = false;
			}
			if (GetComponent<GunInventory> ().currentGun.GetComponent<GunScript> ().meeleAttack == true && been_to_meele_anim == false) {
				been_to_meele_anim = true;
				//	if (isRunning == false) {
				StartCoroutine ("MeeleAttackWeaponHit");
				//	}
			}
		}

	}

	/*
	 *Method that is called if the waepon hit animation has been triggered the first time via Q input
	 *and if is, it will search for target and make damage
	 */
	IEnumerator MeeleAttackWeaponHit(){
		if (Physics.Raycast (ray1, out hitInfo, 2f, ~ignoreLayer) || Physics.Raycast (ray2, out hitInfo, 2f, ~ignoreLayer) || Physics.Raycast (ray3, out hitInfo, 2f, ~ignoreLayer)
			|| Physics.Raycast (ray4, out hitInfo, 2f, ~ignoreLayer) || Physics.Raycast (ray5, out hitInfo, 2f, ~ignoreLayer) || Physics.Raycast (ray6, out hitInfo, 2f, ~ignoreLayer)
			|| Physics.Raycast (ray7, out hitInfo, 2f, ~ignoreLayer) || Physics.Raycast (ray8, out hitInfo, 2f, ~ignoreLayer) || Physics.Raycast (ray9, out hitInfo, 2f, ~ignoreLayer)) {
			//Debug.DrawRay (bulletSpawn.position, bulletSpawn.forward + (bulletSpawn.right*0.2f), Color.green, 0.0f);
			if (hitInfo.transform.tag=="Dummie") {
				Transform _other = hitInfo.transform.root.transform;
				if (_other.transform.tag == "Dummie") {
					print ("hit a dummie");
				}
				InstantiateBlood(hitInfo,false);
			}
		}
		yield return new WaitForEndOfFrame ();
	}

	[Header("BloodForMelleAttaacks")]
	RaycastHit hit;//stores info of hit;
	[Tooltip("Put your particle blood effect here.")]
	public GameObject bloodEffect;//blod effect prefab;
	/*
	* Upon hitting enemy it calls this method, gives it raycast hit info 
	* and at that position it creates our blood prefab.
	*/
	void InstantiateBlood (RaycastHit _hitPos,bool swordHitWithGunOrNot) {		

	}
	private GameObject myBloodEffect;


	[Header("Player SOUNDS")]
	[Tooltip("Jump sound when player jumps.")]
	public AudioSource _jumpSound;
	public AudioSource JumpUp;
	public AudioSource JumpDown;
	[Tooltip("Sound while player makes when successfully reloads weapon.")]
	public AudioSource _freakingZombiesSound;
	[Tooltip("Sound Bullet makes when hits target.")]
	public AudioSource _hitSound;
	[Tooltip("Walk sound player makes.")]
	public AudioSource _walkSound;
	[Tooltip("Run Sound player makes.")]
	public AudioSource _runSound;
}


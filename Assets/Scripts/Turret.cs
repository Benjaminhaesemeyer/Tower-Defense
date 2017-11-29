using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	private Transform target; //Variable to store current target
	private Enemy targetEnemy; //Enemy to target

	[Header("General")]
	public float range = 12f; //The turrets shooting range

	[Header("Use Bullets (default)")]
	public GameObject bulletPrefab; //Bullet model 
	public float fireRate = 1f; //Speed of bullets
	private float fireCountdown = 0f; //Time till next bullet fires

	[Header("Use Laser")]
	public bool useLaser = false; //default for use of laser
    //Damage and slow effect of laser
	public int damageOverTime = 30;
	public float slowAmount = .5f;
    //Design variables of laser
	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect;
	public Light impactLight;

	[Header("Unity Setup Fields")]
	public string enemyTag = "Enemy"; //Enemy tag reference 

    public Transform partToRotate; //Turret head to swivel
	public float turnSpeed = 8f; //Speed the head swivels at

	public Transform firePoint; //End of the barrel

	// Use this for initialization
	void Start () {
        InvokeRepeating ("UpdateTarget", 0f, 0.5f); //Call UpdateTarget 2X a second

	}

    void UpdateTarget () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag); //Finding all enemies in the scene
		float shortestDistance = Mathf.Infinity; //Finding closest enemy 
		GameObject nearestEnemy = null; //Store nearest enemy found here
		foreach (GameObject enemy in enemies) { //Checking through each enemy in enemies array
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position); //Get distance of each enemy found
			if (distanceToEnemy < shortestDistance) { //Check to see if enemy is closer than current closest enemy
				shortestDistance = distanceToEnemy; //Assigning closest enemy found so far
                nearestEnemy = enemy; //Closest enemy set to enemy to target
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) //If we find an enemy that is within our turrets range
		{
			target = nearestEnemy.transform; //Set target to nearest enemy's transform
			targetEnemy = nearestEnemy.GetComponent<Enemy> ();
		}  
		else{
			target = null; //If there is'nt an enemy in range don't target anything
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) { //If we dont have a target disable laserbeam visual effect
			if (useLaser) {
				if (lineRenderer.enabled) {
					lineRenderer.enabled = false;
					impactEffect.Stop ();
					impactLight.enabled = false;
				}
			}
			return;
		}
        //In this case target isn't null
		LockOnTarget (); //Have the turret track the target 

		if (useLaser) { 
            Laser (); //If turret uses a laser run this
		} 
		else { //If turret doesn't use a laser
			if(fireCountdown <= 0f) {
				Shoot ();
				fireCountdown = 1f / fireRate;
			}
			fireCountdown -= Time.deltaTime;
		}	
	}
    //Function for laserbeam turret
	void Laser() {

		targetEnemy.TakeDamage (damageOverTime * Time.deltaTime); //Damage to inflict on enemy over time
		targetEnemy.Slow(slowAmount); //Slowing down enemy movement speed

		if (!lineRenderer.enabled) { //Render the laserbeam line effect
			lineRenderer.enabled = true;
			impactEffect.Play ();
			impactLight.enabled = true;
		}
		lineRenderer.SetPosition (0, firePoint.position);
		lineRenderer.SetPosition (1, target.position);

		Vector3 dir = firePoint.position - target.position; //Finding line direction from gun barrel to enemy 

		impactEffect.transform.position = target.position + dir.normalized; //laser imapact effect tracked to enemy movement

		impactEffect.transform.rotation = Quaternion.LookRotation (dir); //Proper rotated orientation for impact effect in relation to enemy

	}

	void LockOnTarget(){
		//Target lock on
		Vector3 dir = target.position - transform.position; //Creating direction between turret and target
		Quaternion lookRotation = Quaternion.LookRotation (dir); //Proper rotation towards target
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //Rotation speed and smoothness
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); //Getting the head piece of turret to rotate
	}
    //Function for turrets that shoot projectiles
	void Shoot(){
		GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet> ();

		if (bullet != null)
			bullet.Seek (target);
	}
	//Creating a visual for displaying the range of the turrets in the editor
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}

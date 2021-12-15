using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptGun : MonoBehaviour

{   
    public GameObject PlayerController;
    //public GameObject ObjectReference;
    public AudioSource _audioSource;
    public PauseMenu PauseMenu;
    public Animator AnimationWeapon;

    public float damage = 20f;
    public float  range = 200f;
    public float fireRate = 30f;
    public float reloadTime = 2f;
    public int capacityAmmo = 5;
    public int maxAmmo;
    public int idWeapon;
    public string nameAnimationShot;
    public string nameAnimationReload;

    public Camera fpsCamera;
    public Text ammocount;

    public ParticleSystem flashWeapon;
    //public GameObject impactEffect;
    private int currentAmmo;
    private float nextTimeToFire = 0f;
    public bool isReloading = false;

    private void Awake() {
        AnimationWeapon.SetBool("Recargar", false);
        AnimationWeapon.SetBool("InicioCorrer", false);
        AnimationWeapon.SetBool("FinalCorrer", false);

        PlayerController.GetComponent<PlayerController>().getAnimator(AnimationWeapon);
    }

    void Start() 
    {
        currentAmmo = capacityAmmo;
        ammocount.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
    }

    void OnEnable() 
    {
        isReloading = false;
        WeaponBobbingV3._reloading = false;
        //ObjectReference.transform.position = new Vector3(0,0,0);
        //ObjectReference.transform.rotation = new Vector3(0,0,0);
    }
    // Update is called once per frame}

    void Update()
    {
        ammocount.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
        if (isReloading)
            return;

        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            if (maxAmmo > 0 && currentAmmo != capacityAmmo )
            {
                StartCoroutine(Reload());
                return;
            }
        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !(PauseMenu._isGamePaused) && 0 < currentAmmo )
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        

        isReloading = true;
        AnimationWeapon.Play(nameAnimationReload);

        //Debug.Log("*procede a recargar*");
        //WeaponBobbingV3._reloading = true;
        yield return new WaitForSeconds(reloadTime);
        //Debug.Log("*termine de recargar*");
        //WeaponBobbingV3._reloading = false;

        if (maxAmmo > (capacityAmmo - currentAmmo))
        {
            maxAmmo = maxAmmo - (capacityAmmo - currentAmmo);
            currentAmmo = capacityAmmo;
        }
        else
        {
            currentAmmo = currentAmmo + maxAmmo;
            maxAmmo = 0;
        }
        

        
        isReloading = false;
        //AnimationWeapon.SetBool("Recargar", false);
        
    }

    void Shoot()
    {
        AnimationWeapon.Play(nameAnimationShot);
        _audioSource.Play();
        flashWeapon.Play();
        //Debug.Log(currentAmmo);
        currentAmmo--;

        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hitInfo, range))
        {
            //Debug.Log("*le dispara*");

            ShooterEnemy target = hitInfo.transform.GetComponent<ShooterEnemy>();
            ShooterBoss targetBoss = hitInfo.transform.GetComponent<ShooterBoss>();
            MeleEnemy targetMelee = hitInfo.transform.GetComponent<MeleEnemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            else if( targetBoss != null)
            {
                targetBoss.TakeDamage(damage);
            }
            else if( targetMelee != null)
            {
                targetMelee.TakeDamage(damage);
            }

            //GameObject impactGO = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            //Destroy(impactGO, 1f);
            
        }
        
    }
}

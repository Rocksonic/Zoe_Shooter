using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //public CharacterController Character_Controller;
    public Camera FirstPersonCamera;
    public Transform playerBody;
    public CharacterController cH;
    [SerializeField]
    public WeaponBobbingV3 weaponBobbing;
    public WeaponBobbingV3 weaponBobbing2;

    private Animator AnimationWeapon;

    public float maxHealth;
    public float Movement_Speed;
    public float _jumpSpeed;
    [Range(0.01f, 150f)]
    public float Sensitivity;
    public float gravity_Multiplier;
    public float h;
    public float v;
    public float gravity;

    public Vector3 moveDirection;
    public Vector3 speedForce;
    public Vector3 _fallingVelocity;

    private float xRotation = 0f;
    private float mouseX;
    private float mouseY;
    public float currentHealth;
    public int kills = 0;
    public AudioSource audioSource;

    public GameObject damageMarker;

    void Start()
    {
        audioSource=this.gameObject.GetComponent<AudioSource>();
        //Set gravity and lock the cursor
        currentHealth = maxHealth;
        gravity = -9.81f;
        Cursor.lockState = CursorLockMode.Locked;
        CoinsText.ModifyCoinText();
        HealthScript.UpdateHealthBar();
    }


    // Update is called once per frame
    void Update()
    {
        //We call the 2 most important methods
        MovePlayer();
        MoveCamera();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        HealthScript.UpdateHealthBar();
        StartCoroutine("DamageMarker");
        
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void TakeHealing(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth,0, maxHealth);
        HealthScript.UpdateHealthBar();
    }

    void Die()
    {
        SceneManager.LoadScene ("muerte");
        //Debug.Log("me mori");
    }

    void MoveCamera()
    {
        mouseX = (Input.GetAxis("Mouse X") * Sensitivity) * Time.deltaTime;
        
        mouseY = (Input.GetAxis("Mouse Y") * Sensitivity) * Time.deltaTime;
        
        xRotation -= mouseY;
        
        xRotation = Mathf.Clamp(xRotation,-90f, 90f);

        FirstPersonCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        playerBody.Rotate(Vector3.up * mouseX);
    }

    //Character Movement using Character Controller, not change of position.
    void MovePlayer()
    {
        //Detecting Axis inputs for movement
        h = Input.GetAxis("Horizontal") * Movement_Speed;
        v = Input.GetAxis("Vertical") * Movement_Speed;
        
        if ((v != 0) || (h != 0))
        {
            weaponBobbing._go = true;
            weaponBobbing2._go = true;
            AnimationWeapon.SetBool("InicioCorrer", true);
            AnimationWeapon.SetBool("FinalCorrer", false);

        }

        else
        {
            AnimationWeapon.SetBool("FinalCorrer", true);
            AnimationWeapon.SetBool("InicioCorrer", false);  
            weaponBobbing._go = false;
            weaponBobbing2._go = false;
        }
        
        if (weaponBobbing._go && !audioSource.isPlaying) audioSource.Play(); // if player is moving and audiosource is not playing play it
            if (!weaponBobbing._go) audioSource.Stop(); // if player is not moving and audiosource is playing stop it
                
        
        //This vector3 controls the direction of the movement, it works, dont ask, just enjoy it.
        moveDirection = transform.right * h + transform.forward * v;

        //Check if it's falling and its vertical velocity, if its grounded and the falling velocity is lower than 0, we reset it
        if (cH.isGrounded && _fallingVelocity.y < 0)
        {
            _fallingVelocity.y = 0f;
        }
        
        //Detecting jump input and aplaying jump
        if (Input.GetButton("Jump") && cH.isGrounded)
        {
            _fallingVelocity.y = Mathf.Sqrt(_jumpSpeed * -2 * gravity);
        }
        
        // Aplaying axis movement
        cH.Move(moveDirection * Time.deltaTime);

        _fallingVelocity.y += gravity * gravity_Multiplier * Time.deltaTime;
        
        //Aplaying falling movement
        cH.Move(_fallingVelocity * Time.deltaTime);
    }

    public void resetKills()
    {
        kills = 0;
    }

    public void getAnimator(Animator x) 
    {
        AnimationWeapon = x;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.ModifyCoinAmount(1);
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Parts"))
        {
            GameManager.ModifyPartsAmount(1);
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Parts2"))
        {
            GameManager.ModifyParts2Amount(1);
            Destroy(other.gameObject);
        }
    }

    IEnumerator DamageMarker()
    {
        damageMarker.SetActive(true);
        yield return 0.4f;
        damageMarker.SetActive(false);
    }
}
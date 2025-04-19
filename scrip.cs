using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class scrip : MonoBehaviour
{
    NewControls controls;
    Rigidbody2D rb;
    private float direction=0;

    private float coolDownTimer = Mathf.Infinity;
    bool canAttack = false;

    private AudioSource adSource;
    public AudioClip clip;

    // Public Variables
    [SerializeField] float movespeed;
    [SerializeField] Transform pos;
    [SerializeField] GameObject prefab;
    [SerializeField] float velocity;
    [SerializeField] float attackCooldown;

   
    void Start()
    {
        // Fatching Components
        adSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        // Accessing The Input System Control Script
        controls = new NewControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {

            direction = ctx.ReadValue<float>();
        
        
        };
    }

    // Update is called once per frame
    void Update()
    {

        // CoolDownTimer and Checking The Attack Permission
        coolDownTimer += Time.deltaTime;
        if (coolDownTimer > attackCooldown)
        {
            canAttack = true;
        }


        // Cannon Movement between Specified Space and Transform Back if Exceeded the Certain Range with velocity becoming zero

        if (rb.position.y >= -3.1f && rb.position.y <= 7.8f)
        {
            
            rb.velocity = new Vector2(0f, direction * movespeed);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.transform.position = new Vector2(rb.position.x,Mathf.Clamp(rb.position.y,-3.06f,7.8f)); // Range with Mathf.clamp
        }
       


    }


    // Attack Function with OnClick Component
    public void shoot()
    {
        if (canAttack)
        {

            var obj = Instantiate(prefab, pos.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * velocity);
            Destroy(obj, 5f);
            adSource.PlayOneShot(clip);
            canAttack = false;
            coolDownTimer = 0;


        }
    }
    ~scrip(){

        controls.Disable();
    }
}

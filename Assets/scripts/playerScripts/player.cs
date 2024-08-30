using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;


public class player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform playerPos;
    [SerializeField] Transform cameraPos;
    [SerializeField] int jumpsLeft;
    [SerializeField] int jumpsMax;
    [SerializeField] Sprite standing;
    [SerializeField] Sprite crouching;
    [SerializeField] bool isCrouching;
    [SerializeField] SpriteRenderer sp;
    [SerializeField] Collider2D col;

    public int maxHp;
    public int hp;


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        playerPos = GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        jumpsLeft = 1;
        jumpsMax = 1;    
    }

    // Update is called once per frame
    void Update()
    {

        #region BasicFunctionsCalls
        if (Input.GetButtonDown("Fire1"))
        {
            Jump();
        }


        if (Input.GetButton("Fire2"))
        {
            Crouch();
        }
        if (hp <= 0)
        {
            PlayerDeath();
        }

        #endregion
    }

    void FixedUpdate()
    {
        // Movimento sempre para a direita
        rb.velocity = new Vector2(speed, rb.velocity.y);

        //Camera seguindo o player

        cameraPos.transform.position = new Vector3 (playerPos.position.x + 2.5f, playerPos.position.y + 3 ,-10);


        
        




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jumpsLeft = jumpsMax;
        }


        if(collision.gameObject.tag == "obstacle1")
        {
            hp--;

        }
    }









    void Jump()
      {
       if (jumpsLeft > 0)
       {

            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpsLeft--;

       }

      }

    void Crouch()
    {
        if(isCrouching == true)
        {

            sp.sprite = crouching;

        }



    }

    void PlayerDeath()
    {
        speed = 0;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


}

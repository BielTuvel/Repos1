using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //Animação
    public Animator anime;
    public Rigidbody2D playerRigidbody;
    public int forceJump;
    public int forceJump2;
    //Pulo
    public Transform GroundCheck;
    public bool grounded;
    public LayerMask whatIsGround;
    //Vida
    public Image barra;
    //Andar
    public float speed;
    private float x;
    //Pos Player
    public static float playerPos;
    //Vida
    private int vidas = 3;
   

    void Start()
    {
        
    }

    void Update()
    {

        playerPos = transform.position.x;

        //Pulo
        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.1f, whatIsGround);
        anime.SetBool("jump", !grounded);

        if (!grounded)
        {
            forceJump = 0;
            forceJump2 = 0;
        }
        else
        {
            forceJump = 700;
            forceJump2 = 1015;

            if (Input.GetButtonDown("Vertical"))
            {
                playerRigidbody.AddForce(new Vector2(0, forceJump2));
            }
            else if (Input.GetButtonDown("Jump"))
            {
                playerRigidbody.AddForce(new Vector2(0, forceJump));
            }
        }

        //Andar
        x = transform.position.x;
        x += speed * Time.deltaTime;
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
           // transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
          //  transform.eulerAngles = new Vector2(0, 180);
        }

        if (transform.position.x <= -8.61)
        {
           transform.position = new Vector2(-8.61f, transform.position.y);
        }
        else if (transform.position.x >= -6.655f)
        {
            transform.position = new Vector2(-6.655f, transform.position.y);
        }

    }

    //Colisões
    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == "bomba")
        {
            BombController.bombasColetadas++;
           
        }

        if (outro.tag == "hole")
        {
            barra.fillAmount -= 0.050f;
            BombController.bombasColetadas--;
            if (barra.fillAmount <= 0)
            {
                vidas--;
                barra.fillAmount = 1;
                if (vidas <= 0)
                {
                    Application.LoadLevel(Application.loadedLevel);
                    Score.scoreValue = 0;
                }
            }
        }

        if (outro.tag == "bulletEnemy2")
        {
            barra.fillAmount -= 0.050f;
            if (barra.fillAmount <= 0)
            {
                vidas--;
                barra.fillAmount = 1;
                if (vidas <= 0)
                {
                    Application.LoadLevel(Application.loadedLevel);
                    Score.scoreValue = 0;
                }
            }
        }

        if (outro.tag == "bulletEnemy1")
        {
            barra.fillAmount -= 0.050f;
            if (barra.fillAmount <= 0)
            {
                vidas--;
                barra.fillAmount = 1;
                if (vidas <= 0)
                {
                    Application.LoadLevel(Application.loadedLevel);
                    Score.scoreValue = 0;
                }
            }
        }
    }
}
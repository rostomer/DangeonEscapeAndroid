using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;

    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private Vector2 jumpForce = new Vector2(0, 5f);

    [SerializeField]
    private LayerMask groundLayer;

    private bool isGrounded;

    private float horizontalMovement;

    private PlayerAnimations playerAnims;
    private RaycastHit2D hit;

    //Заглушка
    //private bool _isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        playerAnims = GetComponent<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    void FixedUpdate()
    {
        Movement();
        Jumping();
        Attack();

        playerAnims.RunningAnimation();
        playerAnims.Flip(horizontalMovement);
    }

    private void Movement()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        _rigidbody2D.velocity = new Vector2(horizontalMovement * movementSpeed, _rigidbody2D.velocity.y);

        Debug.Log(horizontalMovement);

    }

    private void Jumping()
    {
        // Луч, параметры - начальная позиция, направление, длина и слой.
        hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, groundLayer.value);
        // Отрисовывает луч. Параметры: начальная позиция луча, направление луча, цвет луча. 
        Debug.DrawRay(transform.position, Vector2.down * 0.7f, Color.green);

        if (hit.collider != null)
        {

            float distance = hit.point.y;

            isGrounded = true;

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                _rigidbody2D.velocity = jumpForce;

                StartCoroutine(DisableRayCourotine());
            }
        }
        else
        {
            isGrounded = false;
        }

        playerAnims.JumpAnimation(isGrounded);
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            playerAnims.IdleAttackAnimation();
            playerAnims.SwordArcAnimation();
        }
    }

    IEnumerator DisableRayCourotine()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer.value);

        yield return new WaitForSeconds(0.15f);

        hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, groundLayer.value);
    }


}

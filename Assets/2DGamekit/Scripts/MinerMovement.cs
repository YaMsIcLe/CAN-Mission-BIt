using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gamekit2D
{
    public class MinerMovement : MonoBehaviour
    {
        public bool test;
        private bool facingRight = true;
        public float maxSpeed = 10;
        private Rigidbody2D rb;
        private Animator animator;
        private PlayerInput pInput;
        private bool jump;
        public int numJumps = 1;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            pInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            if (rb.velocity.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (rb.velocity.x < 0 && facingRight)
            {
                Flip();
            }

            if (rb.velocity.y > 0)
            {
                numJumps = 0;
            }
            else if (rb.velocity.y == 0)
            {
                numJumps = 1;
            }

            if (pInput.Jump.Down && numJumps > 0)
            {
                jump = true;
            }

            animator.SetBool("isWalking", rb.velocity.x != 0);
            animator.SetBool("isJumping", rb.velocity.y != 0);
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, rb.velocity.y);

            if (jump)
            {
                rb.AddForce(new Vector2(0, 1000));
                numJumps--;
                jump = false;
            }
        }

        private void Jump()
        {
            Debug.Log(Input.GetAxis("Space"));
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}


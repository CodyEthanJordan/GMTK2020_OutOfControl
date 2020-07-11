using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shooter
{
    public class ShooterController : MonoBehaviour
    {
        public float Speed = 10;
        public float Jump = 10;
        public float ShootSpeed = 0.5f;
        public float BulletSpeed = 10;
        public float KnockbackStrength;
        public GameObject BulletPrefab;
        public float ControlLossTime = 1;
        public bool InControl = true;

        [SerializeField]
        private Transform groundCheck;
        [SerializeField]
        private Transform bulletSpawn;

        private Rigidbody2D rb;
        private SpriteRenderer sr;

        private Vector2 move = Vector2.zero;
        private bool jump = false;
        private float shootTimer = 0;
        private float controlTimer = float.NegativeInfinity;
        private Vector3 spawnPoint;
        private bool goingRight = true;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            spawnPoint = bulletSpawn.transform.position;
        }

        private void Update()
        {
            if(InControl)
            {
                HandleInput();
            }
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(move.x * Speed, rb.velocity.y);
            if(jump)
            {
                if(Grounded)
                {
                    rb.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
                }

                jump = false;
            }
        }
        
        public void OutOfControl()
        {
            sr.color = Color.red;
            InControl = false;
            StartCoroutine(RegainingControl());
        }

        IEnumerator RegainingControl()
        {
            yield return new WaitForSeconds(ControlLossTime);
            sr.color = Color.white;
            InControl = true;
        }

        public bool Grounded
        {
            get
            {
                var hit = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
                if(hit is null || hit.Length == 0)
                {
                    return false;
                }
                else if(hit.Any(h => h.gameObject.CompareTag("Terrain")))
                {
                    return true;
                }

                return false;
            }
        }

        private void HandleInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            move = new Vector2(x, 0).normalized;

            if(x >= 0.2)
            {
                goingRight = true;
            }
            else if (x <= -0.2)
            {
                goingRight = false;
            }

            if(Input.GetButtonDown("Jump"))
            {
                jump = true;
            }

            shootTimer -= Time.deltaTime;
            if(Input.GetButton("Fire") && shootTimer <= 0)
            {
                shootTimer = ShootSpeed;
                Vector3 pos;
                if(goingRight)
                {
                    pos = bulletSpawn.transform.position;
                }
                else
                {
                    pos = -this.transform.position + bulletSpawn.transform.position;
                    pos = this.transform.position - 2 * pos;
                }
                var go = Instantiate(BulletPrefab, pos, Quaternion.identity);
                if(goingRight)
                {
                    go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * BulletSpeed, ForceMode2D.Impulse);
                }
                else
                {

                    go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * BulletSpeed, ForceMode2D.Impulse);
                }
            }

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Powerup") && InControl)
            {
                var p = collision.gameObject;
                OutOfControl();
                var knockAway = (collision.gameObject.transform.position - this.transform.position).normalized * KnockbackStrength;
                p.GetComponent<Rigidbody2D>().AddForce(knockAway, ForceMode2D.Impulse);
                //TODO: should this destroy it?
                Destroy(collision.gameObject);
            }
        }
    }
}

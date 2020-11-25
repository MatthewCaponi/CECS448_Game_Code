using Assets.HeroEditor.Common.CharacterScripts;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonsterImpactController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SkeletonAnimation animation;
    private EnemyMovementController enemyMovement;
    
    private GameObject player;
    private GameObject HPBar;
    private float playerPos;
    private float distanceToPlayer;
    private float distancePercent;
    private bool missed = false;
    private bool isHit = false;
    public ParticleSystem glow;
    public int deathEffect;
    // Start is called before the first frame update

    [SerializeField] GameObject Hitbox; 

    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animation = gameObject.GetComponent<SkeletonAnimation>();
        enemyMovement = gameObject.GetComponent<EnemyMovementController>();
        player = GameObject.Find("Player");
        HPBar = GameObject.Find("HP Bar Green");
        Hitbox = GameObject.Find("LightningEnchant");
  
    }

    private void Update()
    {
        if (!PauseMenu.IsPaused)
        {
          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            //Debug.Log("Enemy collided with barrier");
            DestroyEnemy();
        }

        if (collision.gameObject.layer == 15 && gameObject.layer == 19)
        {
            gameObject.GetComponent<SkeletonAnimation>().AnimationName = "Attack";
        }


        if (collision.gameObject.layer == 9 && gameObject.layer == 19 && !isHit)
        {
            //Debug.Log("Player Got hit");
            player.GetComponent<PlayerStateController>().subtractHP(20);
            HPBar.GetComponent<Image>().fillAmount = (float)player.GetComponent<PlayerStateController>().currentHP / player.GetComponent<PlayerStateController>().MaxHP;
        }
        else if (collision.gameObject.layer == 9 && !isHit)
        {
            //Debug.Log("Player Got hit by obstacle");
            player.GetComponent<PlayerStateController>().subtractHP(10);
            HPBar.GetComponent<Image>().fillAmount = (float)player.GetComponent<PlayerStateController>().currentHP / player.GetComponent<PlayerStateController>().MaxHP;
        }

        else if (collision.gameObject.layer == 16 && !isHit && (gameObject.layer != 19))
        {
            if (collision.gameObject.name == "BottomMissBox")
            {
                ScoreUIManager.instance.ScoreHit(1, transform.position);
                player.GetComponent<PlayerStateController>().subtractHP(5);
                HPBar.GetComponent<Image>().fillAmount = (float)player.GetComponent<PlayerStateController>().currentHP / player.GetComponent<PlayerStateController>().MaxHP;
            }
            else if (collision.gameObject.name == "TopMissBox" && !isHit)
            {
               ScoreUIManager.instance.ScoreHit(1, transform.position);
               player.GetComponent<PlayerStateController>().subtractHP(5);
               HPBar.GetComponent<Image>().fillAmount = (float)player.GetComponent<PlayerStateController>().currentHP / player.GetComponent<PlayerStateController>().MaxHP;
            }
            else if (collision.gameObject.layer == 12)
            {
                DestroyEnemy();
            }
        }


        if (collision.gameObject.layer == 13 && player.GetComponent<WeaponControls>().Attacking && !isHit)
        {
            if (gameObject.layer == 19)
            {
                gameObject.GetComponent<SkeletonAnimation>().AnimationName = "Attack";
            }
            else
            {
                GetComponent<Collider2D>().enabled = false;
                //Debug.Log("is hit");
                isHit = true;
                PlayDeathDeathEffect();
                enemyMovement.StopMovement();
                animation.AnimationName = "Dead";

                rigid.bodyType = RigidbodyType2D.Dynamic;
                rigid.mass = 1f;
                rigid.gravityScale = 10;
                transform.parent = null;
                //rigid.AddForce(new Vector2(-5, 20), (ForceMode2D)ForceMode.VelocityChange);
                rigid.AddTorque(13);
                rigid.velocity = new Vector2(-15, 35);

                Vector3 distance = new Vector3(
                    this.transform.position.x - Hitbox.transform.position.x,
                    this.transform.position.y - Hitbox.transform.position.y,
                    this.transform.position.z - Hitbox.transform.position.z);


                double distanceX = Math.Abs(distance.x);
                //Debug.Log(distanceX);
                if (distanceX >= 1.25) //ok
                {
                    Invoke("Obliterate", .1f);
                    ScoreUIManager.instance.ScoreHit(2, transform.position);
                }
                else if (distanceX > .75 && distanceX <= 1.25) //good
                {
                    Invoke("Obliterate", .1f);
                    ScoreUIManager.instance.ScoreHit(3, transform.position);
                }
                else if (distanceX <= .75) //perfect
                {
                    Invoke("Obliterate", .1f);
                    ScoreUIManager.instance.ScoreHit(4, transform.position);
                }



                player.GetComponent<PlayerStateController>().addHP(5);
                //Debug.Log("healed");
                HPBar.GetComponent<Image>().fillAmount = (float)player.GetComponent<PlayerStateController>().currentHP / player.GetComponent<PlayerStateController>().MaxHP;

            }
        }
            
    }

    

    private void Obliterate()
    {
        glow.Play();
        Invoke("DestroyEnemy", .35f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void PlayDeathDeathEffect()
    {
        //int rand = UnityEngine.Random.Range(1, SoundManager.instance.HitEffects.Length);
        //SoundManager.instance.Audio.Stop();
        SoundManager.instance.Audio.PlayOneShot(SoundManager.instance.HitEffects[5]);
        //Debug.Log(SoundManager.instance.Audio.clip.name);
    }
}

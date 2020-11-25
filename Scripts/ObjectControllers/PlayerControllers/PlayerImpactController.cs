using Assets.HeroEditor.Common.CharacterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpactController : MonoBehaviour
{
    Rigidbody2D rigid;
    BoxCollider2D collider;
    WeaponControls weaponController;
    [SerializeField] GameObject weapon;
    //public bool attacking = false;
    public Character character;
    private bool debugNoDead = false;
    public AnimationEvents AnimationEvents;


    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<BoxCollider2D>();
        weaponController = GetComponentInChildren<WeaponControls>();
       // rigid.Sleep();
        //collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if ( !debugNoDead)
        //{
        //    if (!weaponController.Attacking)
        //    {
        //        //rigid.bodyType = RigidbodyType2D.Kinematic;
        //      //  rigid.Sleep();
        //        //collider.enabled = false;
        //        attacking = false;
        //    }
        //    else
        //    {
        //        //rigid.Sleep();
        //       // collider.enabled = false;
        //        attacking = true;
        //    }
        //}
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //rigid.bodyType = RigidbodyType2D.Static;
            debugNoDead = !debugNoDead;
        }
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 19)
        {
            if (!(PlayerStateController.instance.state == PlayerStateController.PlayerState.dead))
            {
                character.Animator.SetTrigger("Hurt");
            }
            else
            {
                collider.enabled = false;
            }
            
        }
    }
}

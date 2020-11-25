using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundraryController : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            SoundManager.instance.Audio.Stop();
            SoundManager.instance.Audio.PlayOneShot(SoundManager.instance.Barrier1);
            hitEffect.transform.position = collision.gameObject.transform.position;
            collision.gameObject.SetActive(false);
            hitEffect.GetComponent<ParticleSystem>().Play();
            PlayerStateController.instance.ChangePlayerState(PlayerStateController.PlayerState.dead);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}

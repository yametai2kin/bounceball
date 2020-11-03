using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private GameManager gameManager = null;
    public AudioClip hitWall = null;
    private AudioSource audioSource = null;

    public int bounceCount
    {
        get;
        set;
    }

    public int score
    {
        get;
        set;
   }

    public GameObject ball
    {
        get;
        set;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.gameManager = FindObjectOfType<GameManager>();
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionExit( Collision collision )
    {
        if( !collision.collider.material.name.Contains( "Floor" ) )
        {
            this.score += 10;
            this.bounceCount++;

            // 効果音
            this.audioSource.PlayOneShot( this.hitWall );
        }
    }

    void OnTriggerExit( Collider other )
    {
        Ornament ornament = other.gameObject.GetComponent<Ornament>();
        if( ornament != null )
        {
            this.score += ornament.addScore;
            if( ornament.mulScore > 0 )
            {
                this.score *= ornament.mulScore;
            }
            Instantiate( this.gameManager.hitEffect, ornament.transform.position, Quaternion.identity );
            other.gameObject.SetActive( false );

            // 効果音
            if( ornament.hitSound != null )
            {
                this.audioSource.PlayOneShot( ornament.hitSound );
            }
            return;
        }
    }

}

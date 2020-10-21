using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if( rigidbody.velocity.magnitude < 1 )
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    void OnCollisionExit( Collision collision )
    {
        Ornament ornament = collision.gameObject.GetComponent<Ornament>();
        if( ornament != null )
        {
            this.score += ornament.addScore;
            this.score *= ornament.mulScore;
            collision.gameObject.SetActive( false );
            return;
        }

        if( !collision.collider.material.name.Contains( "Floor" ) )
        {
            this.score += 10;
            this.bounceCount++;
        }
    }
}

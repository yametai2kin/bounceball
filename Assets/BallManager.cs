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

    public GameObject ball
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

    }

    void OnCollisionExit( Collision collision )
    {
        if( !collision.collider.material.name.Contains( "Floor" ) )
        {
            this.score += 10;
            this.bounceCount++;
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
            other.gameObject.SetActive( false );
            return;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public Transform ball = null;
    public float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown( 0 ) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;
            if( Physics.Raycast( ray, out hit, 1000 ) )
            {
                Rigidbody rigidbody = this.ball.GetComponent<Rigidbody>();
                BallManager ballManager = this.ball.GetComponent<BallManager>();
                Vector3 vec = hit.point - rigidbody.transform.position;
                vec.y = 0;
                rigidbody.AddForce( vec * this.speed, ForceMode.Acceleration );
                ballManager.bounceCount = 0;
                ballManager.score = 0;
            }
        }
    }

    /*
    void OnGUI()
    {
        GUILayout.Box( "Bounce Ball", GUILayout.Width( 170 ), GUILayout.Height( 100 ) );
        Rect screenRect = new Rect( 10, 25, 150, 100 );
        GUILayout.BeginArea( screenRect );
        BallManager ballManager = this.ball.GetComponent<BallManager>();
        GUILayout.TextArea( string.Format( "Speed:{0}", ballManager.GetComponent<Rigidbody>().velocity.magnitude ) );
        GUILayout.TextArea( string.Format( "Score:{0}", ballManager.score ) );
        GUILayout.EndArea();
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        Ready,
        Shooting,
        Running,
        Result,
    }

    public BallManager ballManager = null;
    public float speed = 100;
    public float stopSpeed = 1.5f;
    public GameObject stage = null;
    public GameObject[] stagePrehabs = null;
    public GameObject hitEffect = null;
    public State state = State.Ready;

    // Start is called before the first frame update
    void Start()
    {
        SetupStage();
    }

    // Update is called once per frame
    void Update()
    {
        switch( this.state )
        {
            case State.Ready:
            {
                if( Input.GetMouseButtonDown( 0 ) )
                {
                    Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
                    RaycastHit hit;
                    if( Physics.Raycast( ray, out hit, 1000 ) )
                    {
                        Rigidbody rigidbody = this.ballManager.GetComponent<Rigidbody>();
                        BallManager ballManager = this.ballManager.GetComponent<BallManager>();
                        Vector3 vec = hit.point - rigidbody.transform.position;
                        vec.y = 0;
                        rigidbody.AddForce( vec * this.speed, ForceMode.Acceleration );
                        ballManager.bounceCount = 0;
                        ballManager.score = 0;
                        this.state = State.Shooting;
                    }
                }
            }
            break;

            case State.Shooting:
            {
                Rigidbody rigidbody = this.ballManager.GetComponent<Rigidbody>();
                if( rigidbody.velocity.magnitude >= this.stopSpeed )
                {
                    this.state = State.Running;
                }
            }
            break;


            case State.Running:
            {
                Rigidbody rigidbody = this.ballManager.GetComponent<Rigidbody>();
                if( rigidbody.velocity.magnitude < this.stopSpeed )
                {
                    rigidbody.velocity = Vector3.zero;
                    rigidbody.Sleep();
                    this.state = State.Result;
                }
            }
            break;

            case State.Result:
            {

            }
            break;
        }
    }

    void ButtonReset()
    {
        if( this.stage != null )
        {
            Destroy( this.stage );
            this.stage = null;
        }
        this.stage = Instantiate<GameObject>( this.stagePrehabs[ 0 ] );
        SetupStage();
        this.state = State.Ready;
    }

    void SetupStage()
    {
        if( this.stage == null )
        {
            return;
        }
        this.ballManager = this.stage.GetComponentInChildren<BallManager>();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BodyManager : MonoBehaviour
{
    [System.Serializable]
    public class MaterialSet
    {
        public Material visualMaterial;
        public PhysicMaterial physicMaterial;
        public MaterialSet( Material visualMaterial, PhysicMaterial physicMaterial )
        {
            this.visualMaterial = visualMaterial;
            this.physicMaterial = physicMaterial;
        }
    }

    private GameObject childRoot = null;
    private Transform[] childBodies = null;
    public MaterialSet[] materialSets = null;


    // Start is called before the first frame update
    void Start()
    {
        this.childRoot = new GameObject( "ChildRoot" );
        this.childBodies = new Transform[ this.transform.childCount ];

        // 無効化
        for( int i = 0 ; i < this.transform.childCount ; i++ )
        {
            this.childBodies[ i ] = this.transform.GetChild( i );
            this.childBodies[ i ].gameObject.SetActive( false );
        }

    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.D ) )
        {
            for( int i = this.childRoot.transform.childCount ; i > 0 ; i-- )
            {
                Destroy( this.childRoot.transform.GetChild( i - 1 ).gameObject );
            }
        }
        else if( Input.GetKeyDown( KeyCode.Space ) )
        {

        }
    }

    void OnGUI()
    {
        GUILayout.Box( "Body Manager", GUILayout.Width( 170 ), GUILayout.Height( 100 ) );
        Rect screenRect = new Rect( 10, 25, 150, 100 );
        GUILayout.BeginArea( screenRect );
        if( GUILayout.Button( "Add Body" ) )
        {
            GameObject body = GameObject.Instantiate( this.childBodies[ Random.Range( 0, this.childBodies.Length ) ].gameObject );
            body.SetActive( true );
            body.transform.parent = this.childRoot.transform;
            body.transform.position = this.transform.position;
            body.transform.rotation = Random.rotation;

            // マテリアルを設定する
            if( this.materialSets.Length > 0 )
            {
                MaterialSet materialSet = this.materialSets[ Random.Range( 0, this.materialSets.Length ) ];
                body.GetComponent<Renderer>().material = materialSet.visualMaterial;
                body.GetComponent<Collider>().material = materialSet.physicMaterial;
            }
        }
        if( GUILayout.Button( "Delete Body" ) )
        {
            for( int i = this.childRoot.transform.childCount ; i > 0 ; i-- )
            {
                Destroy( this.childRoot.transform.GetChild( i - 1 ).gameObject );
            }
        }

        GUILayout.EndArea();
    }
}

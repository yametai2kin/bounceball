using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ornament : MonoBehaviour
{
    public int addScore = 0;
    public int mulScore = 1;
    private TextMesh text = null;

    // Start is called before the first frame update
    void Start()
    {
        this.text = GetComponentInChildren<TextMesh>();
        if( this.addScore > 0 )
        {
            this.text.text = string.Format( "＋{0}", this.addScore );
        }
        else if( this.mulScore > 0 )
        {
            this.text.text = string.Format( "×{0}", this.mulScore );
        }

    }

    // Update is called once per frame
    void Update()
    {
        this.text.transform.forward = Camera.main.transform.forward;
    }
}

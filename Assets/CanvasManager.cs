using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public GameManager gameManager = null;
    private TextMeshProUGUI textScore = null;
    private TextMeshProUGUI textNavigation = null;
    private GameObject buttonReset = null;
    private GameObject planeBackground = null;

    // Start is called before the first frame update
    void Start()
    {
        this.textScore = GameObject.Find( "Canvas/TextScore" ).GetComponent<TextMeshProUGUI>();
        this.textNavigation = GameObject.Find( "Canvas/TextNavigation" ).GetComponent<TextMeshProUGUI>();
        this.buttonReset = GameObject.Find( "Canvas/ButtonReset" );
        this.planeBackground = GameObject.Find( "Canvas/PanelBackground" );
    }

    // Update is called once per frame
    void Update()
    {
        switch( this.gameManager.state )
        {
            case GameManager.State.Ready:
            {
                this.textScore.enabled = true;
                this.textNavigation.enabled = true;
                this.textNavigation.text = "クリックでボールを打ち出せ！";
                this.planeBackground.SetActive( true );
                this.buttonReset.SetActive( false );
            }
            break;

            case GameManager.State.Shooting:
            {
                this.textScore.enabled = true;
                this.textNavigation.enabled = false;
                this.planeBackground.SetActive( false );
                this.buttonReset.SetActive( false );
            }
            break;

            case GameManager.State.Running:
            {
                this.textNavigation.enabled = false;
                this.planeBackground.SetActive( false );
                this.buttonReset.SetActive( false );

            }
            break;

            case GameManager.State.Result:
            {
                this.textScore.enabled = false;
                this.textNavigation.enabled = true;
                this.textNavigation.text = string.Format( "スコア:{0}", this.gameManager.ballManager.score );
                this.planeBackground.SetActive( true );
                this.buttonReset.SetActive( true );
            }
            break;

            default:
            {
                this.textScore.enabled = false;
                this.textNavigation.enabled = false;
                this.planeBackground.SetActive( false );
                this.buttonReset.SetActive( false );
             }
            break;
        }


        this.textScore.text = "";
        //this.textScore.text += string.Format( "State:{0}\n", this.gameManager.state );
        //this.textScore.text += string.Format( "Speed:{0}\n", this.gameManager.ballManager.GetComponent<Rigidbody>().velocity.magnitude );
        this.textScore.text += string.Format( "Score:{0}\n", this.gameManager.ballManager.score );
    }
}

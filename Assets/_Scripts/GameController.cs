
/*
 * Sourcefile name : GameController
 * Author’s name: Anjith Babu
 * Last	Modifiedby: Anjith Babu
 * Date	lastModified : Feb 05, 2016	
 * Program	description: The StartCoroutine is obtained after referencing following link http://answers.unity3d.com/questions/569864/blink-objec-on-collision.html	
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    // PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;

    [SerializeField]
    private AudioSource _gameOverSound;

    // PUBLIC ACCESS METHODS
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }

    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
               this._endGame();
            }
            else
            {
                this.LivesLabel.text = "lives: " + this._livesValue;
            }
        }
    }

    
    // PUBLIC INSTANCE VARIABLES
    public int cloudNumber = 3;
    public EnemySubController enemySub;
    public HeroSubController heroSub;
    public PearlController pearl;
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text HighScoreLabel;
    public Button RestartButton;
    public bool gameNotOver = true;
    public Transform transform;

    // Use this for initialization
    void Start()
    {
        this._initialize();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //PRIVATE METHODS ++++++++++++++++++

    //Initial Method
    private void _initialize()
    {
        this.ScoreValue = 0;
        this.LivesValue = 5;
        this.GameOverLabel.gameObject.SetActive(false);
        this.HighScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);


        for (int cloudCount = 0; cloudCount < this.cloudNumber; cloudCount++)
        {
            Instantiate(enemySub.gameObject);
        }
    }

    // Things to do when game ends

    private void _endGame()
    {
        this.gameNotOver = false;
        this.HighScoreLabel.text = "High Score: " + this._scoreValue;
        this.GameOverLabel.gameObject.SetActive(true);
        this.HighScoreLabel.gameObject.SetActive(true);
        this.LivesLabel.gameObject.SetActive(false);
        this.ScoreLabel.gameObject.SetActive(false);
        this.heroSub.gameObject.SetActive(false);
        this.pearl.gameObject.SetActive(false);
        this._gameOverSound.Play();
        this.RestartButton.gameObject.SetActive(true);

    }

    // PUBLIC METHODS ------------------------------//

    public void RestartButtonClick()
    {
        gameNotOver = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Control the behaviour of hero submarine when it is hit by enemy

    public void controlHero() {
        if (gameNotOver)
        {
            StartCoroutine(makeHeroDisappear());
        }
    }


    IEnumerator makeHeroDisappear() 
    {
        //move hero out of the frame
         this.transform = this.heroSub.gameObject.GetComponent<Transform>();
         this.transform.position = new Vector2(-368f, 0);

        //wait for a bit
        yield return new WaitForSeconds(1);
     
        //bring hero back
        this.transform.position = new Vector2(-297f, 0);
     }
     
}

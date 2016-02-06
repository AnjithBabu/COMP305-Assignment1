using UnityEngine;
using System.Collections;

public class HeroCollider : MonoBehaviour {

    // PRIVATE INSTANCE VARIABLES
    private AudioSource[] _audioSources;
    private AudioSource _pearlSound;
    private AudioSource _enemySubSound;
    public PearlController pearl;
    public HeroSubController heroSub;

    // PUBLIC INSTANCE VARIABLES
    public GameController gameController;

    // Use this for initialization
    void Start()
    {
        // Initialize the audioSources array
        this._audioSources = gameObject.GetComponents<AudioSource>();
        this._pearlSound = this._audioSources[1];
        this._enemySubSound = this._audioSources[2];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pearl"))
        {
            this._pearlSound.Play();
            this.gameController.ScoreValue += 100;
            this.pearl.Reset();
            
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            this._enemySubSound.Play();
            this.gameController.LivesValue -= 1;
            this.gameController.controlHero(); 
        }
    }
}

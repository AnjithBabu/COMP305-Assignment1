using UnityEngine;
using System.Collections;

public class EnemySubController : MonoBehaviour {
    // PUBLIC INSTANCE VARIABLES
    public float minVerticalSpeed = -2f;
    public float maxVerticalSpeed = 2f;
    public float minHorizontalSpeed = 5f;
    public float maxHorizontalSpeed = 10f;

    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Vector2 _currentPosition;
    private float _verticalSpeed;
    private float _horizontalDrift;
    private float yPosition;

    // Use this for initialization
    void Start()
    {
        // Make a reference with the Transform Component
        this._transform = gameObject.GetComponent<Transform>();

        // Reset the Cloud Sprite to the Top
        this.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        this._currentPosition = this._transform.position;
        this._currentPosition -= new Vector2(this._verticalSpeed, 0);
        this._transform.position = this._currentPosition;

        if (this._currentPosition.x <= -391)
        {
            this.Reset();
        }
        
    }

    public void Reset()
    {
        this._verticalSpeed = Random.Range(this.minVerticalSpeed, this.maxVerticalSpeed);
        this._horizontalDrift = Random.Range(this.minHorizontalSpeed, this.maxHorizontalSpeed);
        this.yPosition = Random.Range(-154f, 218f);
        this._transform.position = new Vector2(395f, yPosition);
    }

    // PRIVATE METHODS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void _checkBounds()
    {
        
        // check if the plane is going out of bounds and keep it inside window boundary
        if (this._currentPosition.y < -154f)
        {
            this._currentPosition.y = -154f;
        }

    }
}

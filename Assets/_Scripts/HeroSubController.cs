
/*
 * Sourcefile name : HeroSubController
 * Author’s name: Anjith Babu
 * Last	Modifiedby: Anjith Babu
 * Date	lastModified : Feb 05, 2016	
 */
using UnityEngine;
using System.Collections;

public class HeroSubController : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES
    public float speed = 5;

    // PRIVATE INSTANCE VARIABLES
    private float playerInput;
    private Transform transform;
    private Vector2 currentPosition;

    // Use this for initialization
    void Start()
    {
        this.transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.currentPosition = this.transform.position;
        this.playerInput = Input.GetAxis("Vertical");

        if (this.playerInput > 0 && this.currentPosition.y < 227)
        {
            this.currentPosition += new Vector2(0, this.speed);

        }
        if (this.playerInput < 0 && this.currentPosition.y > -146)
        {
            this.currentPosition -= new Vector2(0, this.speed);

        }
        this.transform.position = this.currentPosition;
    }
}

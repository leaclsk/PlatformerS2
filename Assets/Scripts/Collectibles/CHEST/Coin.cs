using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int bounces = 0;
    private bool isGrounded = true;
    private Vector2 groundVelocity;
    private float verticalVelocity, afterVelocity;

    private Transform t_parent; // Main
    private Transform t_body; // Body
    private Transform t_shadow; // Shadow

    #region OPTIONAL PICK UP
    bool canCollect;
    // Make it trigger
    BoxCollider2D pickUpCollision;

    #region SETTINGS
    [Tooltip("XReducer will slow down horizontal axis ( left right top bottom movement )")]
    [Range(1f, 2.5f)]
    public float YReducer = 1.5f;

    [Tooltip("YReducer will slow down vertical axis ( height of the bounce )")]
    [Range(1f, 2.5f)]
    public float XReducer = 1.5f;

    public int numberOfBounces = 3;

    [Tooltip("Amount of vertical force")]
    public float velocity = 10;

    [Tooltip("Amount of horizontal force")]
    public float horizontalForce = 2;

    public float gravity = -30;

    public float destroyTime = 0f;
    #endregion

    void Start()
    {
  
    }

    void Update()
    {
        UpdatePosition();
    }

    void Initialize(Vector2 groundvelocity)
    {
        isGrounded = false;
        // Slow down the height of bounce
        afterVelocity /= YReducer;
        this.groundVelocity = groundvelocity;
        this.verticalVelocity = afterVelocity;
        bounces++;
    }


    // Call this method to simulate bounce effect
    // On Default it's in the Start()
    public void SimulateDrop()
    {
        StartCoroutine(Simulate());
    }

    private IEnumerator Simulate()
    {
        yield return new WaitForSeconds(1f);
        groundVelocity = new Vector2(Random.Range(-horizontalForce, horizontalForce), Random.Range(-horizontalForce, horizontalForce));
        verticalVelocity = Random.Range(velocity - 1, velocity);
        afterVelocity = verticalVelocity;
        Initialize(groundVelocity);
        yield return null;
    }

    private void UpdatePosition()
    {
        if (!isGrounded)
        {
            verticalVelocity += gravity * Time.deltaTime;
            t_body.position += new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
            t_parent.position += (Vector3)groundVelocity * Time.deltaTime;
            CheckGroundHit();
        }
    }

    /// <summary>
    /// If number of bounces is less than current bounces, it will add force to the item
    /// Force is each bounce reduced by XReducer and YReducer
    /// </summary>
    private void CheckGroundHit()
    {
        if (t_body.position.y < t_shadow.position.y)
        {
            t_body.position = t_shadow.position;

            if (bounces < numberOfBounces)
            {
                Initialize(new Vector2(groundVelocity.x / XReducer, groundVelocity.y / XReducer));
            }
            else
            {
                // Prevent item moving
                isGrounded = true;
            }

        }
    }


    #endregion


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{

    [Header("Run")]
    Animator animController;
    public float runMaxSpeed; //vitesse que le player doit atteindre
    public float runAcceleration; //Time (approx.) temps que prend le player à accelerer de 0 jusqu'au max speed
    [HideInInspector] public float runAccelAmount; // force (multipliée avec speedDiff) appliquée au player
    public float runDecceleration; // le temps que le player prend pour passer de max speed à 0
    [HideInInspector] public float runDeccelAmount; // force (multipliée avec speedDiff) appliquée au player
    [Space(10)]
    [Range(0.01f, 1)] public float accelInAir; //Multipliers applied to acceleration rate when airborne.
    [Range(0.01f, 1)] public float deccelInAir;
    public bool doConserveMomentum;
    #region COMPONENTS
    public Rigidbody2D rb;
    #endregion

    #region STATE PARAMETERS
    //Variables control the various actions the player can perform at any time.
    //These are fields which can are public allowing for other sctipts to read them
    //but can only be privately written to.
    public bool IsFacingRight { get; private set; }
    public float LastOnGroundTime { get; private set; }
    #endregion

    #region INPUT PARAMETERS
    private Vector2 _moveInput;
    #endregion

    #region CHECK PARAMETERS
    //Set all of these up in the inspector
    [Header("Checks")]
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.49f, 0.03f);
    #endregion

    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    [SerializeField] private LayerMask _groundLayer;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<Animator>();
    }

    private void Start()
    {
        IsFacingRight = true;
    }

    private void Update()
    {
        #region TIMERS
        LastOnGroundTime -= Time.deltaTime;
        #endregion

        #region INPUT HANDLER
        _moveInput.x = Input.GetAxisRaw("Horizontal");

        if (_moveInput.x != 0)
            CheckDirectionToFace(_moveInput.x > 0);
        #endregion

        #region COLLISION CHECKS
        //Ground Check
        if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer)) //checks if set box overlaps with ground
            LastOnGroundTime = 0.1f;
        #endregion
    }

    private void FixedUpdate()
    {
    
            Run();
    }

    //MOVEMENT METHODS
    #region RUN METHODS
    private void Run()
    {
        animController.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        //Calculate the direction we want to move in and our desired velocity
        float targetSpeed = _moveInput.x * runMaxSpeed;

        #region Calculate AccelRate
        float accelRate;

        //Gets an acceleration value based on if we are accelerating (includes turning) 
        //or trying to decelerate (stop). As well as applying a multiplier if we're air borne.
        if (LastOnGroundTime > 0)
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? runAccelAmount : runDeccelAmount;
        else
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? runAccelAmount * accelInAir : runDeccelAmount * deccelInAir;
        #endregion


        #region Conserve Momentum
        //We won't slow the player down if they are moving in their desired direction but at a greater speed than their maxSpeed
        if (doConserveMomentum && Mathf.Abs(rb.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(rb.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && LastOnGroundTime < 0)
        {
            //Prevent any deceleration from happening, or in other words conserve are current momentum
            //You could experiment with allowing for the player to slightly increae their speed whilst in this "state"
            accelRate = 0;
        }
        #endregion

        //diiférence entre la velocité actuelle et celle désirée
        float speedDif = targetSpeed - rb.velocity.x;
        //calcul la force sur l'axe x pour l'appliquer au player

        float movement = speedDif * accelRate;

        //Converti en vecteur et l'applique au player
        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);

    }

    private void Turn()
    {
        //stores scale and flips the player along the x axis, 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        IsFacingRight = !IsFacingRight;
    }
    #endregion


    #region CHECK METHODS
    public void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != IsFacingRight)
            Turn();
    }
    #endregion
}

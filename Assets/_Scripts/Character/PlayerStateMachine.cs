using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStateMachine : MonoBehaviour
{

    public PlayerState currentState { get; private set; }
    public PlayerInputHandler inputHandler; // Input handler for player actions
    public PlayerStatsManager playerStatsManager; // Player stats manager for health, attack, etc.
    public ComboInputHandler comboInputHandler; // Handles combo inputs and skill casting
    public UiManager uiManager;
    public Animator animator; // Animator for player animations
    public AnimatorOverrideController baseOverrideController;
    public SpriteRenderer spriteRenderer; // Sprite renderer for player visuals
    public AnimationManager animationManager; // Animation manager for handling animations

    [Header("Player Movement")]
    public Rigidbody2D rb; // Rigidbody for physics interactions
    public bool isAttacking = false;
    public float jumpForce = 5f; // Player jump force
    public float walkAcceleration = 20f; // Player acceleration when walking

    [Header("Ground Check")]
    public Transform groundCheckPoint; // ayak seviyesinde bo� obje
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    [Header ("Player attack hitnbox")]
    public GameObject attackHitbox; 

    private void Awake()
    {
        animationManager.Initialize(this); 
    }


    public int de�er;
    void Start()
    {
        ChangeState(new IdleState(this));
    }

    void Update()
    {
        currentState?.Update();

        print(IsGrounded());

    }

    void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }
    public void ChangeState(PlayerState newState)
    {
        //// Ayn� state'e ge�meye �al��ma!
        //if (currentState != null && currentState.GetType() == newState.GetType())
        //    return;

        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }


    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

    public void SpriteFlipRotation()
    {
        if (inputHandler.moveInput.x > 0)
        {
            // Sprite'� sa�a �evir
            spriteRenderer.flipX = false;

            // Hitbox'� sa� tarafa ta��
            Vector3 hitboxLocalPos = attackHitbox.transform.localPosition;
            hitboxLocalPos.x = Mathf.Abs(hitboxLocalPos.x);
            attackHitbox.transform.localPosition = hitboxLocalPos;
        }
        else if (inputHandler.moveInput.x < 0)
        {
            // Sprite'� sola �evir
            spriteRenderer.flipX = true;

            // Hitbox'� sol tarafa ta��
            Vector3 hitboxLocalPos = attackHitbox.transform.localPosition;
            hitboxLocalPos.x = -Mathf.Abs(hitboxLocalPos.x);
            attackHitbox.transform.localPosition = hitboxLocalPos;
        }
    }

    public void SetAnimation(AnimationClip animation)
    {
        if (animator.runtimeAnimatorController is AnimatorOverrideController currentOverride)
        {
            currentOverride["NormalAttack"] = animation;
        }
        else
        {
            AnimatorOverrideController newOverride = new AnimatorOverrideController(baseOverrideController);
            newOverride["NormalAttack"] = animation;
            animator.runtimeAnimatorController = newOverride;
        }

        // Ayn� state olsa bile yeniden ba�lamas�n� ZORLA
        animator.Play("Attack", -1, 0f);
    }
}

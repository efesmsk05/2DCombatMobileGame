using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections; // IEnumerator için gerekli olan ad alaný

public class PlayerInputHandler : MonoBehaviour
{

    private float lastAttackTime;
    private float attackCooldown = 0.28f;
    private PlayerInputActions inputActions;
    public bool lightAttackTriggered { get; private set; } = false;
    public bool heavyAttackTriggered { get; private set; } = false;


    public bool playerIsAttacking { get; private set; } = false; // Saldýrý durumu


    public Vector2 moveInput { get; private set; }

    public bool jumpTriggered { get; private set; }

    public bool attackTriggered { get; private set; }    

    private void Awake()
    {

        inputActions = new PlayerInputActions();

        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();// genel move iþlemi için
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Player.Jump.performed += ctx => jumpTriggered = true;// zýplandýðýnda veri tetikler
        inputActions.Player.Jump.canceled += ctx => jumpTriggered = false; // zýplama iptal edildiðinde veri sýfýrlanýr

        inputActions.Player.Atack.performed += ctx => attackTriggered = true;
        inputActions.Player.Atack.canceled += ctx => attackTriggered = false; // saldýrý iptal edildiðinde veri sýfýrlanýr

    }

    private void Update()
    {


    }

    public void OnJumpButtonDown() => jumpTriggered = true;
    public void OnJumpButtonUp() => jumpTriggered = false;

    public void LightAttackButtonDown()
    {
        if (Time.time - lastAttackTime < attackCooldown) return;

        lastAttackTime = Time.time;
        lightAttackTriggered = true; // Bu frame'de tetiklendi
    }

    public void HeavyAttacButtonDown()
    {
        if (Time.time - lastAttackTime < attackCooldown) return;

        lastAttackTime = Time.time;
        heavyAttackTriggered = true; // Bu frame'de tetiklendi
    }

    public void OnAttackButtonUp() => playerIsAttacking = false;


    public void OnLeftButtonDown() => moveInput = new Vector2(-1f, 0f);
    public void OnRightButtonDown() => moveInput = new Vector2(1f, 0f);
    public void OnMoveButtonUp() => moveInput = Vector2.zero;



    public bool isMoving()
    {
        if (moveInput.x != 0 || moveInput.y != 0)
        {
            return true; // hareket ediyorsa true döner
        }

        return false; // hareket etmiyorsa false döner

    }

    public bool isJumping()
    {
        return jumpTriggered; // zýplama tetiklendiðinde true döner
    }

    public bool isAttacking()
    {
        return attackTriggered; // saldýrý tetiklendiðinde true döner
    }
    private void OnEnable()
    {
        inputActions.Enable(); // input sistemini etkinleþtirir"z
    }
    private void OnDisable()
    {
        inputActions.Disable(); // input sistemini devre dýþý býrakýr
    }

    public void ResetInputFlags()
    {
        jumpTriggered = false;
        attackTriggered = false;
        lightAttackTriggered = false; // Bu frame'de tetiklenmediðini belirtir
        heavyAttackTriggered = false; // Bu frame'de tetiklenmediðini belirtir

    }


}

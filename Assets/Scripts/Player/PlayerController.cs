using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")] 
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpPower;
    public LayerMask groundLayerMask;
    
    [Header("Look")] 
    public Transform cameraContainer;
    public float minXLook; // 최소 시야각
    public float maxXLook; // 최대 시야각
    private float camCurXRot;
    public float lookSensitivity; //마우스 회전 민감도
    private Vector2 mouseDelta;
    public bool canLook = true;
    
    public Action inventory;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        //마우스 커서 삭제
        Cursor.lockState = CursorLockMode.Locked;
    }

    
  void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            // Debug.Log("땅인가?" + IsGrounded());
            CameraLook();
        }
    }
    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);
        
        transform.Rotate(Vector3.up * mouseDelta.x * lookSensitivity);
        
        
        transform.eulerAngles = new Vector3(0, mouseDelta.x * lookSensitivity,0);
    }

    public void OnMove(InputAction.CallbackContext context) //이벤트
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>(); //지속적인 값읽기
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward*0.2f)+(transform.up*0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward*0.2f)+(transform.up*0.01f), Vector3.down),
            new Ray(transform.position + (transform.forward*0.2f)+(transform.up*0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward*0.2f)+(transform.up*0.01f), Vector3.down)
        } ;
        for (int i = 0; i < rays.Length; i++) 
        {
            // Debug.DrawRay(rays[i].origin, rays[i].direction * 0.5f, Color.red);
            
            if (Physics.Raycast(rays[i], 0.5f, groundLayerMask))
            {
                return true;
            }
        }
        
        return false; //반환문
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            inventory?.Invoke();
            ToggleCurSor();

        }
    }

    void ToggleCurSor()
    {
        bool toggle = Cursor.lockState ==CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = toggle;
    }
}



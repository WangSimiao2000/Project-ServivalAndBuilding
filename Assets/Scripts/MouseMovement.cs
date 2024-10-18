using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivityX = 100f;
    public float mouseSensitivityY = 100f;

    public Transform playerBody; // 玩家模型的父级（通常是一个空的 GameObject）
    public Transform playerCamera; // 摄像机的 Transform

    float xRotation = 0f;
    // float YRotation = 0f;

    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        // 控制摄像机的上下旋转
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 限制上下旋转的角度，防止过度旋转

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // 只影响摄像机的旋转

        // 控制玩家左右旋转（影响整个玩家模型）
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
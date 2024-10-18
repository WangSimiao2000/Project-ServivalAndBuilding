using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivityX = 100f;
    public float mouseSensitivityY = 100f;

    public Transform playerBody; // ���ģ�͵ĸ�����ͨ����һ���յ� GameObject��
    public Transform playerCamera; // ������� Transform

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

        // �����������������ת
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ����������ת�ĽǶȣ���ֹ������ת

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // ֻӰ�����������ת

        // �������������ת��Ӱ���������ģ�ͣ�
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
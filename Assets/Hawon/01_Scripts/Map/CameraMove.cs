using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject lookAtMe;
    public float rotateSpeed = 5000f;
    public float scrollSpeed;
    private float yRotateMove;

    public bool isAlt;
    Vector2 clickPoint;
    float dragSpeed = 450.0f;

    private void Update()
    {
        CameraMoving();
    }

    private void CameraMoving()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt)) isAlt = true;
        if (Input.GetKeyUp(KeyCode.LeftAlt)) isAlt = false;

        if (Input.GetMouseButtonDown(0)) clickPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (Input.GetMouseButton(0))
        {
            if (isAlt)
            {
                lookAtMe.transform.SetParent(this.transform);

                Vector3 position
                    = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);

                position.z = position.y;
                position.y = .0f;

                Vector3 move = -position * (Time.deltaTime * dragSpeed);

                float y = transform.position.y;

                transform.Translate(move);
                transform.position
                    = new Vector3(transform.position.x, y, transform.position.z);
            }
            else
            {
                //xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
                yRotateMove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;

                Vector3 pos = lookAtMe.transform.position;

                transform.RotateAround(pos, Vector3.right, -yRotateMove);
                //transform.RotateAround(pos, Vector3.up, xRotateMove);

                transform.LookAt(pos);
            }
        }
        else
        {
            lookAtMe.transform.SetParent(null);

            float scroollWheel = Input.GetAxis("Mouse ScrollWheel");

            Vector3 cameraDirection = this.transform.localRotation * Vector3.forward;

            this.transform.position += cameraDirection * Time.deltaTime * scroollWheel * scrollSpeed;
        }
    }
}

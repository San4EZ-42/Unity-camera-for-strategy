using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
      //Set the values ​​of camera movement speed, camera rotation speed along the Y axis and map coordinate limits
public float rotateSpeed = 80.0f, speed = 40.0f, borderThickness = 10f;
public float panLimitX = 60f, panLimitZ = 150f;

public void Update(){
      //-------------Camera movement-------------
      //We assign the task of rotating the camera along the Y axis to the Q, E keys
      if (Input.GetKey(KeyCode.Q)){
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime, Space.World);
      }
      if (Input.GetKey(KeyCode.E)){
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
      }
      
      Vector3 move = Vector3.zero;

      if (Input.anyKey){  //We assign the WASD keys the task of moving the camera around the game map
            if (Input.GetKey(KeyCode.W)){
                  Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
                  move += forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S)){
                  Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
                  move -= forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D)){
                  Vector3 right = new Vector3(transform.right.x, 0, transform.right.z).normalized;
                  move += right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A)){
                  Vector3 right = new Vector3(transform.right.x, 0, transform.right.z).normalized;
                  move -= right * speed * Time.deltaTime;
            }
      }


      transform.position += move;
      Vector3 pos = transform.position;

      //We set a ban on camera movement when it reaches the constraint coordinates
      pos.x = Mathf.Clamp(pos.x, -panLimitX, panLimitX);
      pos.z = Mathf.Clamp(pos.z, -panLimitZ, panLimitZ);

      transform.position = pos;
      }
}

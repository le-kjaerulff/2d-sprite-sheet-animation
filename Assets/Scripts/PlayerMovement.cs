using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Henter unity inputsystem pakken

public class PlayerMovement : MonoBehaviour
{
  
    Vector2 movement; // variabel som kan holde en 2D-vektor værdi. 
    Rigidbody2D snailBody; // variabel som kan holde et rigid-body component.
    Animator snailAnimator; // variabel som kan holde et animator component.

    [SerializeField] float movementSpeed; // int-variabel som justerer spillerens hastighed. 
   

    private void Awake()
    {
        snailBody = GetComponent<Rigidbody2D>(); // snailBody får Rigidbody2D componentet som ligger på "Doug the Slug"-objektet i Unity. 
        snailAnimator = GetComponent<Animator>(); // snailAnimator får Animator componentet som ligger på "Doug the Slug"-objektet i Unity.

        Debug.Log("READY! SET! GO!"); // skriver dette i konsollen. 
    }


    void OnMovement(InputValue value) // En funktion oprettes som oversætter spillerens inputs til vector2 værdier og gemmer det i "movement". "InputValue" er en class fra Inputsystem. 
    {
        movement = value.Get<Vector2>(); // movement får en Vector2 værdi baseret på spilleres inputs. "Get" er en metode fra InputValue classen som læser værdien som et objekt. 
        
        if (movement.x != 0) // Condition som er sand når spilleren bevæger sig. 
        {
            snailAnimator.SetFloat("X", movement.x); // sætter "X" parameteren i Animatoren til movements vector2 værdi.

            snailAnimator.SetBool("isMoving", true); // sætter "isMoving" parameteren i Animatoren til true.
        }
        else
        {
            snailAnimator.SetBool("isMoving", false); // sætter "isMoving" parameteren i Animatoren til false. 
        }
    }

     private void FixedUpdate()
    {
        snailBody.velocity = movement * movementSpeed; // Rigidbodyens velocity får vektoren fra "movement" og ganger denne med skalaren fra "movementspeed". 
    }





}

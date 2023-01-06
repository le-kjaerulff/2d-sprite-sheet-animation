using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Henter unity inputsystem pakken

public class PlayerMovement : MonoBehaviour
{
  
    Vector2 movement; // variabel som kan holde en 2D-vektor v�rdi. 
    Rigidbody2D snailBody; // variabel som kan holde et rigid-body component.
    Animator snailAnimator; // variabel som kan holde et animator component.

    [SerializeField] float movementSpeed; // int-variabel som justerer spillerens hastighed. 
   

    private void Awake()
    {
        snailBody = GetComponent<Rigidbody2D>(); // snailBody f�r Rigidbody2D componentet som ligger p� "Doug the Slug"-objektet i Unity. 
        snailAnimator = GetComponent<Animator>(); // snailAnimator f�r Animator componentet som ligger p� "Doug the Slug"-objektet i Unity.

        Debug.Log("READY! SET! GO!"); // skriver dette i konsollen. 
    }


    void OnMovement(InputValue value) // En funktion oprettes som overs�tter spillerens inputs til vector2 v�rdier og gemmer det i "movement". "InputValue" er en class fra Inputsystem. 
    {
        movement = value.Get<Vector2>(); // movement f�r en Vector2 v�rdi baseret p� spilleres inputs. "Get" er en metode fra InputValue classen som l�ser v�rdien som et objekt. 
        
        if (movement.x != 0) // Condition som er sand n�r spilleren bev�ger sig. 
        {
            snailAnimator.SetFloat("X", movement.x); // s�tter "X" parameteren i Animatoren til movements vector2 v�rdi.

            snailAnimator.SetBool("isMoving", true); // s�tter "isMoving" parameteren i Animatoren til true.
        }
        else
        {
            snailAnimator.SetBool("isMoving", false); // s�tter "isMoving" parameteren i Animatoren til false. 
        }
    }

     private void FixedUpdate()
    {
        snailBody.velocity = movement * movementSpeed; // Rigidbodyens velocity f�r vektoren fra "movement" og ganger denne med skalaren fra "movementspeed". 
    }





}

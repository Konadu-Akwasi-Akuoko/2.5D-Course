using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed=5.0f;
    [SerializeField]
    private float _gravity = 5.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity = 0;
    private bool _doubleJump = false;

    //Coins part
    private int _coins;
    private UIManager uimanager;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        uimanager = GameObject.FindWithTag("UI").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //  INPUT MANAGER AND CHARACTER CONTROLLER
        // getting input from the input manager
        float horizontalInput = Input.GetAxis("Horizontal");

        //you need direction in which the inout manager will move,
        //NB the input manager is not responsible for direction in your games,
        //you need to create your own directions.
        Vector3 direction = new Vector3(horizontalInput, 0, 0);

        //time to make use of velocity here, by adding velocity, u are adding speed
        //to the 1 metre / unit to make it move according to your specified speed
        Vector3 velocity = direction * _speed;

        //j/adding gravity to the player, we need to substract gravity from our current velocity.y position
        //j/when we are not grounded, thus we will keep substracting from our velocity.y position when high up 
        //j/in the air. We will only stop substracting when we are grounded. This is made possible by our
        //j/ .move function so that we may have a smooth fall, otherwise it will work as a 
        //j/transform.position or some teleportation thing.
        
        //g/here we are adding jump to our velocity.y when grounded
        //g/and it's just the opposite of gravity, where velocity is substracting jumpheight is also adding.

        if(_controller.isGrounded == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                //when double jump is true, make the player add another jumpheight to yVelocity
                //then when space is pressed in the else function make the bool false again.
                _doubleJump = true;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _doubleJump == true)
            {
                _yVelocity += _jumpHeight;
                _doubleJump = false;
            }
            _yVelocity -= _gravity;
        }

        //1.here we need to add a force so the player moves in accordance to the specified direction
        //1.and one metre / unit if no acceleration is added.
        //2.after the creation of velocity we just swap "direction" with "velocity" in the move function

        // we need to cache our y velocity in "yVelocty" to stop it being weird, because when we do not
        //cache on every frame our direction set the y value to zero making it snap.
        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);

    }


    private void OnTriggerEnter(Collider other)
    {
        //COINS, if the collided thing's tag is "collectible", the we add1 and call the ui func.
        if (other.tag == "Collectible")
        {
            _coins++;
            uimanager.UIcoins(_coins);
            Destroy(other.gameObject);
        }
    }


}

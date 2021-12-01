using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Samuel Ayeni

public class PlayerScript : MonoBehaviour
{
    public GameManagerScript gms;
    public GameObject spawnPoint;
    public GameObject[] spawnedProjectile;
    public bool showOptions;
    private float hor, vert, turnX, turnY, health, currentBar, maxBar = 100.0f, speed, timeSinceDamaged = 0.0f, rightJoystick4th, rightJoystick5th, rotX, rotY;
    private Rigidbody rb;
    private Vector3 movement;
    private bool alive;
    public OptionsScript os;
    public string currController;

    private float Health
    {
        get { return health; }
        set {
            if(health != 0.0f)
            {
                health = value;
            } else {
                Alive = false;
            }
        }
    }

    public bool Alive
    {
        get { return alive; }
        set { alive = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Alive = true;
        gms = GetComponent<GameManagerScript>();
        rb = GetComponent<Rigidbody>();
        os = GetComponent<OptionsScript>();
        speed = 10.0f;
        health = maxBar;
        currentBar = Health * maxBar / 100.0f;
        Cursor.visible = false;
        showOptions = false;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (Input.GetJoystickNames()[0] != null)
                currController = Input.GetJoystickNames()[0];
            print(currController);
        } catch (System.Exception e) {
            currController = e.ToString();
        }
        
        if(!gms.Paused || !showOptions)
        {
            if (Alive)
            {
                if (timeSinceDamaged > 10.0f && Health < 100.0f)
                {
                    Health += 2.0f;
                    timeSinceDamaged = 0.0f;
                }

                if (currController != null)
                {
                    rotX += turnY * 3;
                    rotY += turnX * 3;

                    if (os.currProfile.Contains("1"))
                    {
                        turnX = Input.GetAxis(os.mouseX);
                        turnY = Input.GetAxis(os.mouseY);

                        transform.rotation = Quaternion.Euler(-rotX, rotY, 0.0f);
                    }
                    else
                    {
                        if (Input.GetKey(os.turnRight))
                            turnX = 1.0f;
                        else if (Input.GetKey(os.turnLeft))
                            turnX = -1.0f;
                        else
                            turnX = 0.0f;

                        transform.rotation = Quaternion.Euler(0.0f, rotY, 0.0f);
                    }

                    transform.Rotate(Vector3.up * turnY);
                    transform.Rotate(Vector3.right * turnX);
                }
                else
                {
                    if (currController.Equals("Controller (XBOX 360 For Windows)"))
                    {
                        rightJoystick4th = Input.GetAxis(os.mouseX);

                        if (rightJoystick4th > 0.05f)
                            transform.Rotate(Vector3.right * (rightJoystick4th * 3));
                        else if (rightJoystick4th < -0.05f)
                            transform.Rotate(Vector3.left * (-rightJoystick4th * 3));
                    }
                }

                timeSinceDamaged += Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        if (!gms.Paused || !showOptions)
        {
            if(Alive)
            {
                //Movement, Shooting, etc.

                if (os.currProfile.Contains("1") || os.currProfile.Contains("2"))
                {
                    if (Input.GetKey(os.right))
                    {
                        hor = 1.0f;
                    }
                    else if (Input.GetKeyUp(os.right))
                    {
                        hor = 0.0f;
                    }
                    else if (Input.GetKey(os.left))
                    {
                        hor = -1.0f;
                    }
                    else if (Input.GetKeyUp(os.left))
                    {
                        hor = 0.0f;
                    }
                    else if (Input.GetKey(os.up))
                    {
                        vert = 1.0f;
                    }
                    else if (Input.GetKeyUp(os.up))
                    {
                        vert = 0.0f;
                    }
                    else if (Input.GetKey(os.down))
                    {
                        vert = -1.0f;
                    }
                    else if (Input.GetKeyUp(os.down))
                    {
                        vert = 0.0f;
                    }
                    else if (Input.GetKey(os.right) && Input.GetKey(os.up))
                    {
                        hor = 1.0f;
                        vert = 1.0f;
                    }
                    else if (Input.GetKeyUp(os.right) && Input.GetKeyUp(os.up))
                    {
                        hor = 0.0f;
                        vert = 0.0f;
                    }
                    else if (Input.GetKey(os.right) && Input.GetKey(os.down))
                    {
                        hor = 1.0f;
                        vert = -1.0f;
                    }
                    else if (Input.GetKeyUp(os.right) && Input.GetKeyUp(os.down))
                    {
                        hor = 0.0f;
                        vert = 0.0f;
                    }
                    else if (Input.GetKey(os.left) && Input.GetKey(os.up))
                    {
                        hor = -1.0f;
                        vert = 1.0f;
                    }
                    else if (Input.GetKeyUp(os.left) && Input.GetKeyUp(os.up))
                    {
                        hor = 0.0f;
                        vert = 0.0f;
                    }
                    else if (Input.GetKey(os.left) && Input.GetKey(os.down))
                    {
                        hor = -1.0f;
                        vert = -1.0f;
                    }
                    else if (Input.GetKeyUp(os.left) && Input.GetKeyUp(os.down))
                    {
                        hor = 0.0f;
                        vert = 0.0f;
                    } else {
                        hor = 0.0f;
                        vert = 0.0f;
                    }
                } else {
                    if(currController.Equals("Controller (XBOX 360 For Windows)"))
                    {
                        rightJoystick5th = Input.GetAxis(os.vertProfile);
                    }
                        
                }

                //Moves using the players local coordinates instead of its global coordinates
                movement = (transform.forward * vert) + (transform.right * hor);
                rb.position += ((rb.position.y * 0f) + 1f) * movement * speed * Time.deltaTime;

                if (Input.GetKeyDown(os.shoot))
                {
                    Instantiate(spawnedProjectile[Random.Range(0, 2)], spawnPoint.transform.position, spawnPoint.transform.rotation);
                }
            }
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        timeSinceDamaged = 0.0f;
    }

    void OnGUI()
    {
        //Health
        if(Alive)
        {
            currentBar = Health * maxBar / 100.0f;
            Rect healthBar = new Rect(Screen.width / 2 - 675, Screen.height / 2 - 300, currentBar, 20.0f);
            GUI.Box(healthBar, currentBar.ToString());
        }
    }
}

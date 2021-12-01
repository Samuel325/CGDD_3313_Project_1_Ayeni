using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Samuel Ayeni

public class GameManagerScript : MonoBehaviour
{
    public PlayerScript ps;
    private bool paused;
    private string keyToChange;
    private string inputKeyCode_string;
    private bool getInputKey;

    public bool Paused
    {
        get { return paused; }
        set {
            paused = value;
            if (paused) {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Paused = false;
        Cursor.visible = false;
        ps = GetComponent<PlayerScript>();
        keyToChange = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")) {
            PauseGame();
        }

        if(Paused)
        {
            Cursor.visible = true;
        } else {
            Cursor.visible = false;
        }

        ChangeKeyCode();
    }

    void OnGUI()
    {
        //Profile Menu
        if (ps.showOptions)
        {
            Paused = true;

            Rect profilePane = new Rect(Screen.width / 2, Screen.height / 2 - 300, 600.0f, 200.0f);
            float widthPane = profilePane.x - 100;
            float heightPane = profilePane.height / 2;

            GUI.Box(profilePane, "Options");

            //Profile 1
            if (GUI.Button(new Rect(profilePane.x + 15.0f, heightPane - 30.0f, profilePane.width - 400.0f, 25.0f), "Profile 1 - Keyboard 1"))
            {
                ps.os.UpdateControls("1");
                ps.os.UpdateKeyboardKeys();
                PauseGame();
            }

            //Profile 2
            if (GUI.Button(new Rect(profilePane.x + 15.0f, heightPane, profilePane.width - 400.0f, 25.0f), "Profile 2 - Keyboard 2"))
            {
                ps.os.UpdateControls("2");
                ps.os.UpdateKeyboardKeys();
                PauseGame();
            }

            //Profile 3
            if (ps.currController != null)
            {
                if (GUI.Button(new Rect(profilePane.x + 15.0f, heightPane + 30.0f, profilePane.width - 400.0f, 25.0f), "Profile 3 - USB"))
                {
                    ps.os.UpdateControls("3");
                    ps.os.UpdateKeyboardKeys();
                    PauseGame();
                }
            }

            //Profile 1

            //W Key
            if (GUI.Button(new Rect(widthPane + 320.0f, heightPane - 30.0f, 25.0f, 25.0f), ps.os.profile1[2]))
            {
                getInputKey = true;
                keyToChange = "up_W";
                inputKeyCode_string = " ";
            }

            //A Key
            if (GUI.Button(new Rect(widthPane + 350.0f, heightPane - 30.0f, 25.0f, 25.0f), ps.os.profile1[3]))
            {
                getInputKey = true;
                keyToChange = "left_A";
                inputKeyCode_string = " ";
            }

            //S Key
            if (GUI.Button(new Rect(widthPane + 380.0f, heightPane - 30.0f, 25.0f, 25.0f), ps.os.profile1[4]))
            {
                getInputKey = true;
                keyToChange = "down_S";
                inputKeyCode_string = " ";
            }

            //D Key
            if (GUI.Button(new Rect(widthPane + 410.0f, heightPane - 30.0f, 25.0f, 25.0f), ps.os.profile1[5]))
            {
                getInputKey = true;
                keyToChange = "right_D";
                inputKeyCode_string = " ";
            }

            //Mouse 1 Key - Profile 1
            if (GUI.Button(new Rect(widthPane + 440.0f, heightPane - 30.0f, 75.0f, 25.0f), ps.os.profile1[8]))
            {
                getInputKey = true;
                keyToChange = "Profile1_Mouse1";
                inputKeyCode_string = " ";
            }

            //Profile 2

            //T Key
            if (GUI.Button(new Rect(widthPane + 320.0f, heightPane, 25.0f, 25.0f), ps.os.profile2[2]))
            {
                getInputKey = true;
                keyToChange = "up_T";
                inputKeyCode_string = " ";
            }

            //G Key
            if (GUI.Button(new Rect(widthPane + 350.0f, heightPane, 25.0f, 25.0f), ps.os.profile2[3]))
            {
                getInputKey = true;
                keyToChange = "left_F";
                inputKeyCode_string = " ";
            }

            //F Key
            if (GUI.Button(new Rect(widthPane + 380.0f, heightPane, 25.0f, 25.0f), ps.os.profile2[4]))
            {
                getInputKey = true;
                keyToChange = "down_G";
                inputKeyCode_string = " ";
            }

            //H Key
            if (GUI.Button(new Rect(widthPane + 410.0f, heightPane, 25.0f, 25.0f), ps.os.profile2[5]))
            {
                getInputKey = true;
                keyToChange = "right_H";
                inputKeyCode_string = " ";
            }

            //Right Arrow Key
            if (GUI.Button(new Rect(widthPane + 440.0f, heightPane, 75.0f, 25.0f), ps.os.profile2[6]))
            {
                getInputKey = true;
                keyToChange = "RightArrow";
                inputKeyCode_string = " ";
            }
            
            //Left Arrow Key
            if (GUI.Button(new Rect(widthPane + 520.0f, heightPane, 75.0f, 25.0f), ps.os.profile2[7]))
            {
                getInputKey = true;
                keyToChange = "LeftArrow";
                inputKeyCode_string = " ";
            }

            //Mouse 1 Key - Profile 2
            if (GUI.Button(new Rect(widthPane + 600.0f, heightPane, 75.0f, 25.0f), ps.os.profile2[8]))
            {
                getInputKey = true;
                keyToChange = "Profile2_Mouse1";
                inputKeyCode_string = " ";
            }

            //Profile 3
            if (ps.currController != null)
            {
                //Swap Thumbsticks
                if (GUI.Button(new Rect(widthPane + 320.0f, heightPane + 30.0f, 150.0f, 25.0f), "Invert Thumbsticks"))
                {
                    ps.os.SwapJoysticks();
                }

                //Right Trigger Button
                if (GUI.Button(new Rect(widthPane + 480.0f, heightPane + 30.0f, 150.0f, 25.0f), ps.os.profile3[4]))
                {
                    getInputKey = true;
                    keyToChange = "RightTrigger";
                    inputKeyCode_string = " ";
                }
            }

            //Quit
            if (GUI.Button(new Rect(profilePane.x + 15.0f, heightPane + 60.0f, profilePane.width - 50.0f, 25.0f), "Quit"))
            {
                Application.Quit();
            }
        }
    }

    private void PauseGame()
    {
        Paused = !Paused;
        ps.showOptions = !ps.showOptions;
        Cursor.visible = !Cursor.visible;
    }

    void ChangeKeyCode()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey) && getInputKey)
            {
                inputKeyCode_string = vKey.ToString();
                getInputKey = false;
            }
        }

        if (keyToChange.Equals("up_W"))
        {
            ps.os.profile1[2] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("up_T"))
        {
            ps.os.profile2[2] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("down_S"))
        {
            ps.os.profile1[4] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("down_G"))
        {
            ps.os.profile2[4] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("left_A"))
        {
            ps.os.profile1[3] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("left_F"))
        {
            ps.os.profile2[3] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("right_D"))
        {
            ps.os.profile1[5] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("right_H"))
        {
            ps.os.profile2[5] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("RightArrow"))
        {
            ps.os.profile2[6] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("LeftArrow"))
        {
            ps.os.profile2[7] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("Profile1_Mouse1"))
        {
            ps.os.profile1[8] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("Profile2_Mouse1"))
        {
            ps.os.profile2[8] = inputKeyCode_string;
        }
        else if (keyToChange.Equals("RightTrigger"))
        {
            ps.os.profile3[4] = inputKeyCode_string;
        }

        //Prevents the game from crashing if the inputKeyCode_string variable is set to null
        try
        {
            switch (ps.os.currProfile)
            {
                case "1":
                    ps.os.UpdateControls("1");
                    ps.os.UpdateProfile1(ps.os.profile1[2], ps.os.profile1[3], ps.os.profile1[4], ps.os.profile1[5], ps.os.profile1[8]);
                    break;
                case "2":
                    ps.os.UpdateControls("2");
                    ps.os.UpdateProfile2(ps.os.profile2[2], ps.os.profile2[3], ps.os.profile2[4], ps.os.profile2[5], ps.os.profile2[6], ps.os.profile2[7], ps.os.profile2[8]);
                    break;
                case "3":
                    ps.os.UpdateControls("3");
                    ps.os.UpdateProfile3(ps.os.profile3[4]);
                    break;
            }
        } catch (System.Exception e) {

        }
    }
}

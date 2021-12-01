using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Samuel Ayeni

public class OptionsScript : MonoBehaviour
{
    public string upKey = "W", downKey = "S", leftKey = "A", rightKey = "D", horProfile = "Horizontal", vertProfile = "Vertical", mouseX = "Mouse X", mouseY = "Mouse Y", rightArr = "RightArrow", leftArr = "LeftArrow", fireProjectile = "Mouse1", currProfile;

    private bool inverted = false;

    public KeyCode up, down, left, right, turnRight, turnLeft, shoot;
    
    public string[] profile1 = { "Horizontal", "Vertical", "W", "A", "S", "D" , "Mouse X", "Mouse Y", "Mouse1" };
    public string[] profile2 = { "Horizontal_TGFH", "Vertical_TGFH", "T", "F", "G", "H", "RightArrow", "LeftArrow", "Mouse1" };
    public string[] profile3 = { "Horizontal_USB", "Vertical_USB", "4th Axis", "5th Axis", "JoystickButton5" };
    
    // Start is called before the first frame update
    void Start()
    {
        inverted = false;
        currProfile = "1";
        UpdateKeyboardKeys();
    }

    public void UpdateControls(string config)
    {
        switch (config)
        {
            case "1":
                horProfile = profile1[0];
                vertProfile = profile1[1];
                upKey = profile1[2];
                leftKey = profile1[3];
                downKey = profile1[4];
                rightKey = profile1[5];
                mouseX = profile1[6];
                mouseY = profile1[7];
                fireProjectile = profile1[8];
                currProfile = "1";
                break;
            case "2":
                horProfile = profile2[0];
                vertProfile = profile2[1];
                upKey = profile2[2];
                leftKey = profile2[3];
                downKey = profile2[4];
                rightKey = profile2[5];
                rightArr = profile2[6];
                leftArr = profile2[7];
                fireProjectile = profile2[8];
                currProfile = "2";
                break;
            case "3":
                horProfile = profile3[0];
                vertProfile = profile3[1];
                upKey = "Null";
                leftKey = "Null";
                downKey = "Null";
                rightKey = "Null";
                mouseX = profile3[2];
                mouseY = profile3[3];
                fireProjectile = profile3[4];
                currProfile = "3";
                break;
        }
    }

    public void UpdateKeyboardKeys()
    {
        UpdateControls(currProfile);

        if (!currProfile.Contains("3"))
        {
            up = (KeyCode)System.Enum.Parse(typeof(KeyCode), upKey);
            down = (KeyCode)System.Enum.Parse(typeof(KeyCode), downKey);
            left = (KeyCode)System.Enum.Parse(typeof(KeyCode), leftKey);
            right = (KeyCode)System.Enum.Parse(typeof(KeyCode), rightKey);
            turnRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), rightArr);
            turnLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), leftArr);
        }
        
        shoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), fireProjectile);
    }

    public void UpdateProfile1(string W, string A, string S, string D, string shoot)
    {
        profile1[2] = W;
        profile1[3] = A;
        profile1[4] = S;
        profile1[5] = D;
        profile1[8] = shoot;

        UpdateKeyboardKeys();
    }

    public void UpdateProfile2(string T, string F, string G, string H, string rightArrow, string leftArrow, string shoot)
    {
        profile2[2] = T;
        profile2[3] = F;
        profile2[4] = G;
        profile2[5] = H;
        profile2[6] = rightArrow;
        profile2[7] = leftArrow;
        profile2[8] = shoot;

        UpdateKeyboardKeys();
    }

    public void UpdateProfile3(string shoot)
    {
        profile3[4] = shoot;
        UpdateKeyboardKeys();
    }

    public void SwapJoysticks()
    {
        inverted = !inverted;

        if (inverted)
        {
            profile3[0] = "Horizontal_USB";
            profile3[1] = "Vertical_USB";
            profile3[2] = "4th Axis";
            profile3[3] = "5th Axis";
        }
        else
        {
            profile3[0] = "4th Axis";
            profile3[1] = "5th Axis";
            profile3[2] = "Horizontal_USB";
            profile3[3] = "Vertical_USB";
        }

        UpdateKeyboardKeys();
    }
}

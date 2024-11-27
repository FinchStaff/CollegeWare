using System;
using System.IO;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

public class SaveHandling : MonoBehaviour
{
    public static string saveDirectory = Environment.CurrentDirectory + "\\Save.savdat";
    public static bool[] bools = new bool[1];
    public static int[]  ints = {0};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!File.Exists(saveDirectory))
        {
            File.Create(saveDirectory).Close();
        }

        bools = new bool[]{ SettingsMenu.fullscreen };
        ints  = new  int[]{ SettingsMenu.resolution };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static byte MakeBoolsIntoByte(bool[] boolArray)
    {
        int integer = 0;
        for (int i = 0; i < boolArray.Length; i++)
        {
            if (boolArray[i])
            {
                integer += Convert.ToInt32(Math.Pow(2, 7 - i));
            }
        }
        byte byt = Convert.ToByte(integer);
        return byt;
    }

    public static void LoadSettings()
    {
        
        bools = new bool[]{ SettingsMenu.fullscreen };
        ints  = new  int[]{ SettingsMenu.resolution };
        try{
            FileStream fs = File.OpenRead(saveDirectory);
            int boolByte = fs.ReadByte();
            fs.Position++;
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = fs.ReadByte();
            }

            string boolByteBinary = Convert.ToString(boolByte, 2).Replace("0b", "");
            for (int i = 0; i < bools.Length; i++)
            {
                bools[i] = Convert.ToBoolean(int.Parse(boolByteBinary[i].ToString()));
            }
            SettingsMenu.resolution = ints[0];
            SettingsMenu.fullscreen = bools[0];

            fs.Close();
        }
        catch
        {
            Debug.Log("Something went wrong, taking assumption that the user somehow did something that would do this, and will put in default settings");
            SettingsMenu.fullscreen = false;
            SettingsMenu.resolution = 1;
            bools = new bool[]{ SettingsMenu.fullscreen };
            ints  = new  int[]{ SettingsMenu.resolution };
        }
    }

    public static void SaveSettings()
    {
        bools = new bool[]{ SettingsMenu.fullscreen };
        ints  = new  int[]{ SettingsMenu.resolution };
        Debug.Log("Attempting save of: "+ bools[0] + " " + ints[0]);
        try
        {
            FileStream fs = File.OpenWrite(saveDirectory);
            fs.WriteByte(MakeBoolsIntoByte(bools));
            fs.Position++;
            foreach (int i in ints)
            {
                fs.WriteByte(Convert.ToByte(i));
                fs.Position++;
            }
            fs.Close();
        }
        catch
        {
            Debug.Log("Save failed");
        }
    }
}

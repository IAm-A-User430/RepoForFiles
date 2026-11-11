using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    //veriables
    //create a number for the score
    private int score;

    //add input references for interacting with score and saving
    public InputActionReference scoreplus;
    public InputActionReference save;
    public InputActionReference clear;

    //set the folder path
    private const string DIR_RES = "/Resources";
    //set a file to read
    private const string FILE_SAVES =DIR_RES + "/SAVES.txt";

    //create the file path
    private string FILE_PATH_SAVES;

    //make a variable to hold the int as a string
    public string Inputnum; 

    //add text mesh pro variavke for previous scores, and one for current score
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI savedScores;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //declare the file path
        FILE_PATH_SAVES = Application.dataPath + FILE_SAVES;

        //set the score
        score = 0;
        
        //show all saved scores 
        savedScores.text = File.ReadAllText(FILE_PATH_SAVES);

    }

    // Update is called once per frame
    void Update()
    {
       //show the score
       currentScore.text = "" + score;
       
        //if I press a button, score goes up by 1
        if(scoreplus.action.WasPressedThisFrame())
        {
            score ++;
        }
        //if I press a button, run the same function
        if (save.action.WasPressedThisFrame())
        {
            Savescore(score);
            score = 0;
            savedScores.text = File.ReadAllText(FILE_PATH_SAVES);
        }
        //if I press a button this time, run a function that clears all the saves
        if (clear.action.WasPressedThisFrame())
        {
            ClearSaves();
        }
    }


public void Savescore(int s)
    {
        Inputnum = s.ToString();
        string fileContents = File.ReadAllText(FILE_PATH_SAVES);
        fileContents += Inputnum + "\n";
        File.WriteAllText(FILE_PATH_SAVES, fileContents);
    }

public void ClearSaves()
    {
        File.WriteAllText(FILE_PATH_SAVES, "");
    }
}
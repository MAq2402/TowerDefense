using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Class responsible for basic level management*/
/*Author: Martyna Drabińska*/
public class LevelManager : MonoBehaviour
{
    public static int currentLevelNumber = 1;
    public Text levelNumberText;

    /*Class representing basic level features*/
    /*Author: Martyna Drabińska*/
    public class LevelFeatures
    {
        public int startMoney;
        public Color sceneColor;
        public List<Dictionary<string, int>> levelWaves;
        public List<string> aditionalTurrets;
    }

    /*Author: Martyna Drabińska*/
    public readonly static Dictionary<int, LevelFeatures> levelFeatures = new Dictionary<int, LevelFeatures>()
    {
        [1] = new LevelFeatures { startMoney=350, sceneColor= new Color(0f, 0f, 1f),
            levelWaves = new List<Dictionary<string, int>>()
            {
                new Dictionary<string, int>()
                {
                      ["guardian"] = 4, ["warrior"] = 2, ["scout"] = 5
                },
                  new Dictionary<string, int>()
                {
                    ["scout"] = 5,   ["fighter"] = 1, ["warrior"] = 2, ["guardian"] = 2,
                }
                  ,
                  new Dictionary<string, int>()
                {
                    ["guardian"] = 2, ["warrior"] = 3,  ["fighter"] = 2, ["scout"] = 3
                }
            },
            aditionalTurrets = new List<string>() { }
        },
        [2] = new LevelFeatures { startMoney = 450, sceneColor = new Color(0.0f, 1f, 0f),
            levelWaves = new List<Dictionary<string, int>>()
            {
                new Dictionary<string, int>()
                {
                    ["scout"] = 6, ["sparrow"] = 1, ["warrior"] = 4, ["fighter"] = 1
                },
                  new Dictionary<string, int>()
                {
                    ["warrior"] = 2, ["scout"] = 3, ["sparrow"] = 1, ["guardian"] = 3 , ["fighter"] = 1 
                },
                   new Dictionary<string, int>()
                {
                    ["guardian"] = 2, ["sparrow"] = 1, ["scout"] = 6, ["fighter"] = 2
                },
                  new Dictionary<string, int>()
                {
                    ["scout"] = 4, ["fighter"] = 1, ["warrior"] = 3, ["sparrow"] = 2, ["guardian"] = 2
                }
            },
            aditionalTurrets = new List<string>() { "MissileLauncher"}
        },
        [3] = new LevelFeatures { startMoney = 500, sceneColor = new Color(1f, 0f, 0f),
            levelWaves = new List<Dictionary<string, int>>()
            {
             new Dictionary<string, int>()
             {
                 ["sparrow"] = 1, ["warrior"] = 2, ["scout"] = 4, ["robot"] = 2, ["fighter"] = 1 
             },
             new Dictionary<string, int>()
             {
                 ["guardian"] = 3, ["warrior"] = 2, ["sparrow"] = 1 , ["robot"] = 2, ["scout"] = 2, ["jet"] = 1
             },
             new Dictionary<string, int>()
             {
                 ["sparrow"] = 3, ["scout"] = 4, ["warrior"] = 2, ["robot"] = 1, ["jet"] = 1, ["guardian"] = 3
             },
             new Dictionary<string, int>()
             {
                 ["guardian"] = 2, ["warrior"] = 2, ["fighter"] = 2 ,["robot"] = 2, ["sparrow"] = 2, ["scout"] = 4
             },
             new Dictionary<string, int>()
             {
                 ["warrior"] = 2, ["scout"] = 4, ["fighter"] = 1 ,["robot"] = 3, ["jet"] = 2, ["guardian"] = 3
             }
            },
            aditionalTurrets = new List<string>() { "MissileLauncher", "SuperDefensive" }
        },
        [4] = new LevelFeatures { startMoney = 600, sceneColor = new Color(1f, 1f, 1f),
            levelWaves = new List<Dictionary<string, int>>()
            {
                new Dictionary<string, int>()
                {
                    ["sparrow"] = 1, ["scout"] = 6, ["warrior"] = 4,["jet"] = 1, ["robot"] = 2, ["fighter"] = 1
                },
                new Dictionary<string, int>()
                {
                    ["scout"] = 6, ["destroyer"] = 1, ["robot"] = 3 , ["warrior"] = 3, ["sparow"] = 1, ["guardian"] = 3, ["jet"] = 1
                },
                new Dictionary<string, int>()
                {
                    ["sparrow"] = 1, ["robot"] = 3, ["destroyer"] = 1, ["scout"] = 5, ["lord"] = 2, ["warrior"] = 4, ["fighter"] = 1
                },
                new Dictionary<string, int>()
                {
                    ["guardian"] = 3, ["warrior"] = 3, ["sparrow"] = 1 ,["robot"] = 2, ["destroyer"] = 1, ["scout"] = 4, ["lord"] = 2
                },
                new Dictionary<string, int>()
                {
                    ["sparrow"] = 1, ["guardian"] = 3, ["warrior"] = 2,["lord"] = 3, ["robot"] = 2, ["destroyer"] = 1, ["scout"] = 3
                },
                new Dictionary<string, int>()
                {
                    ["destroyer"] = 1, ["robot"] = 2, ["scout"] = 4, ["fighter"] = 1, ["lord"] = 3, ["sparrow"] = 2, ["warrior"] = 3
                }
            },

            aditionalTurrets = new List<string>() { "MissileLauncher", "SuperDefensive", "Laser" }
        }
    };

    /*Author: Martyna Drabińska*/
    void Start()
    {
        levelNumberText.text = $"Level: {currentLevelNumber}";
    }
   
}

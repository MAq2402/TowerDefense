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
        public Dictionary<string, int> levelWaves;
    }

    public static Dictionary<int, LevelFeatures> levelFeatures = new Dictionary<int, LevelFeatures>()
    {
        [1] = new LevelFeatures { startMoney=100, sceneColor= new Color(0f, 0f, 1f),
            levelWaves = new Dictionary<string, int>()
            {
                ["guardian"] = 1, ["warrior"] = 1, ["robot"] = 1, ["scout"] = 1 
            }
        },
        [2] = new LevelFeatures { startMoney = 200, sceneColor = new Color(0.0f, 1f, 0f),
            levelWaves = new Dictionary<string, int>()
            {
                ["guardian"] = 2, ["warrior"] = 2, ["robot"] = 2, ["scout"] = 2
            }
        },
        [3] = new LevelFeatures { startMoney = 250, sceneColor = new Color(1f, 0f, 0f),
            levelWaves = new Dictionary<string, int>()
            {
                ["guardian"] = 1, ["warrior"] = 1, ["robot"] = 1, ["scout"] = 1
            }
        },
        [4] = new LevelFeatures { startMoney = 300, sceneColor = new Color(1f, 1f, 1f),
            levelWaves = new Dictionary<string, int>()
            {
                ["guardian"] = 1, ["warrior"] = 1, ["robot"] = 1, ["scout"] = 1
            }
        }
    };

    /*Author: Martyna Drabińska*/
    void Start()
    {
        levelNumberText.text = $"Level: {currentLevelNumber}";
    }
   
}

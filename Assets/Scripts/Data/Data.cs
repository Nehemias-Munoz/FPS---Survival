using UnityEngine;

public static class Data
{
    public static string scoreKey = "playerScore";
    public static string livesKey = "playerLives";
    public static string levelKey = "playerLevel";
    public static string czombiesKey = "cantZombies";


    public static int GetLives()
    {
        var lives = PlayerPrefs.HasKey(livesKey) ? PlayerPrefs.GetInt(livesKey) : 3;
        return lives;
    }
    public static int GetScore()
    {
        var score = PlayerPrefs.HasKey(scoreKey) ? PlayerPrefs.GetInt(scoreKey) : 0;
        return score;
    }
    public static int GetLevel()
    {
        var level = PlayerPrefs.HasKey(levelKey) ? PlayerPrefs.GetInt(levelKey) : 1;
        return level;
    }

    public static int GetCzombies()
    {
        var cantZombies = PlayerPrefs.HasKey(czombiesKey) ? PlayerPrefs.GetInt(czombiesKey) : 5;
        return cantZombies;
    }

    public static void SetLives(int value)
    {
        PlayerPrefs.SetInt(livesKey,value);
    } 
    public static void SetScore(int value)
    {
        PlayerPrefs.SetInt(scoreKey,value);
    } 
    public static void SetLevel(int value)
    {
        PlayerPrefs.SetInt(levelKey,value);
    }

    public static void SetCZombies(int value)
    {
        PlayerPrefs.SetInt(czombiesKey,value);
    }
    
}

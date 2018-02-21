using System;
using UnityEngine;
using System.Collections.Generic;

public class Difficulty : MonoBehaviour
{
    #region Structs

    [Serializable]
    public struct Difficulties
    {
        public string difficulty;
        public DifficultyLevels difficultyLevel;
        public int minRange;
        public int maxRange;
    }

    #endregion Structs

    #region Fields

    [SerializeField]
    private DifficultyLevels currentDifficult;
    [SerializeField]
    private List<Difficulties> difficultyList;
    private static IList<Difficulties> difficultStaticList;
    private static DifficultyLevels currentStaticDifficult;

    #endregion Fields

    #region Properties

    public static IList<Difficulties> DifficultStaticList
    {
        get
        {
            return difficultStaticList;
        }

        set
        {
            difficultStaticList = value;
        }
    }

    public static DifficultyLevels CurrentStaticDifficult
    {
        get
        {
            return currentStaticDifficult;
        }

        set
        {
            currentStaticDifficult = value;
        }
    }

    #endregion Properties

    #region Enums

    public enum DifficultyLevels
    {
        VeryEasy = 0,
        Easy = 1,
        Medium = 2,
        Hard = 3,
        VeryHard = 4,
        Insane = 5,
        God = 6
    }

    #endregion Enums

    #region Methods

    public static Difficulties GetCurrentDifficult()
    {
        foreach (var diff in DifficultStaticList)
        {
            if (CurrentStaticDifficult == diff.difficultyLevel)
            {
                return diff;
            }
        }

        return DifficultStaticList[0];
    }

    #endregion Methods

    #region UnityMethods

    private void Start()
    {
        DifficultStaticList = difficultyList;
        CurrentStaticDifficult = currentDifficult;
    }

    #endregion UnityMethods
}

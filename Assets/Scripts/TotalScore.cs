using UnityEngine;

[CreateAssetMenu(fileName = "TotalScore", menuName = "ScriptableObjects/TotalScore")]
public class TotalScore : ScriptableObject
{
    [SerializeField] private int[] _scores;

    private int _totScore = default;

    /// <summary>
    /// Property to show player's total score after winning or losing the game,
    /// in the respective screens
    /// </summary>
    /// <value> Total scores </value>
    public int TotScore
    {
        get => _totScore;

        set
        {
            for (int i = 0; i < _scores.Length; i++)
            {
                _totScore += _scores[i];
            }
        }

    }
    
    /// <summary>
    /// Awake is called when the script instance is being loaded. To be used in
    /// LevelUI object to initialize the array size
    /// </summary>
    public void Awake()
    {
        _scores = new int[10];
    }


    /// <summary>
    /// Method to save level score in the array if "slot" has value of zero
    /// </summary>
    /// <param name="levelScore"> Score to be saved </param>
    public void SaveScore(float levelScore)
    {
        int aux = (int)levelScore;

        for (int i = 0; i < _scores.Length; i++)
        {
            if (_scores[i] == 0)
            {
                _scores[i] = aux;
                break;
            }
            else
            {
                continue;
            }
        }
    }

    /// <summary>
    /// Method to reset scores after game win or loss.null To be used in previews
    /// respective screens
    /// </summary>
    public void ResetScores()
    {
        for (int i = 0; i < _scores.Length; i++)
        {
            _scores[i] = 0;
        }
    }
}

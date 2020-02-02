using UnityEngine;
using UnityEngine.SceneManagement;

public class Station : MonoBehaviour
{
    private float _repairPercentage = default;
    private int _stationHP = default;
    public float RepairPercentage => _repairPercentage;
    public int StationHP => _stationHP;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _stationHP = 100;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        _repairPercentage += 0.67f * Time.deltaTime;

        if (_repairPercentage >= 100)
        {
            _repairPercentage = 0;
            _stationHP = 100;
        }

        if (_stationHP == 0)
        {
            //SceneManager.LoadScene("GameOver");
        }
    }

    /// <summary>
    /// Method to be used when an enemy entity strikes the station
    /// </summary>
    /// <param name="dmg"> Damage value </param>
    public void TakeHit(int dmg)
    {
        _stationHP -= dmg;
    }

    /// <summary>
    /// Method to be used when player strikes an enemy entity that can speed up
    /// the repair time
    /// </summary>
    /// <param name="repairValue"></param>
    public void SpeedRepair(int repairValue)
    {
        _repairPercentage += repairValue;
    }
}

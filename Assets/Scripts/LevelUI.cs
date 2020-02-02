using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private Text _scoreText = default;
    [SerializeField] private Text _repairText = default;
    [SerializeField] private Text _hpText = default;
    [SerializeField] private TotalScore _tScore = default;
    private float _levelScore = default;
    private GameObject _station = default;
    private Station _sScript = default;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _station = GameObject.Find("Station");
        _sScript = _station.GetComponent<Station>();
        _tScore.Awake();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        _levelScore += 15 * Time.deltaTime;
        _scoreText.text = _levelScore.ToString("0");
        _repairText.text = $"{_sScript.RepairPercentage.ToString("0")}%";
        _hpText.text = $"Station's HP: {_sScript.StationHP}";

        if (_sScript.RepairPercentage >= 99.99)
        {
            _tScore.SaveScore(_levelScore);
        }
    }
}

using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private UnitType typeOfUnit;

    public int cplus;
    public int csharp;
    public int java;
    public int javascript;
    public int html;
    public int css;

    void RandomizeStatsLow()
    {
        cplus = Random.Range(1, 20);
        csharp = Random.Range(1, 20);
        java = Random.Range(1, 20);
        javascript = Random.Range(1, 20);
        html = Random.Range(1, 20);
        css = Random.Range(1, 20);
    }

    void SetStatsHigh()
    {
        cplus = 99;
        csharp = 99;
        java = 99;
        javascript = 99;
        html = 99;
        css = 99;
    }

    // Use this for initialization
    void Start () {
        switch ((int)typeOfUnit)
        {
            case 0:
                RandomizeStatsLow();
                break;
            case 1:
                SetStatsHigh();
                break;
            default:
                RandomizeStatsLow();
                break;
        }
	}
}

public enum UnitType
{
    Bad = 0,
    Great = 1
}

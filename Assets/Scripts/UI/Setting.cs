using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

enum SettingType
{
    Decimal,
    Percentage,
    Time
};
public class Setting : MonoBehaviour
{
    public string namee;
    public int val = 5;
    public int maxVal = 10;
    public int minVal = 0;
    public TextMeshProUGUI valLabel;
    [SerializeField] SettingType type = new SettingType();


    private void Start()
    {
        val = PlayerPrefs.GetInt(namee);
        Debug.Log(PlayerPrefs.GetInt(namee));
        ShowData();
    }

    public void Next(int multiplier)
    {
        if (val >= maxVal) return;
        MenuSoundManager.Instance.PlayNextPageSfx();
        val +=multiplier;
        if (val > maxVal) val = maxVal;
        ShowData();
    }

    public void Previous(int multiplier)
    {
        if (val <= minVal) return;
        MenuSoundManager.Instance.PlayPreviousPageSfx();
        val -=multiplier;
        if (val < minVal) val = minVal;
        ShowData();
    }

    void ShowData()
    {
        if (type == SettingType.Percentage) valLabel.text = val * 10 + "%";
        else if (type == SettingType.Decimal) valLabel.text = val.ToString();
        else if(type == SettingType.Time) valLabel.text = val * 10 / 60 + ":" + val * 10 % 60;
    }
}

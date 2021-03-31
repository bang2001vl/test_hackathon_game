using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    public static int MAX_ROW = 7;
    public static char SEPERATE_CHARACTER = '%';
    [SerializeField] GameObject rowTitle;
    [SerializeField] GameObject rowPrefab;

    public void showHighScore()
    {
        List<Rows> rows = LoadPref();
        Vector3 distance = new Vector3(0, 80, 0);
        for (int i = 0; i < rows.Count; i++)
        {
            GameObject gameObject = GameObject.Instantiate(rowPrefab);
            gameObject.transform.position = rowPrefab.transform.position + i * distance;

            Text[] childs = gameObject.GetComponents<Text>();
            childs[0].text = rows[i].PlayerName;
            childs[1].text = rows[i].BestLevel.ToString();
            childs[2].text = (System.TimeSpan.FromMilliseconds(rows[i].BestTime)).ToString("HH:mm:ss");
        }
    }

    public static List<Rows> LoadPref()
    {
        List<Rows> rs = new List<Rows>(MAX_ROW);
        for (int i = 0; i < MAX_ROW; i++)
        {
            Rows row = Rows.fromPreference(i);
            if (row != null)
            {
                rs.Add(row);
            }
            else
            {
                break;
            }
        }
        return rs;
    }

    public static bool Report(Rows row)
    {
        List<Rows> rows = LoadPref();
        if (rows[rows.Count - 1].BestTime >= row.BestTime)
        {
            return false;
        }

        rows.Add(row);
        rows.Sort(new RowComparer());

        if (rows.Count > MAX_ROW)
        {
            rows.RemoveAt(rows.Count - 1);
        }

        for (int i = 0; i < rows.Count; i++)
        {
            rows[i].Save(i);
        }

        PlayerPrefs.Save();

        return true;
    }

    public class Rows
    {
        public string PlayerName;
        public int BestTime; // In millis
        public int BestLevel;
        public void Save(int order)
        {
            PlayerPrefs.SetString(string.Format("HighScore_{0}", order), PlayerName);
            PlayerPrefs.SetInt(string.Format("HighScore_{0}_time", order), BestTime);
            PlayerPrefs.SetInt(string.Format("HighScore_{0}_lv", order), BestLevel);
        }
        public static Rows fromPreference(int order)
        {
            Rows row = new Rows();
            row.PlayerName = PlayerPrefs.GetString(string.Format("HighScore_{0}", order), null);
            if (row.PlayerName == null) return null;
            row.BestTime = PlayerPrefs.GetInt(string.Format("HighScore_{0}_time", order));
            row.BestLevel = PlayerPrefs.GetInt(string.Format("HighScore_{0}_lv", order));
            return row;
        }
    }

    public class RowComparer : IComparer<Rows>
    {
        public int Compare(Rows x, Rows y)
        {
            if (x.BestLevel == y.BestLevel)
            {
                return x.BestTime.CompareTo(y.BestTime);
            }

            return x.BestLevel.CompareTo(y.BestLevel);
        }
    }
}

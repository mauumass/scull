using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public BoatController bc;
    public GameObject panel;
    public GameObject canvas;
    public UnityEngine.UI.Text hsText;
    public string level;

    private void OnTriggerEnter(Collider collider)
    {
        bc.canMove = false;
        SaveAndSortScores();
        canvas.SetActive(true);
        panel.SetActive(true);
        string scores = System.IO.File.ReadAllText(level + "scores.txt");
        hsText.text = scores;
    }

    public class Tuple<T1, T2>
    {
        public T1 First { get; private set; }
        public T2 Second { get; private set; }
        internal Tuple(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }
    }

    public static class Tuple
    {
        public static Tuple<T1, T2> New<T1, T2>(T1 first, T2 second)
        {
            var tuple = new Tuple<T1, T2>(first, second);
            return tuple;
        }
    }

    private void SaveAndSortScores()
    {
        float time = Time.timeSinceLevelLoad;
        string[] lines = System.IO.File.ReadAllLines(level + "scores.txt");
        string name = PlayerPrefs.GetString("name");

        if (lines.Length < 3)
        {
            System.IO.File.AppendAllText(level + "scores.txt", name + " " + time.ToString() + System.Environment.NewLine);
        }
        else
        {
            string top5 = "";
            List<Tuple<string, float>> scores = new List<Tuple<string, float>>();
            scores.Add(new Tuple<string, float>(name, time));

            foreach (string line in lines)
            {
                string[] splitstring = line.Split(' ');
                scores.Add(new Tuple<string, float>(splitstring[0], float.Parse(splitstring[1])));
            }

            scores.Sort((x, y) => x.Second.CompareTo(y.Second));

            for (int i = 0; i < 3; i++)
            {
                Tuple<string, float> nameScore = scores[i];
                top5 += nameScore.First + " " + nameScore.Second.ToString() + System.Environment.NewLine;
            }

            System.IO.File.WriteAllText(level + "scores.txt", top5);
        }
    }
}

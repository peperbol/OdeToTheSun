using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;

public class BeatSequence {
    public const int MEASURELENGHT = 4;
    public const string BARIER = "########";
    public const char NONE = '-';
    public const char HOLD = 'h';
    public const char RELEASE = 'r';
    public const string Path = "/sequence.txt";

    public bool[,] data;
    public BeatSequence(string path) {

        Load(path);
    }
    public void Load(string path) {
        List<bool[]> bools = new List<bool[]>();
        string line;
        try
        {
            StreamReader theReader = new StreamReader(Application.streamingAssetsPath + path, Encoding.Default);
            do
            {
                line = theReader.ReadLine();

                if (!(line == null || line == BARIER))
                {

                    bools.Add(new bool[] { line[0] != NONE, line[1] != NONE, line[2] != NONE, line[3] != NONE, line[4] != NONE, line[5] != NONE, line[6] != NONE, line[7] != NONE, (line.Length > 8) ? line[8] == HOLD : false, (line.Length > 8) ? line[8] == RELEASE : false });

                }
            } while (line != null);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            data = new bool[1, 10];
            return;
        }
        data = new bool[bools.Count, 10];
        for (int x = 0; x < bools.Count; x++)
        {
            bool[] e = bools[x];
            for (int y = 0; y < e.Length; y++)
            {
                data[x, y] = e[y];
            }
        }
    }
    public void Write(string path) {
        if (File.Exists(Application.streamingAssetsPath + path)) {
            File.Delete(Application.streamingAssetsPath + path);
        }
        StreamWriter sr = File.CreateText(Application.streamingAssetsPath + path);
        for (int x = 0; x < data.GetLength(0); x++)
        {
            if (x % MEASURELENGHT == 0) {
                sr.WriteLine(BARIER);
            }
            string line = "";
            for (int i = 0; i < 8; i++)
            {
                line += (data[x, i]) ? "X" : NONE.ToString();
            }
            if (data[x, 8]) {
                line += HOLD.ToString();
            } else if (data[x,9])
            {
                line += RELEASE.ToString();
            }
            sr.WriteLine(line);
        }
        sr.Close();
    }
    public void Resize(int length) {
        if (length != data.GetLength(0))
        {
            bool[,] oldData = data;
            data = new bool[length, 10];
            for (int x = 0; x < data.GetLength(0) && x < oldData.GetLength(0); x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    data[x, y] = oldData[x, y];
                }
            }
        }
    }
}

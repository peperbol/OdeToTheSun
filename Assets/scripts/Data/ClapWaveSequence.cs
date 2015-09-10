using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ClapWaveSequence
{

  public const int MEASURELENGHT = 4;
  public const string BARIER = "########";
  public const char NONE = '-';
  public const char HOLD = 'h';
  public const char RELEASE = 'r';

  public static ClapWaveSequence LoadSequenceFile(string fileName, float timePerBeat)
  {
    ClapWaveSequence waveSequence = new ClapWaveSequence();
    StreamReader reader = null;
    try
    {
      string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
      reader = new StreamReader(filePath, System.Text.Encoding.Default);
    }
    catch (System.Exception e)
    {
      Debug.LogWarning("Cant read \"" + fileName + "\"" + e.StackTrace);
      return null;
    }
    string line = reader.ReadLine();


    do
    {
      bool[] claps = new bool[8];
      if (line[0] == BARIER[0])
      {
        line = reader.ReadLine();
        continue;
      }

      for (int i = 0; i < 8; i++)
        claps[i] = line[i] != NONE;
      bool hold = line.Length > 8 && line[8] == HOLD;
      bool release = line.Length > 8 && line[8] == RELEASE;
      ClapWave wave = new ClapWave(claps, hold, release);
      waveSequence.Add(wave);

      /*
      Debug.Log(line);
      Debug.Log(wave.ToString());
      */
      line = reader.ReadLine();
    } while (line != null);

    waveSequence.GenerateTimeStamps(timePerBeat);
    return waveSequence;
  }
  public static void SaveSequenceFile(string fileName, float timePerBeat, ClapWaveSequence seq)
  {
    if (File.Exists(Application.streamingAssetsPath + fileName))
    {
      File.Delete(Application.streamingAssetsPath + fileName);
    }
    StreamWriter sr = File.CreateText(Application.streamingAssetsPath + fileName);

    for (int x = 0; x < seq.Count(); x++)
    {
      if (x % MEASURELENGHT == 0)
      {
        sr.WriteLine(BARIER);
      }
      string line = "";
      ClapWave wave = seq.GetWave(x);
      for (int i = 0; i < 8; i++)
      {
        line += (wave.Notes[i]) ? "X" : NONE.ToString();
      }
      if (wave.Hold)
      {
        line += HOLD.ToString();
      }
      else if (wave.Release)
      {
        line += RELEASE.ToString();
      }
      sr.WriteLine(line);
    }

    sr.Close();
  }
  List<ClapWave> waves;

  public ClapWaveSequence()
  {
    waves = new List<ClapWave>();
  }

  public void Add(ClapWave wave)
  {
    wave.SetId(Count() + 1);
    waves.Add(wave);
  }
  public void SetLength(int length)
  {
    float diff = length - Count();
    while (diff != 0)
    {
      if (diff < 0)
      {
        waves.RemoveAt(Count() - 1);
      }
      else
      {
        Add(new ClapWave(new bool[8], false, false));
      }
      diff = length - Count();
    }
  }

  public void GenerateTimeStamps(float timePerBeat)
  {
    for (int i = 0; i < waves.Count; i++)
      waves[i].SetTimeStamp(timePerBeat * i);
  }

  public int Count()
  {
    return waves.Count;
  }

  public ClapWave GetWave(int waveId)
  {
    return waves[waveId];
  }

  public void ApplyTimestampOffset(float offset)
  {
    // TODO
  }
}

public class ClapWave
{

  private int id;       // Id of the wave in the sequence (0-Count)
  private bool[] notes;
  private bool hold;
  private bool release;
  private float timeStamp = 0;

  public ClapWave(bool[] notes, bool hold = false, bool release = false)
  {
    this.notes = notes;
    this.hold = hold;
    this.release = release;
  }
  public bool[] Notes
  {
    get { return notes; }
  }

  public bool Release
  {
    get
    {
      return release;
    }

    set
    {
      release = value;
    }
  }

  public bool Hold
  {
    get
    {
      return hold;
    }

    set
    {
      hold = value;
    }
  }

  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetTimeStamp(float timeStamp)
  {
    this.timeStamp = timeStamp;
  }

  public float GetTimeStamp()
  {
    return timeStamp;
  }

  public override string ToString()
  {
    string str = "";

    for (int i = 0; i < notes.Length; i++)
    {
      if (notes[i])
        str += "x";
      else
        str += "-";
    }

    if (release)
      str += " release";
    if (hold)
      str += " hold";

    return str;
  }

}

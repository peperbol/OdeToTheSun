using UnityEngine;
using System.Collections;
using System;

public class EndOfGame : MonoBehaviour
{
    public Vector3 endPos;
    public float endSize;
    public float dayDelay;
    public float nightDelay;
    public float afterDelay;
    public float creditFade;
    public float zoomTime;
    public SpriteRenderer scenery;
    public SpriteRenderer credit;
    public SpriteRenderer title;
    public Sprite day;
    public Sprite night;
    private bool restartable = false;
    private bool ended = false;
    public void End()
    {
        if (!ended)
        {
            GameObject.FindObjectOfType<SongPlayer>().playing = false;
            StartCoroutine(ZoomOut());
            ended = true;
        }
    }

    private IEnumerator ZoomOut()
    {
        bool finish = GameProgress.Progress > 0.75f;
        float p = GameProgress.Progress;
        float startSize = Camera.main.orthographicSize;
        Vector3 startPos = Camera.main.transform.position;

        VisualFadeOnEndGame[] faders = GameObject.FindObjectsOfType<VisualFadeOnEndGame>();
        for (int i = 0; i < faders.Length; i++)
        {
            faders[i].EndGame();
        }

        scenery.sprite = (finish) ? day : night;
        float time = 0;
        while (time < ((finish) ? dayDelay : nightDelay))
        {
            time += Time.deltaTime;
            if (!finish)
            {
                GameProgress.Progress = Mathf.Lerp(p, 0, time / nightDelay);
            }
            yield return null;
        }
        time = 0;
        while (time < zoomTime)
        {
            time += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(startPos, endPos, time / zoomTime);
            Camera.main.orthographicSize = Mathf.Lerp(startSize, endSize, time / zoomTime);
            yield return null;
        }
        time = 0;
        while (time < afterDelay)
        {

            time += Time.deltaTime;
            yield return null;
        }

        time = 0;
        while (time < creditFade)
        {
            time += Time.deltaTime;
            Color c = credit.color;
            c.a = Mathf.Lerp(0, 1, time / creditFade);
            credit.color = c;
            title.color = c;
            yield return null;
        }
        restartable = true;
        yield return null;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (restartable)
        {
            bool press = false;
            for (int i = 0; i < GameProperties.NUMBER_OF_COLORS; i++)
            {
                press |= InputController.GetPress((SolarColor)i);

            }
            if (GameProperties.Platform == GameProperties.InputPlatform.MOBILE)
            {
                press |= Input.GetMouseButtonDown(0);
            }
            if (press)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}

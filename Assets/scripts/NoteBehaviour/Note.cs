using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{

  public float fadeoutSpeed = 0.1f;
  private bool arriving = false;
  private Colors color;
  public AudioClip miss;
  public AudioClip hit;
  public AudioPlay src;
  private SpriteRenderer spriteRenderer;
  public Colors ColorOfNote
  {
    get { return color; }
    set { color = value; }
  }
  private bool activated;
  // Use this for initialization
  void Start()
  {
    spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    spriteRenderer.sprite = color.GetSprite();
  }

  // Update is called once per frame
  void Update()
  {
    if (arriving)
    {
      Color color = spriteRenderer.color;
      color.a -= fadeoutSpeed;
      spriteRenderer.color = color;
      Destroy(GetComponent<Renderer>());
    }
  }
  public void Activate()
  {
    activated = true;
  }

  public void Validate()
  {
    // Debug.Log("val");
    if (activated)
    {
      // Debug.Log("Activated arrive");
      GameProgress.HitBeat();
      AudioPlay.PlaySound(hit, src);
    }
    else
    {
      // Debug.Log("unactivated arrive");
      GameProgress.MissBeat();
      Camera.main.GetComponent<RandomShake>().PlayShake();
      AudioPlay.PlaySound(miss, src);
    }
    Destroy(gameObject);
  }
  public void Arrive()
  {
    //Debug.Log("arrived");
    arriving = true;
  }


}

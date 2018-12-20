using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAndFadeScript : MonoBehaviour {

    [SerializeField] float direction = 1;
    [SerializeField] float speed;
    [SerializeField] float fadeTime;

    float Direction { get { return direction; } set { direction = value; } }
    float Speed { get { return speed; } set { speed = value; } }
    float FadeTime { get { return fadeTime; } set { fadeTime = value; } }

    float timePassed;

    private void Start()
    {
        if (direction == 0)
            direction = 1;
    }
    // Use this for initialization
    public void Initialise(float speed, float fTime)
    {

        Speed = speed;
        fadeTime = fTime;
    }
    public void Initialise( float speed, float fTime, float dir)
    {
        Initialise(speed, fTime);
        Direction = dir;
    }
    void Float()
    {
        gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + (speed * direction));
    }

    void Fade()
    {
        GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1f, 0f, FadeTime*timePassed);
    }
	// Update is called once per frame
	void Update ()
    {
        Float();
        Fade();
        timePassed += Time.deltaTime;

        if (GetComponent<CanvasGroup>().alpha <= 0f)
            Destroy(gameObject);
	}
}

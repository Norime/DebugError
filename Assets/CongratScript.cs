using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    
    private List<string> TextToDisplay = new List<string>();
    
    [SerializeField] private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;
    
    // Start is called before the first frame update
    void Start()
    {
        SparksParticles = gameObject.AddComponent<ParticleSystem>();
        TimeToNextText = 0.0f;
        CurrentText = 0;
        
        RotatingSpeed = 0.2f;

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[0];
        
        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        SparksParticles.transform.Rotate(new Vector3(0, 0, 20), RotatingSpeed);
        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;
            
            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }
            Text.text = TextToDisplay[CurrentText];
        }
        //RotatingSpeed
    }
}
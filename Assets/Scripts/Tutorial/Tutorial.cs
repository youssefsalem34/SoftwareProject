using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private int steps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(steps == 1)
        {
            FirstStep();
            AddStep(1);
        }
        else if(steps == 2)
        {
            SecondStep();
            AddStep(1);
        }
        else if(steps == 3)
        {
            ThirdStep();
            AddStep(1);
        }
    }

    public int AddStep(int m)
    {
        steps -= m;
        return steps;
    }


    void FirstStep()
    {

    }

    void SecondStep()
    {

    }


    void ThirdStep()
    {

    }
}

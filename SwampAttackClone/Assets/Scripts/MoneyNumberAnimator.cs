using System.Collections;
using UnityEngine;
using TMPro;

public class MoneyNumberAnimator : MonoBehaviour
{
    [SerializeField]
    private double _current;

    [SerializeField]
    private int _destination;

    [SerializeField]
    private float _duration = 3;

    [SerializeField]
    private TextMeshProUGUI _number;

    private bool isWorking = false;

    public void SetStartProps(int current, int destination)
    {
        _current = current;
        _destination = destination;

        _number.text = _current.ToString();
    }

    public void StartAnimation(int destination)
    {
        if (isWorking)
        {
            StopAllCoroutines();
        }
        else
        {
            _destination = destination;
            StartCoroutine(ChangeNumber());
        }
    }

    private IEnumerator ChangeNumber()
    {
        isWorking = true;
        float count = _duration / Time.deltaTime;
        double step = (_destination - _current) / count;

        int i = 0;
        while (i < count)
        {
            _current += step;
            var text = (int)_current;
            _number.text = text.ToString();
            i++;
            yield return new WaitForSeconds(Time.deltaTime);
            isWorking = false;
        }
    }
}

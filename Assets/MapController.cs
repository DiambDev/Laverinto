using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MapController : MonoBehaviour
{
    
    [SerializeField] GameObject Meta;
    [SerializeField] PlayerMove _p1;
    [SerializeField] GameObject _muro1;
    [SerializeField] PlayerMove _p2;
    [SerializeField] GameObject _muro2;
    [SerializeField] UnityEvent Win1;
    [SerializeField] UnityEvent Win2;
    bool time1=true;
    bool time2=true;
    void Start() 
    {
        _p1.LLegar += WIN1;
        _p2.LLegar += WIN2;
    }

    void Update()
    {
        
    }

    public void WIN1()
    {
        Win1?.Invoke();
    }
    public void WIN2()
    {
        Win2?.Invoke();
    }

    public void Trampa1()
    {
        if (time1==true)
        {
            StartCoroutine(Espera1());
        }
        
    }
    IEnumerator Espera1()
    {
        GameObject tmp = Instantiate(_muro1, _p1.transform.position,Quaternion.identity);
        tmp.SetActive(true);
        time1 = false;
        yield return new WaitForSecondsRealtime(7);
        Destroy(tmp,1);
        yield return new WaitForSecondsRealtime(20);
        time1 = true;
    }
    public void Trampa2()
    {
        if (time1 == true)
        {
            StartCoroutine(Espera2());
        }

    }
    IEnumerator Espera2()
    {
        GameObject tmp = Instantiate(_muro2, _p2.transform.position, Quaternion.identity);
        tmp.SetActive(true);
        time2 = false;
        yield return new WaitForSecondsRealtime(7);
        Destroy(tmp, 1);
        yield return new WaitForSecondsRealtime(20);
        time2 = true;
    }
}

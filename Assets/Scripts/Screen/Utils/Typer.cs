using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float timeBetweenLetters;
    public string frase;

    private void Awake()
    {
        textMesh.text = "";
    }


    [NaughtyAttributes.Button]
    public void StartType()
    {
        StartCoroutine(Type(frase));
    }


    IEnumerator Type(string s)
    {
        textMesh.text = "";
        foreach(char l in s.ToCharArray()) //para cada caracter dentro do character array da string s
        {
            textMesh.text += l;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }






}

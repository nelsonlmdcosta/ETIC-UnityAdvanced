using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPlayerDiedAnimateDeathScreen : MonoBehaviour
{
    private TMP_Text TextObject;

    private void Awake()
    {
        TextObject = GetComponent<TMP_Text>();
    }

    public void OnPlayerDied()
    {
        StartCoroutine(AnimateEndSequence());
    }

    public IEnumerator AnimateEndSequence()
    {
        while (TextObject.color.a <= 1.0f)
        {
            Color TempColor = TextObject.color;
            TempColor.a += Time.deltaTime;
            TextObject.color = TempColor;

            yield return null;
        }

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("Events Delegates Etc");
    }
}

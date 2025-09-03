using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_canvasGroup;
    [SerializeField] private Image m_fadePanel;
    [SerializeField] private float m_fadeDuration;

    private bool m_isActive;

    // フェードアウト
	public void FadeOut(bool isActive)
    {
        m_isActive = isActive;
        StartCoroutine(Fade(1, 0));
    }

    // フェードイン
    public void FadeIn(bool isActive)
    {
		m_isActive = isActive;
		StartCoroutine(Fade(0, 1));
    }

    // フェードの処理
    IEnumerator Fade(float start, float end)
    {
        m_fadePanel.enabled = true;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / m_fadeDuration;
            m_canvasGroup.alpha = Mathf.Lerp(start, end, t);
            yield return null;
        }
        m_canvasGroup.alpha = end;

        if (m_isActive)
        {
            SceneController();
        }
    }

    // シーン遷移
    public void SceneController()
    {
		if (SceneManager.GetActiveScene().name == "TitleScene")
		{
			SceneManager.LoadScene("GameScene");
		}
		else
		{
			SceneManager.LoadScene("TitleScene");
		}
	}
}

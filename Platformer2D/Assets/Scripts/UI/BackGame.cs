using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGame : MonoBehaviour
{
    // Vari�veis para controlar o estado do jogo
    private bool isPaused = true;

    // Refer�ncia ao menu de pausa (caso voc� tenha um UI)
    public GameObject pauseMenu;

    void Update()
    {
        // Verifica se o jogador pressionou a tecla ESC
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    // Fun��o para pausar o jogo
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // O jogo ser� pausado
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true); // Ativa o menu de pausa (se tiver)
        }
    }

    // Fun��o para retomar o jogo
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // O jogo retorna ao normal
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false); // Desativa o menu de pausa
        }
    }

    // Fun��o para sair do jogo (caso tenha um bot�o para sair)
    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}

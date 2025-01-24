using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGame : MonoBehaviour
{
    // Variáveis para controlar o estado do jogo
    private bool isPaused = true;

    // Referência ao menu de pausa (caso você tenha um UI)
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

    // Função para pausar o jogo
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // O jogo será pausado
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true); // Ativa o menu de pausa (se tiver)
        }
    }

    // Função para retomar o jogo
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // O jogo retorna ao normal
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false); // Desativa o menu de pausa
        }
    }

    // Função para sair do jogo (caso tenha um botão para sair)
    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}

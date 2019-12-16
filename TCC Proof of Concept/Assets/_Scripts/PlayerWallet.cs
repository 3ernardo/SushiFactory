using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public static PlayerWallet instance;
    private float playerMoney;

    void Awake() {
        instance = this;
    }

    public float getMoney(){
        return playerMoney;
    }

    public void setMoney(float value) {
        playerMoney = value;
    }

    public bool checkForCredit(float value) {
        Debug.Log("Testando fundos: Saldo - " + playerMoney + ", Teste - " + value);
        if (playerMoney >= value) {
            Debug.Log("Testando fundos: Sucesso");
            return true;
        } else {
            Debug.Log("Testando fundos: Falha");
            return false;
        }
    }
    
    public void removeMoney(float value) {
        if (playerMoney >= value) {
            playerMoney = playerMoney - value;
        } else {
            Debug.Log("Erro: Não há dinheiro suficiente para realizar esta operação.");
        }
    }

    public void addMoney(float value) {
        if (value > 0) {
            playerMoney = playerMoney + value;
        } else {
            Debug.Log("Erro: Tentativa de adição de valor zero ou inferior.");
        }
    }
}

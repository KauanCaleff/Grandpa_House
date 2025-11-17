using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MatchItem : MonoBehaviour, IPointerDownHandler, IDragHandler,IPointerEnterHandler,IPointerUpHandler 
// Pointerdownrender = cria a linha, drahandler = move a ponta da linha com, pointerenter = atualiza o que esta sob o mouse, pointerup = vê se tá certo ou errado
{
    static MatchItem hoverItem; // item que está sobre o cursor

    public GameObject linePrefab;
    public string itemName;

    private GameObject line;

    public void OnPointerDown(PointerEventData eventData){ // quando aperta o mouse em cima deste item
        line = Instantiate(linePrefab, transform.position, Quaternion.identity,transform.parent.parent); // cria a linha father
        UpdateLine(eventData.position); // atualiza até a posição atual do mouse
    }

    public void OnDrag(PointerEventData eventData){
        UpdateLine(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData){ // quando solta o botao do mouse
        if (!this.Equals(hoverItem) && itemName.Equals(hoverItem.itemName)){
            UpdateLine(hoverItem.transform.position); // termina a linha na posição do item
            MatchLogic.AddPoint();
            Destroy(hoverItem); // destroi os dois itens 
            Destroy(this);
        }
        else {
            Destroy(line); // se não é o mesmo nome, apaga a linha
        }
    }

    public void OnPointerEnter(PointerEventData eventData){ // quando o mouse entra na área do item
        hoverItem = this;
    }

    void UpdateLine(Vector3 position){
        Vector3 direction = position - transform.position; // calcula a direção do ponto inicial e atual
        line.transform.right = direction; // rotaciona a linha para a direção do mouse

        line.transform.localScale = new Vector3(direction.magnitude, 1, 1); // ajusta o tamanho da linha
    }
}

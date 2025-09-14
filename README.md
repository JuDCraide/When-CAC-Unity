![Logo](https://raw.githubusercontent.com/JuDCraide/When-CAC/main/frontend/public/images/logo-no-bg.png)

# When CAC - Versão Unity

Este é o cliente do jogo "When CAC", desenvolvido na engine **Unity**. Ele se conecta ao mesmo backend da [versão web](https://github.com/JuDCraide/When-CAC), permitindo que os jogadores testem seus conhecimentos sobre os vídeos do canal **[Cadê a Chave?](https://www.youtube.com/@cadeachave)** em uma aplicação desktop.

## 🎮 Como Jogar

A jogabilidade é a mesma da versão web: ao longo de 5 rodadas, seu objetivo é adivinhar o **número do episódio** e a **data de publicação** de um vídeo, utilizando apenas seu título e thumbnail como dicas. Sua pontuação é calculada com base na precisão dos seus palpites.

### Modos de Jogo
* **Aleatório:** Inicia um jogo com 5 vídeos aleatórios.
* **Com Seed:** Permite inserir uma "semente" de um jogo anterior para jogar com a mesma sequência de vídeos e desafiar seus amigos.

### Onde jogar
* **Site Web** - Jogue em https://when-cac.vercel.app/
* **Unity Android APKPure** - Baixe o apk em APKPure https://apkpure.com/p/com.JuliaDCraide.WhenCAC
* **Unity Android itch.io** - Baixe o apk pelo itch.io em https://judcraide.itch.io/when-cac
* **Unity Web** - Jogue em https://judcraide.itch.io/when-cac
* **Unity Windows** - Baixe o installer em https://judcraide.itch.io/when-cac ou baixe o zip com executável no mesmo link

## 🛠️ Detalhes Técnicos

* **Engine:** Unity 2022.3.4f1
* **Linguagem:** C#
* **Comunicação com Backend:** O jogo utiliza `UnityWebRequest` para se comunicar com a API do backend, buscando informações dos vídeos e enviando as respostas dos jogadores para calcular a pontuação.

### Principais Scripts

O núcleo do jogo está localizado em `Assets/Script/`. Alguns dos scripts mais importantes são:

* **`GameManager.cs`**: Um script estático (singleton) que gerencia o estado do jogo entre as diferentes cenas, como informações da partida, pontuação atual, rodada, etc.
* **`GetGame.cs`**: Responsável por iniciar o jogo, fazendo a requisição à API para obter o UUID da partida, a seed e o vídeo da primeira rodada.
* **`PostAnswer.cs`**: Envia o palpite do jogador (episódio e data) para o backend e recebe o resultado com a pontuação da rodada.
* **`ShowResults.cs` / `ShowPoints.cs`**: Exibem os resultados da rodada e a pontuação final na interface do usuário (UI).
* **`Request.cs`**: Uma classe utilitária que centraliza a lógica para realizar as chamadas `GET` e `POST` para a API.

## 🚀 Como Abrir o Projeto

1.  Certifique-se de ter o **Unity Hub** e a versão **Unity 2022.3.4f1** (ou superior) instalada.
2.  Clone ou baixe este repositório.
3.  No Unity Hub, clique em "Open" -> "Add project from disk" e selecione a pasta raiz `When-CAC-Unity-main`.
4.  Após o projeto carregar, abra a cena principal localizada em `Assets/Scenes/Menu.unity` para iniciar o jogo a partir do menu principal.

**Nota:** Para o jogo funcionar corretamente, o backend da aplicação web precisa estar rodando e acessível, pois este cliente depende de suas rotas de API para buscar os dados do jogo.

## 📂 Estrutura dos Assets

* **/Audio**: Contém os efeitos sonoros do jogo.
* **/Images**: Imagens utilizadas na UI, como logos, ícones e backgrounds.
* **/Prefabs**: Objetos pré-configurados, como elementos de UI (Header, botões, etc.).
* **/Scenes**: Todas as telas do jogo (Menu, Jogo, Resultado, etc.).
* **/Script**: Todo o código-fonte em C# que controla a lógica do jogo.
* **/UI**: Assets de terceiros utilizados para a interface, como o DatePicker e o TableLayout.

## 👥 Autores

* **Júlia D. Craide:** [LinkedIn](https://www.linkedin.com/in/juliadcraide/) | [GitHub](https://github.com/JuDCraide)
* **Leonardo R. Gobatto:** [LinkedIn](https://www.linkedin.com/in/leonardorgobatto/) | [GitHub](https://github.com/lrgobatto)

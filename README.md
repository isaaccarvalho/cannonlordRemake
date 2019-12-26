# Cannon Lord Remake
Remake do Jogo CannonLord para teste BluePixel

## Instalação
Para Executar o Jogo Baixe e Extraia o [arquivo zip](https://github.com/isaaccarvalho/cannonlordRemake/blob/master/Builds/Cannon%20Lord%20Remake.zip) na pasta Builds, e Execute Cannon Lord Remake.exe como administrador. 

## Projeto
Foram utilizados os mesmos assets da versão do teste. O código foi organizado nos seguintes módulos:
* Canhão: métodos para o movimento do canhão, atirar e recarregar (chamados por botão na UI), instanciar uma bala.
* Bala: métodos para o movimento da bala, destruição ao colidir com obstaculo ou inimigo, chama o método de dano do inimigo colidido.
* Inimigo: métodos do movimento, gasto de vida e destruição, chama o método pontuar do game ao ser destruido.
* Game: métodos para instanciar o inimigo, controlar a interação com os botões e UI, iniciar, pausar, reiniciar e sair do game.

Os objetos que são instanciados (obstaculo, bala, inimigo) foram criados prefabs com o código de sua mecânica.

## Pontos adicionais
Foi adicionado a mecânica de recarregar o canhão, e aumentou-se a taxa de tiro para deixar a jogabilidade um pouco mais rápida.
O movimento do canhão foi suavizado nos extremos com a função senoidal. E a velocidade do tiro foi aumentada. Todos esses atributos podem ser alterados no Inspector para alterar a jogabilidade.
Os botões de atirar e recarregar foram colocados próximos ao canhão. 
Foi criado um único botão Play/Pause mais intuitivo e um botão reiniciar, resolvendo também um bug no jogo de exemplo em que instancia várias rochas e não se exclui todas as instancias de inimigos ao clicar em reiniciar.

O projeto foi feito em 20h desde a criação do Projeto no Unity (initial commit). Como os assets foram os mesmos a criação do cenário foi rápida.
posteriormente, o código do canhão levou um tempo médio, o da bala e do inimigo foram rápidos, e o controle da UI foi o mais demorado.

Att, 
Isaac Carvalho

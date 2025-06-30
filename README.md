# DominoLeague


Juego de dominó

## Estructura de proyectos y escenas

```
scenes/
  main/MainScene.gd        # Menú principal y acceso a modos de juego
  game/GameScene.gd        # Lógica de la mesa de dominó
  ui/CreateTablePopup.gd   # Pop‑ups para creación de mesa
  ui/ResultsPopup.gd       # Pop‑ups para resultados de partida
scripts/
  DataManager.gd           # Guardado y carga de datos de jugador
```

### Escena Principal
Contiene el menú principal con acceso a los distintos modos de juego, la tienda y el perfil del jugador.

### Escena de Juego
Incluye la mesa de dominó y la interfaz de usuario necesaria para gestionar las fichas durante la partida.

### Escenas de UI Adicionales
Pop‑ups y pantallas auxiliares como la creación de mesa, selección de modos o resultados finales.

### Gestión de Datos
El script `DataManager.gd` implementa un sistema de guardado y carga para el perfil del jugador y otras configuraciones usando un archivo JSON.
Proyecto basico de un juego de dominó desarrollado en Unity.

## Estructura

- `Assets/Scenes` - Carpeta para las escenas del juego.
- `Assets/Scripts` - Contiene los scripts en C# que definen las principales clases:
  - `GameManager` gestiona el flujo del juego.
  - `DominoTile` representa una ficha.
  - `Player` mantiene la mano de un jugador.
  - `DominoBoard` administra las fichas en la mesa.
  - `Partida` gestiona el estado general de una partida.
  - `Mesa` controla las fichas colocadas en el tablero.
  - `Jugador` almacena la información del jugador (ID, nombre, monedas y rango).
  - `Ficha` es la pieza individual de dominó utilizada en la partida.

Para abrir el proyecto simplemente copie la carpeta en su workspace de Unity y abra la escena principal.


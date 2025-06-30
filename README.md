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

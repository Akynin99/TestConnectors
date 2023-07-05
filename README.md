# TestConnectors

![](https://github.com/Akynin99/TestConnectors/blob/master/Unity_UGGNTNbIcH.gif)

---

### Архитектура:

Класс Main

Класс GameProvider - берет на себя функцию связывания вместе менеджеров и сервисов, а так же инициализирует их
  
Менеджеры:
- PlayerControlManager - отвечает за логику управления 
- SpawnManager - отвечает за спавн объектов Connectable в начале игры
  
Сервисы:
- ConnectableService - отвечает за подсветку шаров и изменения позиций объектов Connectable
- LineService - отвечает за создание линий, передачу линиям позиций и соединение линий с объектами Connectable
- MouseCaster - определяет на что сейчас указывает мышь

Классы представления:
- ClickableView
- ConnectableView
- LineView

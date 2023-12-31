# TestConnectors

Это тестовое задание.

### ТЗ:

В сцене Main реализовать следующий функционал:
- Сгенерировать 10 объектов в случайных позициях на плоскости, ограниченной радиусом, заданным в сцене на объекте Main. Объекты должны быть созданы на основе префаба “Connectable”, который находится в папке Prefabs проекта. Пересечением объектов можно пренебречь.
- Реализовать возможность перетаскивать объекты, зажав на их платформах левую кнопку мыши (пересечением объектов также можно пренебречь)
- Реализовать возможность соединять сферы линиями двумя способами, работающими одновременно. Перемещение объектов не должно разрушать линии между сферами:

Способ 1:
- Пользователь кликает на первую сферу. Она окрашивается в желтый, а все остальные сферы окрашиваются в синий.
- Далее, если пользователь кликает во вторую сферу – сферы меняют цвет на исходный и между ними появляется линия.
- Если же пользователь кликает вне сферы, или еще раз на желтую сферу – все сферы меняют цвет на исходный и линия не создается.

Способ 2.
- Пользователь зажимает левую кнопку мыши на первой сфере. Она окрашивается в желтый, а все остальные сферы - в синий.
- Пользователь тянет линию к другой сфере. В моменты, когда под курсором находится еще одна сфера – она тоже окрашивается в желтый, а когда курсор с нее уходит – красится в синий.
- Если левая кнопка мышки была отпущена на другой сфере – создается линия, соединяющая две сферы, и все сферы меняют цвет на исходный.
- Если левая кнопка мыши была отпущена в момент, когда под курсором не было сферы, то протягиваемая линия исчезает и все сферы меняют цвет на исходный


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

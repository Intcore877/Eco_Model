# Eco_Model
## Задача
Разработать систему, моделирующую поведение хищников :crocodile: и жертв в океане :fish:. Система должна состоять из следующих классов:
Ocean  :ocean:

Состоит из двумерного массива указателей на Cell. Инициализируется размерами, количеством объектов Obstacle, Prey и Predator заполняя соответствующими объектами двумерных массив указателей на Cell. 
Имеет счетчик числа ходов.
Отображает свое содержимое и статистику (номер хода и количество объектов Obstacle, Prey и Predator). Заканчивает работу, когда количество Prey и Predator становится равным 0.

Cell (ячейка) - базовый класс.
Хранит указатель на Ocean, в котором находится, а также координаты своего местоположения в Ocean.

Obstacle (препятствие)
Разновидность Cell. Не может двигаться.

Prey (добыча) :fish:
Разновидность Cell. Может двигаться. 
Перемещается с равной вероятностью на любую свободную ячейку. Может размножаться. 
Размножается, если ее время размножения достигло нуля и она переместилась. Потомство создается в том месте, из которого она переместилась. 
При создании и размножении ее счетчик timeToReproduce устанавливается в диапазоне от MIN_PREY_TIME_TO_REPRODUCE до MAX_PREY_TIME_TO_REPRODUCE случайным образом.

Predator (хищник) :crocodile:
Разновидность Prey. Если видит Prey в пределах своего хода, то ест ее. Не ест других Predator. 
В противном случае ведет себя так же, как и Prey. При создании и размножении ее счетчик timeToReproduce устанавливается в диапазоне от MIN_PREDATOR_TIME_TO_REPRODUCE до MAX_PREDATOR_TIME_TO_REPRODUCE случайным образом.
Ест Prey. Умирает от голода, если его timeToFeed достигло нуля. При создании и после еды устанавливает счетчик timeToFeed в диапазоне от MIN_TIME_TO_FEED до MAX_TIME_TO_FEED случайным образом.

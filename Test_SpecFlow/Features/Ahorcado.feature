Feature: Ahorcado

Scenario: Arriesgar palabra completa correcta
	Given la palabra a adivinar es palabra
	When se arriesga la palabra palabra
	Then el resultado deberia ser True

Scenario: Arriesgar palabra completa incorrecta
	Given la palabra a adivinar es palabra
	When se arriesga la palabra incorrecta
	Then el resultado deberia ser False
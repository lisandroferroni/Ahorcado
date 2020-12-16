Feature: Ahorcado

Scenario: Arriesgar palabra completa incorrecta
	Given Navegue a la url del ahorcado
	And hago click en el boton por palabra
	When se arriesga la palabra incorrecta
	Then el resultado deberia ser Perdiste

Scenario: Arriesgar una letra incorrecta
	Given Navegue a la url del ahorcado
	And hago click en el boton por letra
	When se arriesga la letra x	
	Then los intentos restantes deberian ser 3

Scenario: Arriesgar letras incorrectas hasta perder
	Given Navegue a la url del ahorcado
	And hago click en el boton por letra
	When se arriesga la letra x
	And se arriesga la letra y
	And se arriesga la letra z
	And se arriesga la letra ñ
	Then el resultado deberia ser Perdiste

Scenario: Reiniciar juego luego de perder
	Given Navegue a la url del ahorcado
	And hago click en el boton por palabra
	When se arriesga la palabra incorrecta
	And hago click en el boton reiniciar juego
	Then el resultado no deberia ser Perdiste
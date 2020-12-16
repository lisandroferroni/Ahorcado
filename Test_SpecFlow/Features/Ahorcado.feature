Feature: Ahorcado

#Scenario: Arriesgar palabra completa correcta
#	Given Navegue a la url del ahorcado
#	And la palabra a adivinar es palabra
#	When se arriesga la palabra palabra
#	Then el resultado deberia ser Ganaste

Scenario: Arriesgar palabra completa incorrecta
	Given Navegue a la url del ahorcado
	And hago click en el boton por palabra
	When se arriesga la palabra incorrecta
	Then el resultado deberia ser Perdiste

#Scenario: Arriesgar letra correcta
#	Given la palabra a adivinar es palabra
#	When se arriesga la letra a
#	Then el resultado deberia ser True
#
Scenario: Arriesgar letras incorrectas hasta perder
	Given Navegue a la url del ahorcado
	And hago click en el boton por letra
	When se arriesga la letra x
	And se arriesga la letra y
	And se arriesga la letra z
	And se arriesga la letra ñ
	Then el resultado deberia ser Perdiste

#Scenario: Arriesgar letras correctas hasta ganar
#	Given la palabra a adivinar es casa
#	When se arriesga la letra c
#	And se arriesga la letra a
#	And se arriesga la letra s
#	Then el estado de juego deberia ser Ganaste!
#
#Scenario: Arriesgar letras hasta perder
#	Given la palabra a adivinar es casa
#	When se arriesga la letra x
#	And se arriesga la letra y
#	And se arriesga la letra z
#	And se arriesga la letra p
#	Then el estado de juego deberia ser Perdiste!
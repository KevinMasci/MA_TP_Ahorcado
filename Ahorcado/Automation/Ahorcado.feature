Feature: Ahorcado

@tag1
Scenario: Perder el juego
	Given La palabra secreta es ahorcado
	When Ingreso seis palabras incorrectas diferentes
	Then Deberia decirme que perdi el juego

@tag2
Scenario: Ganar el juego
	Given La palabra secreta es juego
	When Ingreso las letras correctas
	Then Deberia decirme que gane el juego

@tag3
Scenario: Intentar ingresar letra duplicada
	Given La palabra secreta es hola y ya ingrese la h
	When Ingreso la letra h
	Then No deberia restar intentos

@tag4
Scenario: Las letras se ubican en las posiciones correctas
	Given La palabra secreta es metodologia
	When Ingreso la letra o
	Then Deberia ubicarse en las posiciones correctas

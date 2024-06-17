
@tool
extends Node2D

@export var columns: int = 8
@export var rows: int = 8
@export var hSeparation: int = 24
@export var vSeparation: int = 25

@export var scene: PackedScene

#TODO: use a better way to get the sizes
var brickVSize: int = 15
var brickHSize: int = 22


func _ready() -> void:
	var currentX: float = position.x
	var currentY: float = position.y

	for column: int in range(columns):
		for row: int in range(rows):
			var instanceScene = scene.instantiate()
			add_child(instanceScene)
			instanceScene.global_position = Vector2(currentX, currentY)
			currentY += vSeparation + brickVSize
		currentX += hSeparation + brickHSize
		currentY = global_position.y

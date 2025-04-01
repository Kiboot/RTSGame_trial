extends CharacterBody2D

@export var health:int = 100
@export var damage:int = 20
@export var mv_speed = 50.0
@export var attack_range = 20.0
@export var attack_rate: float
var last_attack_time: float
var agent: NavigationAgent2D
var sprite: Sprite2D

var target:CharacterBody2D
@export var is_player: bool

func _ready():
    agent = $NavigationAgent2D
    sprite = $Sprite2D

func _try_attack_target ():
    var cur_time = Time.get_unix_time_from_system()
    if cur_time - last_attack_time > attack_rate:
        target.take_damage(damage)
        last_attack_time = cur_time


func take_damage (damage_to_take):
    health -= damage_to_take

    if health <= 0:
        queue_free()
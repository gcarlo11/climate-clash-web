extends CanvasLayer

# Mendefinisikan data cutscene berdasarkan narasi lengkap
var act_0_scenes = [
	{
		"image": preload("res://Act 0 S1.png"),
		"text": "Tahun 2075. Neo-Archipelago berada di ambang krisis. Layar-layar kota menyiarkan peringatan: tiga bencana besar akan datang banjir, gelombang panas, dan kehancuran iklim. Namun, sudah terlambat untuk menghindar."
	},
	{
		"image": preload("res://Act 0 S2.png"),
		"text": "Air laut naik tanpa ampun, menelan jalanan dan bangunan. Infrastruktur runtuh, dan kota mulai tenggelam. Bencana pertama telah dimulai."
	},
	{
		"image": preload("res://Act 0 S3.png"),
		"text": "Di tengah kehancuran, satu harapan tersisa. Kamu adalah Climate Guardian terakhir, penjaga keseimbangan lingkungan. Dengan pengetahuan dan kebijakan, kamu bersumpah menyelamatkan kota ini."
	}
]

var current_scene_index = 0

@onready var texture_rect = $TextureRect
@onready var label = $Panel/Label
@onready var anim_player = $AnimationPlayer

func _ready():
	display_first_scene()

func _input(event):
	if event.is_action_pressed("ui_accept") or (event is InputEventMouseButton and event.pressed):
		next_scene()

func display_first_scene():
	var data = act_0_scenes[current_scene_index]
	texture_rect.texture = data["image"]
	
	# PENGATURAN PAKSA VISUAL
	label.text = data["text"]
	label.visible_ratio = 1.0          # Memastikan teks tidak tersembunyi (efek typewriter)
	label.modulate = Color(1,1,1,1)     # Memastikan teks warna putih pekat
	label.show()                        # Memastikan node tidak 'hidden'
	
	$Panel.show()                       # Memastikan Panel muncul
	$Panel.modulate = Color(1,1,1,1)
	
	anim_player.play("fade_in")
	
func display_scene():
	var data = act_0_scenes[current_scene_index]
	
	# Memastikan nama animasi sesuai dengan yang kamu buat (Fade_out atau fade_out)
	if anim_player.has_animation("Fade_out"):
		anim_player.play("Fade_out")
	else:
		anim_player.play("fade_out")
		
	await anim_player.animation_finished
	
	texture_rect.texture = data["image"]
	label.text = data["text"]
	
	anim_player.play("fade_in")

func next_scene():
	if current_scene_index < act_0_scenes.size() - 1:
		current_scene_index += 1
		display_scene()
	else:
		finish_cutscene()

func finish_cutscene():
	print("Act 0 Selesai. Masuk ke Gameplay.")
	# get_tree().change_scene_to_file("res://BattleScene.tscn")

extends Node

var save_path := "user://player_data.json"

func save_player_data(data: Dictionary) -> void:
    var file := File.new()
    if file.open(save_path, File.WRITE) == OK:
        file.store_string(to_json(data))
        file.close()

func load_player_data() -> Dictionary:
    var file := File.new()
    if file.file_exists(save_path) and file.open(save_path, File.READ) == OK:
        var data := parse_json(file.get_as_text())
        file.close()
        return data
    return {}

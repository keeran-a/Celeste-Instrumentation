from CelestePythonInterface import SocketInterface, SessionParameters, SocketServer
import keyboard

def get_inputs(input):
    key_presses = [
        keyboard.is_pressed("d"), # right
        keyboard.is_pressed("a"), # left
        keyboard.is_pressed("w"), # up
        keyboard.is_pressed("s"), # down
        keyboard.is_pressed("space"), # jump
        keyboard.is_pressed("x"), # dash
        keyboard.is_pressed("z") # climb
    ]
    return [int(x) for x in key_presses]

session_params = SessionParameters()
session_params.Level = "1"
session_params.AreaKey = 1
session_params.AreaMode = 0
session_params.TimeoutSeconds = 60
session_params.EndOnLevelExit = "false"

socket_server = SocketServer()
client_socket, addr = socket_server.await_connection()

while True:
    interface = SocketInterface(client_socket, get_inputs, session_params)
    interface.run()
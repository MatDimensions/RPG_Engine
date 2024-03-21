using SFML.Window;
using System.Runtime.CompilerServices;

namespace Engine
{
	public static class InputUtility
	{
		public enum InputKeys : int
		{
			/// <summary>The left mouse button</summary>
			MouseLeft = -2,
			/// <summary>The right mouse button</summary>
			MouseRight = -3,
			/// <summary>The middle (wheel) mouse button</summary>
			MouseMiddle = -4,
			/// <summary>The first extra mouse button</summary>
			XButton1 = -5,
			/// <summary>The second extra mouse button</summary>
			XButton2 = -6,
			/// <summary>Keep last -- the total number of mouse buttons</summary>
			ButtonCount = -7,

			/// <summary>Unhandled key</summary>
			Unknown = -1,
			/// <summary>The A key</summary>
			A = 0,
			/// <summary>The B key</summary>
			B,
			/// <summary>The C key</summary>
			C,
			/// <summary>The D key</summary>
			D,
			/// <summary>The E key</summary>
			E,
			/// <summary>The F key</summary>
			F,
			/// <summary>The G key</summary>
			G,
			/// <summary>The H key</summary>
			H,
			/// <summary>The I key</summary>
			I,
			/// <summary>The J key</summary>
			J,
			/// <summary>The K key</summary>
			K,
			/// <summary>The L key</summary>
			L,
			/// <summary>The M key</summary>
			M,
			/// <summary>The N key</summary>
			N,
			/// <summary>The O key</summary>
			O,
			/// <summary>The P key</summary>
			P,
			/// <summary>The Q key</summary>
			Q,
			/// <summary>The R key</summary>
			R,
			/// <summary>The S key</summary>
			S,
			/// <summary>The T key</summary>
			T,
			/// <summary>The U key</summary>
			U,
			/// <summary>The V key</summary>
			V,
			/// <summary>The W key</summary>
			W,
			/// <summary>The X key</summary>
			X,
			/// <summary>The Y key</summary>
			Y,
			/// <summary>The Z key</summary>
			Z,
			/// <summary>The 0 key</summary>
			Num0,
			/// <summary>The 1 key</summary>
			Num1,
			/// <summary>The 2 key</summary>
			Num2,
			/// <summary>The 3 key</summary>
			Num3,
			/// <summary>The 4 key</summary>
			Num4,
			/// <summary>The 5 key</summary>
			Num5,
			/// <summary>The 6 key</summary>
			Num6,
			/// <summary>The 7 key</summary>
			Num7,
			/// <summary>The 8 key</summary>
			Num8,
			/// <summary>The 9 key</summary>
			Num9,
			/// <summary>The Escape key</summary>
			Escape,
			/// <summary>The left Control key</summary>
			LControl,
			/// <summary>The left Shift key</summary>
			LShift,
			/// <summary>The left Alt key</summary>
			LAlt,
			/// <summary>The left OS specific key: window (Windows and Linux), apple (MacOS X), ...</summary>
			LSystem,
			/// <summary>The right Control key</summary>
			RControl,
			/// <summary>The right Shift key</summary>
			RShift,
			/// <summary>The right Alt key</summary>
			RAlt,
			/// <summary>The right OS specific key: window (Windows and Linux), apple (MacOS X), ...</summary>
			RSystem,
			/// <summary>The Menu key</summary>
			Menu,
			/// <summary>The [ key</summary>
			LBracket,
			/// <summary>The ] key</summary>
			RBracket,
			/// <summary>The ; key</summary>
			Semicolon,
			/// <summary>The , key</summary>
			Comma,
			/// <summary>The . key</summary>
			Period,
			/// <summary>The ' key</summary>
			Quote,
			/// <summary>The / key</summary>
			Slash,
			/// <summary>The \ key</summary>
			Backslash,
			/// <summary>The ~ key</summary>
			Tilde,
			/// <summary>The = key</summary>
			Equal,
			/// <summary>The - key</summary>
			Hyphen,
			/// <summary>The Space key</summary>
			Space,
			/// <summary>The Return key</summary>
			Enter,
			/// <summary>The Backspace key</summary>
			Backspace,
			/// <summary>The Tabulation key</summary>
			Tab,
			/// <summary>The Page up key</summary>
			PageUp,
			/// <summary>The Page down key</summary>
			PageDown,
			/// <summary>The End key</summary>
			End,
			/// <summary>The Home key</summary>
			Home,
			/// <summary>The Insert key</summary>
			Insert,
			/// <summary>The Delete key</summary>
			Delete,
			/// <summary>The + key</summary>
			Add,
			/// <summary>The - key</summary>
			Subtract,
			/// <summary>The * key</summary>
			Multiply,
			/// <summary>The / key</summary>
			Divide,
			/// <summary>Left arrow</summary>
			Left,
			/// <summary>Right arrow</summary>
			Right,
			/// <summary>Up arrow</summary>
			Up,
			/// <summary>Down arrow</summary>
			Down,
			/// <summary>The numpad 0 key</summary>
			Numpad0,
			/// <summary>The numpad 1 key</summary>
			Numpad1,
			/// <summary>The numpad 2 key</summary>
			Numpad2,
			/// <summary>The numpad 3 key</summary>
			Numpad3,
			/// <summary>The numpad 4 key</summary>
			Numpad4,
			/// <summary>The numpad 5 key</summary>
			Numpad5,
			/// <summary>The numpad 6 key</summary>
			Numpad6,
			/// <summary>The numpad 7 key</summary>
			Numpad7,
			/// <summary>The numpad 8 key</summary>
			Numpad8,
			/// <summary>The numpad 9 key</summary>
			Numpad9,
			/// <summary>The F1 key</summary>
			F1,
			/// <summary>The F2 key</summary>
			F2,
			/// <summary>The F3 key</summary>
			F3,
			/// <summary>The F4 key</summary>
			F4,
			/// <summary>The F5 key</summary>
			F5,
			/// <summary>The F6 key</summary>
			F6,
			/// <summary>The F7 key</summary>
			F7,
			/// <summary>The F8 key</summary>
			F8,
			/// <summary>The F9 key</summary>
			F9,
			/// <summary>The F10 key</summary>
			F10,
			/// <summary>The F11 key</summary>
			F11,
			/// <summary>The F12 key</summary>
			F12,
			/// <summary>The F13 key</summary>
			F13,
			/// <summary>The F14 key</summary>
			F14,
			/// <summary>The F15 key</summary>
			F15,
			/// <summary>The Pause key</summary>
			Pause,

			/// <summary>The total number of keyboard keys</summary>
			KeyCount,
		}

		public class Input
		{
			public string Name;
			public List<InputKeys> Keys { get; private set; } = new List<InputKeys>();

			public List<System.Action<InputKeys>> PressedActions { get; private set; } = new List<System.Action<InputKeys>>();
			public List<System.Action<InputKeys>> OnPressActions { get; private set; } = new List<System.Action<InputKeys>>();
			public List<System.Action<InputKeys>> OnReleaseActions { get; private set; } = new List<System.Action<InputKeys>>();

			internal bool IsPressed = false;
		}

		public class InputMap
		{
			public List<Input> Inputs = new List<Input>();

			internal InputMap() { }
		}

		#region Accesors
		/// <summary>
		/// set current map name
		/// </summary>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentMapName(string mapName)
		{
			m_currentMap = mapName;
		}

		/// <summary>
		/// return current map name
		/// </summary>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string GetCurrentMapName()
		{
			return m_currentMap;
		}

		/// <summary>
		/// return the input map with name or null if it doesn't exist
		/// </summary>
		/// <param name="mapName">name of the map you want to get</param>
		/// <returns>/!\ Can return null</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static InputMap GetInputMap(string mapName)
		{
			if (m_inputMaps.ContainsKey(mapName))
				return m_inputMaps[mapName];
			else
				return null;
		}

		/// <summary>
		/// return current input map or null if there is nothing
		/// </summary>
		/// <returns>/!\ Can return null</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static InputMap GetCurrentInputmap()
		{
			return GetInputMap(m_currentMap);
		}
		#endregion

		public static void Init()
		{
			m_inputMaps = new Dictionary<string, InputMap>();
			m_currentMap = "";
			m_pressedInputs = new List<string>();
		}

		public static void Run()
		{
			m_pressedInputs.Clear();
			if (m_inputMaps.ContainsKey(m_currentMap))
			{
				InputMap currentMap = m_inputMaps[m_currentMap];
				Mouse.Button? mouseButton = null;
				foreach (var input in currentMap.Inputs)
				{
					foreach (InputKeys key in input.Keys)
					{
						if (TryGetMouseInputFromIntInput((int)key, out mouseButton))
						{
							if (!Mouse.IsButtonPressed((Mouse.Button)mouseButton) && input.IsPressed)
							{
								input.IsPressed = false;
								m_onReleasedInputs.Add(input.Name);
								foreach (Action<InputKeys> action in input.OnReleaseActions)
									action?.Invoke(key);
								break;
							}
							else if (Mouse.IsButtonPressed((Mouse.Button)mouseButton) && !input.IsPressed)
							{
								input.IsPressed = true;
								m_onPressedInputs.Add(input.Name);
								foreach (Action<InputKeys> action in input.OnPressActions)
									action?.Invoke(key);
								break;
							}
							else if (Mouse.IsButtonPressed((Mouse.Button)mouseButton))
							{
								input.IsPressed = true;
								m_pressedInputs.Add(input.Name);
								foreach (Action<InputKeys> action in input.PressedActions)
									action?.Invoke(key);
								break;
							}

						}
						else
						{
							if (!Keyboard.IsKeyPressed((Keyboard.Key)key) && input.IsPressed)
							{
								input.IsPressed = false;
								m_onReleasedInputs.Add(input.Name);
								foreach (Action<InputKeys> action in input.OnReleaseActions)
									action?.Invoke(key);
								break;
							}
							else if (Keyboard.IsKeyPressed((Keyboard.Key)key) && !input.IsPressed)
							{
								input.IsPressed = true;
								m_onPressedInputs.Add(input.Name);
								foreach (Action<InputKeys> action in input.OnPressActions)
									action?.Invoke(key);
								break;
							}
							else if (Keyboard.IsKeyPressed((Keyboard.Key)key))
							{
								input.IsPressed = true;
								m_pressedInputs.Add(input.Name);
								foreach (Action<InputKeys> action in input.PressedActions)
									action?.Invoke(key);
								break;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// create a new map with name
		/// </summary>
		/// <param name="mapName">name of the new input map</param>
		/// <returns>
		/// new map created
		/// /!\ return null if you try to create a map with a name already used
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static InputMap CreateNewMap(string mapName)
		{
			if (!m_inputMaps.ContainsKey(mapName))
			{
				InputMap newMap = new InputMap();
				m_inputMaps.Add(mapName, newMap);
				return newMap;
			}
			else
			{
				Debug.LogError("Try to create an input map with a name : " + mapName + " while another map already have this name");
				return null;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInputPressed(string inputName)
		{
			return m_pressedInputs.Contains(inputName);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInputOnPress(string inputName)
		{
			return m_onPressedInputs.Contains(inputName);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInputOnRelease(string inputName)
		{
			return m_onReleasedInputs.Contains(inputName);
		}

		private static bool TryGetMouseInputFromIntInput(int input, out Mouse.Button? button)
		{
			if (input < -1)
			{
				button = (Mouse.Button)((input + 2) * -1);
				return true;
			}
			button = null;
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int GetInputIntFromMouseInput(Mouse.Button button)
		{
			return ((int)button - 1) * -1;
		}

		private static string m_currentMap;
		private static Dictionary<string, InputMap> m_inputMaps;

		private static List<string> m_pressedInputs;
		private static List<string> m_onReleasedInputs;
		private static List<string> m_onPressedInputs;
	}
}

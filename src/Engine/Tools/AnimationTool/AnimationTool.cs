using Engine;
using SFML.Graphics;
using SFML.System;
using System.Text;

namespace AnimationTool
{
	public partial class AnimationTool : Form
	{
		private class AnimationPart
		{
			public string SpriteName;
			public int SpritePosition;
			public Label SpriteLabel;
			public Button SpriteButton;
		}

		public AnimationTool(Form parent)
		{
			m_parent = parent;

			InitializeComponent();
			panelSprites.AutoScroll = true;
			panelAnim.AutoScroll = true;
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			StopThread();
			m_parent.Show();
		}

		private void AddSprites_Click(object sender, EventArgs e)
		{
			AddSpritesToList();
		}

		private void RemoveDuplicates_Click(object sender, EventArgs e)
		{
			List<string> spritesAlreadySeens = new List<string>();
			for (int i = 0; i < m_animationParts.Count; ++i)
			{
				if (spritesAlreadySeens.Contains(m_animationParts[i].SpriteName))
				{
					RemoveSpriteToAnimation(m_animationParts[i]);
					--i;
				}
				else
					spritesAlreadySeens.Add(m_animationParts[i].SpriteName);
			}
		}

		private void InvertAnimationList_Click(object sender, EventArgs e)
		{
			List<string> newList = new List<string>();
			for (int i = m_animationParts.Count - 1; i >= 0; --i)
			{
				newList.Add(m_animationParts[i].SpriteName);
				RemoveSpriteToAnimation(m_animationParts[i]);
			}
			for (int i = 0; i < newList.Count; ++i)
			{
				AddSpriteToAnimation(newList[i]);
			}
		}

		private void StartAnimation_Click(object sender, EventArgs e)
		{
			StartThread();
		}

		private void StopAnimation_Click(object sender, EventArgs e)
		{
			StopThread();
		}

		private void Save_Click(object sender, EventArgs e)
		{
			saveFileDialog.DefaultExt = ".anim";
			saveFileDialog.Filter = "Animation file (*.anim)|*.anim";
			if (m_animationParts.Count == 0 || saveFileDialog.ShowDialog() != DialogResult.OK)
				return;

			string fileName = saveFileDialog.FileName;
			string directoryName = "";
			{
				string[] substrings = fileName.Split('\\');
				foreach (string substring in substrings)
				{
					if (substring.Contains('.'))
						break;
					else
						directoryName = substring;
				}
			}

			using (Stream fileStream = saveFileDialog.OpenFile())
			{
				using (StreamWriter writer = new StreamWriter(fileStream))
				{
					writer.Write("ANIM " + m_animationParts.Count + " " + AnimationTimeBox.Text);
					foreach (AnimationPart part in m_animationParts)
					{
						string[] substrings = part.SpriteName.Split("/");
						StringBuilder builder = new StringBuilder();
						bool directoryFind = false;
						bool firstAdd = false;
						foreach (string substring in substrings)
						{
							if (directoryFind)
							{
								if (!firstAdd)
								{
									builder.Append(substring);
									firstAdd = true;
								}
								else
									builder.Append("/" + substring);
							}
							if (substring == directoryName)
								directoryFind = true;
						}
						writer.Write("\n" + builder.ToString());
					}
				}
			}
		}

		private void Load_Click(object sender, EventArgs e)
		{
			openFileDialog.Multiselect = false;
			openFileDialog.CheckFileExists = true;
			openFileDialog.DefaultExt = ".anim";
			openFileDialog.Filter = "Animation file (*.anim)|*.anim";
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;

			foreach (AnimationPart part in m_animationParts)
				RemoveSpriteToAnimation(part);

			using (Stream stream = openFileDialog.OpenFile())
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					string firstLine = reader.ReadLine();
					string[] splitLine = firstLine.Split(' ');
					if (!splitLine[0].Contains("ANIM") || splitLine[0].Contains("MULTI") || splitLine.Contains("TIMED"))
					{
						MessageBox.Show("Can't read this file as an Animation definition File");
						return;
					}

					AnimationTimeBox.Text = splitLine[2];

					string[] filePath = openFileDialog.FileName.Split('\\');
					StringBuilder directoryPathBuilder = new();
					StringBuilder directoryEnginePathBuilder = new();
					bool datasFind = false;

					for (int i = 0; !filePath[i].Contains("."); ++i)
					{
						directoryPathBuilder.Append(filePath[i] + '/');

						if (datasFind)
							directoryEnginePathBuilder.Append(filePath[i] + '/');
						if (filePath[i].Contains("Datas"))
						{
							directoryEnginePathBuilder.Append("../");
							datasFind = true;
						}
					}

					string directoryPath = directoryPathBuilder.ToString();
					string directoryEnginePath = directoryEnginePathBuilder.ToString();
					List<string> spritesNames = new List<string>();

					for (int i = 0; i < int.Parse(splitLine[1]); ++i)
					{
						spritesNames.Add(reader.ReadLine());
					}

					string[] texturesPaths = new string[spritesNames.Count];
					for (int i = 0; i < spritesNames.Count; ++i)
						texturesPaths[i] = directoryPath + spritesNames[i];

					AddSpriteToList(texturesPaths, '/');
					foreach (string spriteName in spritesNames)
						AddSpriteToAnimation(directoryEnginePath + spriteName);
				}
			}
		}

		private void AddSpritesToList()
		{
			openFileDialog.DefaultExt = ".png";
			openFileDialog.Multiselect = true;
			openFileDialog.InitialDirectory = "../../x64/Datas/";
			openFileDialog.RestoreDirectory = false;
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = "PNG file (*.png)|*.png";

			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;

			AddSpriteToList(openFileDialog.FileNames, '\\');
		}

		private void AddSpriteToList(string[] files, char splitSymbol)
		{
			foreach (var file in files)
			{
				string[] substrings = file.Split(splitSymbol);

				bool textureFind = false;
				int datasFindIn = -1;
				StringBuilder fileName = new();

				for (int i = 0; i < substrings.Length; i++)
				{
					string substring = substrings[i];
					if (textureFind)
						fileName.Append("/" + substring);
					else if (substring == "Datas")
						datasFindIn = i;
					else if (datasFindIn != -1 && i == datasFindIn + 1 && substring != "Textures")
					{
						textureFind = true;
						fileName.Append("../" + substring);
					}
					else if (substring == "Textures")
						textureFind = true;
				}

				string name = fileName.ToString();

				if (m_imagesDictionary.ContainsKey(name))
					continue;

				Sprite currentSprite = SpriteUtility.GetSprite(fileName.ToString());
				int imageSize = (int)currentSprite.Texture.Size.Y;
				imageSize = imageSize >= 20 ? imageSize : 20;
				int YPosition = m_spriteNumber * (imageSize + 10) + 10 + panelSprites.AutoScrollPosition.Y;

				PictureBox picBox = new PictureBox();
				picBox.Image = System.Drawing.Image.FromFile(file);
				picBox.Location = new Point(10, YPosition);
				picBox.Size = picBox.Image.Size;
				picBox.BorderStyle = BorderStyle.FixedSingle;

				m_imagesDictionary.Add(name, picBox.Image);

				panelSprites.Controls.Add(picBox);

				Label label = new Label();
				label.Text = name;
				label.Location = new Point(20 + picBox.Width, YPosition);
				label.Size = new Size(250, 30);

				panelSprites.Controls.Add(label);

				Button btn = new Button();
				btn.Text = "Add";
				btn.Location = new Point(300, YPosition);
				btn.TabIndex = 0;
				btn.Click += (object? sender, EventArgs e) => AddSpriteToAnimation(name);

				panelSprites.Controls.Add(btn);

				++m_spriteNumber;
			}
		}

		private void AddSpriteToAnimation(string name)
		{
			if (!m_imagesDictionary.ContainsKey(name))
			{
				MessageBox.Show("Can't add this Sprite " + name + " to the animation, it isn't registered");
				return;
			}
			AnimationPart part = new AnimationPart();
			part.SpriteName = name;
			part.SpritePosition = m_animationParts.Count;

			int YPosition = part.SpritePosition * 30 + panelAnim.AutoScrollPosition.Y;

			Label label = new Label();
			label.Text = name;
			label.Location = new Point(0, YPosition);
			label.Size = new Size(250, 30);

			panelAnim.Controls.Add(label);

			Button button = new Button();
			button.Text = "Remove";
			button.Location = new Point(280, YPosition);
			button.Click += (object? sender, EventArgs e) => RemoveSpriteToAnimation(part);

			panelAnim.Controls.Add(button);

			part.SpriteLabel = label;
			part.SpriteButton = button;

			m_animationParts.Add(part);
		}

		void RemoveSpriteToAnimation(AnimationPart part)
		{
			panelAnim.Controls.Remove(part.SpriteLabel);
			part.SpriteLabel.Dispose();
			panelAnim.Controls.Remove(part.SpriteButton);
			part.SpriteButton.Dispose();
			m_animationParts.RemoveAt(part.SpritePosition);
			for (int pos = 0; pos < m_animationParts.Count; ++pos)
			{
				m_animationParts[pos].SpritePosition = pos;
				m_animationParts[pos].SpriteLabel.Location = new Point(m_animationParts[pos].SpriteLabel.Location.X, pos * 30 + panelAnim.AutoScrollPosition.Y);
				m_animationParts[pos].SpriteButton.Location = new Point(m_animationParts[pos].SpriteButton.Location.X, pos * 30 + panelAnim.AutoScrollPosition.Y);
			}
			if (m_animationParts.Count == 0)
				m_threadRunning = false;
		}

		void StartThread()
		{
			if (m_animationParts.Count == 0)
				return;
			StopThread();
			m_threadRunning = true;
			m_thread = new Thread(AnimationThreadFunction);
			m_thread.Start();
		}

		void StopThread()
		{
			if (m_thread != null)
			{
				m_threadRunning = false;
				m_thread.Join();
			}
		}

		void AnimationThreadFunction()
		{
			Clock clock = new();
			float timer = 0f;
			int currentSprite = 0;
			while (m_threadRunning)
			{
				try
				{
					timer += clock.Restart().AsSeconds();
					if (timer > float.Parse(AnimationTimeBox.Text) / m_animationParts.Count)
					{
						timer = 0f;
						currentSprite = currentSprite + 1 >= m_animationParts.Count ? 0 : currentSprite + 1;
					}
					pictureBox.Image = m_imagesDictionary[m_animationParts[currentSprite].SpriteName];
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}

		private Form m_parent;
		private int m_spriteNumber;

		private List<AnimationPart> m_animationParts = new List<AnimationPart>();

		#region ThreadGestion
		private Thread m_thread;
		private bool m_threadRunning;
		private Dictionary<string, System.Drawing.Image> m_imagesDictionary = new Dictionary<string, System.Drawing.Image>();
		#endregion
	}
}

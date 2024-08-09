using Engine;
using SFML.Graphics;
using SFML.System;
using System.Text;

namespace AnimationTool
{
	public partial class MultiAnimationTool : Form
	{
		private class AnimationPart
		{
			public string SpriteName;
			public int SpritePosition;
			public Label SpriteLabel;
			public Button SpriteButton;
		}

		private class Animation
		{
			public List<AnimationPart> parts = new();
			public string AnimationName;
			public float AnimationTime;
			public int Index;
			public Button AnimButton;
			public Button RemoveAnimButton;
		}

		public MultiAnimationTool(Form parent)
		{
			m_parent = parent;

			InitializeComponent();
			panelSprites.AutoScroll = true;
			panelAnim.AutoScroll = true;
			panelAnimsNames.AutoScroll = true;
			AnimationNameBox.TextChanged += OnAnimationNameChanged;
			AnimationTimeBox.TextChanged += OnAnimationTimeChanged;
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

		private void AddAnimation_Click(object sender, EventArgs e)
		{
			AddAnimation("Anim" + m_animations.Count, 1f);
		}

		private void RemoveDuplicates_Click(object sender, EventArgs e)
		{
			if (m_currentAnimation > m_animations.Count)
				return;

			List<string> spritesAlreadySeens = new List<string>();
			for (int i = 0; i < m_animations[m_currentAnimation].parts.Count; ++i)
			{
				if (spritesAlreadySeens.Contains(m_animations[m_currentAnimation].parts[i].SpriteName))
				{
					RemoveSpriteToAnimation(m_animations[m_currentAnimation].parts[i]);
					--i;
				}
				else
					spritesAlreadySeens.Add(m_animations[m_currentAnimation].parts[i].SpriteName);
			}
		}

		private void InvertAnimationList_Click(object sender, EventArgs e)
		{
			List<string> newList = new List<string>();
			for (int i = m_animations[m_currentAnimation].parts.Count - 1; i >= 0; --i)
			{
				newList.Add(m_animations[m_currentAnimation].parts[i].SpriteName);
				RemoveSpriteToAnimation(m_animations[m_currentAnimation].parts[i]);
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
			List<string> animsNames = new();
			foreach (Animation animation in m_animations)
			{
				foreach (string name in animsNames)
				{
					if (name == animation.AnimationName)
					{
						MessageBox.Show("Can't save, multiple animations have the same name : " + name);
						return;
					}
				}
				animsNames.Add(animation.AnimationName);
			}

			saveFileDialog.DefaultExt = ".anim";
			saveFileDialog.Filter = "Animation file (*.anim)|*.anim";
			if (m_animations.Count == 0 || saveFileDialog.ShowDialog() != DialogResult.OK)
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
					int texturesCount = 0;
					foreach (Animation animation in m_animations)
						texturesCount += animation.parts.Count;

					writer.Write("MULTI_ANIM " + m_animations.Count + " " + texturesCount);

					int startIndex = 0;
					foreach (Animation animation in m_animations)
					{
						writer.Write("\n" + animation.AnimationName + " " + animation.AnimationTime.ToString() + " " + startIndex + " " + animation.parts.Count);
						startIndex += animation.parts.Count;
					}

					foreach (Animation animation in m_animations)
					{
						foreach (AnimationPart part in animation.parts)
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
		}

		//TODO
		private void Load_Click(object sender, EventArgs e)
		{
			openFileDialog.Multiselect = false;
			openFileDialog.CheckFileExists = true;
			openFileDialog.DefaultExt = ".anim";
			openFileDialog.Filter = "Animation file (*.anim)|*.anim";
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;

			foreach (Animation animation in m_animations)
				RemoveAnimation(animation);

			using (Stream stream = openFileDialog.OpenFile())
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					string firstLine = reader.ReadLine();
					string[] splitLine = firstLine.Split(' ');
					if (!splitLine[0].Contains("MULTI_ANIM") || splitLine.Contains("TIMED"))
					{
						MessageBox.Show("Can't read this file as a MultiAnimation definition File");
						return;
					}

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

					int animationsNumber = int.Parse(splitLine[1]);
					int spritesNumber = int.Parse(splitLine[2]);
					List<int> animationsStartIndex = new List<int>();
					List<int> animationsSpriteNumber = new List<int>();

					for (int i = 0; i < animationsNumber; ++i)
					{
						string animationLine = reader.ReadLine();
						string[] animationLineSplit = animationLine.Split(' ');

						AddAnimation(animationLineSplit[0], float.Parse(animationLineSplit[1]));
						animationsStartIndex.Add(int.Parse(animationLineSplit[2]));
						animationsSpriteNumber.Add(int.Parse(animationLineSplit[3]));
					}

					List<string> spritesNames = new List<string>();

					for (int i = 0; i < spritesNumber; ++i)
					{
						spritesNames.Add(reader.ReadLine());
					}

					string[] texturesPaths = new string[spritesNames.Count];
					for (int i = 0; i < spritesNames.Count; ++i)
						texturesPaths[i] = directoryPath + spritesNames[i];

					AddSpriteToList(texturesPaths, '/');
					for (int i = 0; i < m_animations.Count; ++i)
					{
						SelectAnimation(m_animations[i]);
						for (int j = animationsStartIndex[i]; j < animationsStartIndex[i] + animationsSpriteNumber[i]; ++j)
							AddSpriteToAnimation(directoryEnginePath + spritesNames[j]);
					}
				}
			}
		}

		private void OnAnimationNameChanged(object? sender, EventArgs e)
		{
			if (m_currentAnimation < m_animations.Count)
			{
				m_animations[m_currentAnimation].AnimationName = AnimationNameBox.Text;
				m_animations[m_currentAnimation].AnimButton.Text = AnimationNameBox.Text;
			}
		}

		private void OnAnimationTimeChanged(object? sender, EventArgs e)
		{
			if (m_currentAnimation < m_animations.Count)
			{
				try
				{
					m_animations[m_currentAnimation].AnimationTime = float.Parse(AnimationTimeBox.Text);
				}
				catch (Exception ex) { }
			}
		}

		private void AddAnimation(string animationName, float animationTime)
		{
			Animation animation = new Animation();

			int YPosition = m_animations.Count * 30 + panelAnim.AutoScrollPosition.Y;

			Button animButton = new Button();
			animButton.Size = new Size(150, 25);
			animButton.Location = new Point(0, YPosition);
			animButton.Click += (object? sender, EventArgs e) => SelectAnimation(animation);
			animButton.Parent = panelAnimsNames;

			animation.AnimButton = animButton;

			Button removeButton = new();
			removeButton.Size = new Size(25, 25);
			removeButton.Location = new Point(150, YPosition);
			removeButton.Text = "X";
			removeButton.Click += (object? sender, EventArgs e) => RemoveAnimation(animation);
			removeButton.Parent = panelAnimsNames;

			animation.RemoveAnimButton = removeButton;

			animation.Index = m_animations.Count;
			m_animations.Add(animation);
			animation.AnimationName = animationName;
			animButton.Name = animation.AnimationName;
			animation.AnimationTime = animationTime;

			SelectAnimation(animation);
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
			if (m_currentAnimation > m_animations.Count)
				return;

			AnimationPart part = new AnimationPart();
			part.SpriteName = name;
			part.SpritePosition = m_animations[m_currentAnimation].parts.Count;

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

			m_animations[m_currentAnimation].parts.Add(part);
		}

		void RemoveSpriteToAnimation(AnimationPart part)
		{
			panelAnim.Controls.Remove(part.SpriteLabel);
			part.SpriteLabel.Dispose();
			panelAnim.Controls.Remove(part.SpriteButton);
			part.SpriteButton.Dispose();
			m_animations[m_currentAnimation].parts.RemoveAt(part.SpritePosition);
			for (int pos = 0; pos < m_animations[m_currentAnimation].parts.Count; ++pos)
			{
				m_animations[m_currentAnimation].parts[pos].SpritePosition = pos;
				m_animations[m_currentAnimation].parts[pos].SpriteLabel.Location = new Point(m_animations[m_currentAnimation].parts[pos].SpriteLabel.Location.X, pos * 30 + panelAnim.AutoScrollPosition.Y);
				m_animations[m_currentAnimation].parts[pos].SpriteButton.Location = new Point(m_animations[m_currentAnimation].parts[pos].SpriteButton.Location.X, pos * 30 + panelAnim.AutoScrollPosition.Y);
			}
			if (m_animations[m_currentAnimation].parts.Count == 0)
				m_threadRunning = false;
		}

		void SelectAnimation(Animation anim)
		{
			panelAnim.Controls.Clear();

			if (anim == null)
				return;

			m_currentAnimation = anim.Index;
			AnimationNameBox.Text = anim.AnimationName;
			AnimationTimeBox.Text = anim.AnimationTime.ToString();

			foreach (AnimationPart part in m_animations[m_currentAnimation].parts)
			{
				panelAnim.Controls.Add(part.SpriteButton);
				panelAnim.Controls.Add(part.SpriteLabel);
			}
		}

		void RemoveAnimation(Animation anim)
		{
			if (m_animations.Count == 0) return;

			if (m_currentAnimation == anim.Index)
				m_currentAnimation = 0;
			else if (m_currentAnimation > anim.Index)
				--m_currentAnimation;

			panelAnimsNames.Controls.Remove(anim.AnimButton);
			anim.AnimButton.Dispose();
			panelAnimsNames.Controls.Remove(anim.RemoveAnimButton);
			anim.RemoveAnimButton.Dispose();

			foreach (AnimationPart part in anim.parts)
			{
				part.SpriteLabel.Dispose();
				part.SpriteLabel.Dispose();
			}

			m_animations.RemoveAt(anim.Index);

			for (int i = 0; i < m_animations.Count; ++i)
			{
				m_animations[i].Index = i;
				m_animations[i].AnimButton.Location = new Point(m_animations[i].AnimButton.Location.X, i * 30 + panelAnim.AutoScrollPosition.Y);
				m_animations[i].RemoveAnimButton.Location = new Point(m_animations[i].RemoveAnimButton.Location.X, i * 30 + panelAnim.AutoScrollPosition.Y);
			}

			if (m_currentAnimation < m_animations.Count)
				SelectAnimation(m_animations[m_currentAnimation]);
			else
				SelectAnimation(null);
		}

		void StartThread()
		{
			if (m_animations[m_currentAnimation].parts.Count == 0)
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
					if (timer > float.Parse(AnimationTimeBox.Text) / m_animations[m_currentAnimation].parts.Count)
					{
						timer = 0f;
						currentSprite = currentSprite + 1 >= m_animations[m_currentAnimation].parts.Count ? 0 : currentSprite + 1;
					}
					pictureBox.Image = m_imagesDictionary[m_animations[m_currentAnimation].parts[currentSprite].SpriteName];
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
		private List<Animation> m_animations = new();
		private int m_currentAnimation = 0;

		#region ThreadGestion
		private Thread m_thread;
		private bool m_threadRunning;
		private Dictionary<string, System.Drawing.Image> m_imagesDictionary = new Dictionary<string, System.Drawing.Image>();
		#endregion
	}
}

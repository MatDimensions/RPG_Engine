namespace AnimationTool
{
	public partial class AnimationConverter : Form
	{
		private enum AnimationType
		{
			None,
			Animation,
			TimedAnimation,
			MultiAnimation,
			MultiTimedAnimation,
		}

		public AnimationConverter(Form parent)
		{
			m_parent = parent;

			InitializeComponent();
			openFileDialog.Multiselect = false;
			openFileDialog.CheckFileExists = true;
			openFileDialog.DefaultExt = ".anim";
			openFileDialog.Filter = "Animation file (*.anim)|*.anim";
			saveFileDialog.DefaultExt = ".anim";
			saveFileDialog.Filter = "Animation file (*.anim)|*.anim";
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			m_parent.Show();
		}

		private void SelectFile_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;

			using (Stream stream = openFileDialog.OpenFile())
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					string firstLine = reader.ReadLine();
					string[] splitLine = firstLine.Split(' ');
					if (!splitLine[0].Contains("ANIM"))
					{
						MessageBox.Show("Can't read this file as an Animation definition File");
						return;
					}

					FileName.Text = openFileDialog.FileName;

					switch (splitLine[0])
					{
						case string animName when animName.Contains("MULTI_TIMED_ANIM"):
							animationType.Text = "Multi Timed Animation";
							m_animationType = AnimationType.MultiTimedAnimation;
							break;
						case string animName when animName.Contains("MULTI_ANIM"):
							animationType.Text = "Multi Animation";
							m_animationType = AnimationType.MultiAnimation;
							break;
						case string animName when animName.Contains("TIMED_ANIM"):
							animationType.Text = "Timed Animation";
							m_animationType = AnimationType.TimedAnimation;
							break;
						case string animName when animName.Contains("ANIM"):
							animationType.Text = "Animation";
							m_animationType = AnimationType.Animation;
							break;
					}
					m_fileSelected = true;
				}
			}
		}

		private void Convert_Click(object sender, EventArgs e)
		{
			if (!m_fileSelected)
			{
				MessageBox.Show("You have to select a file before");
				return;
			}

			if (comboBox.SelectedIndex == -1)
			{
				MessageBox.Show("You have to select an Animation type to convert into");
				return;
			}

			if (saveFileDialog.ShowDialog() != DialogResult.OK)
				return;

			using (Stream fileStream = saveFileDialog.OpenFile())
			{
				using (StreamWriter writer = new StreamWriter(fileStream))
				{
					using (StreamReader reader = new StreamReader(FileName.Text))
					{
						string[] firstLine = new string[0];
						switch (m_animationType)
						{
							case AnimationType.Animation:
								firstLine = reader.ReadLine().Split(" ");
								switch (comboBox.SelectedIndex)
								{
									case 0: //Animation
										writer.Write(reader.ReadToEnd());
										break;
									case 1: //TimedAnimation
										float spriteTime = float.Parse(firstLine[2]) / float.Parse(firstLine[1]);
										writer.Write("TIMED_ANIM " + firstLine[1]);
										while (!reader.EndOfStream)
											writer.Write("\n" + reader.ReadLine() + " " + spriteTime.ToString());
										break;
									case 2: //MultiAnimation
										string[] splitName = FileName.Text.Split("\\");
										string[] splitAnimName = splitName[splitName.Length - 1].Split(".");
										string animName = splitAnimName[0];
										string spritesNames = "";
										int spritesNumber = 0;
										while (!reader.EndOfStream)
										{
											spritesNames += "\n" + reader.ReadLine();
											++spritesNumber;
										}
										writer.WriteLine("MULTI_ANIM 1 " + spritesNumber);
										writer.Write(animName + " " + firstLine[2] + " 0 " + spritesNumber);
										writer.Write(spritesNames);
										break;
									case 3: //MultiTimedAnimation
										spriteTime = float.Parse(firstLine[2]) / float.Parse(firstLine[1]);
										splitName = FileName.Text.Split("\\");
										splitAnimName = splitName[splitName.Length - 1].Split(".");
										animName = splitAnimName[0];
										spritesNames = "";
										spritesNumber = 0;
										while (!reader.EndOfStream)
										{
											spritesNames += "\n" + reader.ReadLine() + " " + spriteTime.ToString();
											++spritesNumber;
										}
										writer.WriteLine("MULTI_TIMED_ANIM 1 " + spritesNumber);
										writer.Write(animName + " 0 " + spritesNumber);
										writer.Write(spritesNames);
										break;
									default:
										break;
								}
								break;
							case AnimationType.TimedAnimation:
								firstLine = reader.ReadLine().Split(" ");
								switch (comboBox.SelectedIndex)
								{
									case 0: //Animation
										string[] framesNames = new string[int.Parse(firstLine[1])];
										float animationTime = 0f;
										for (int i = 0; i < framesNames.Length; ++i)
										{
											string[] line = reader.ReadLine().Split(" ");
											framesNames[i] = line[0];
											animationTime += float.Parse(line[1]);
										}
										writer.Write("ANIM " + firstLine[1] + " " + animationTime.ToString());
										foreach (string frameName in framesNames)
											writer.Write("\n" + frameName);
										break;
									case 1: //TimedAnimation
										writer.Write(reader.ReadToEnd());
										break;
									case 2: //MultiAnimation
										string[] splitName = FileName.Text.Split("\\");
										string[] splitAnimName = splitName[splitName.Length - 1].Split(".");
										string animName = splitAnimName[0];

										framesNames = new string[int.Parse(firstLine[1])];
										animationTime = 0f;
										for (int i = 0; i < framesNames.Length; ++i)
										{
											string[] line = reader.ReadLine().Split(" ");
											framesNames[i] = line[0];
											animationTime += float.Parse(line[1]);
										}

										writer.WriteLine("MULTI_ANIM 1 " + firstLine[1]);
										writer.Write(animName + " " + animationTime.ToString() + " 0 " + framesNames.Length);
										foreach (string frameName in framesNames)
											writer.Write("\n" + frameName);
										break;
									case 3: //MultiTimedAnimation
										splitName = FileName.Text.Split("\\");
										splitAnimName = splitName[splitName.Length - 1].Split(".");
										animName = splitAnimName[0];

										writer.WriteLine("MULTI_TIMED_ANIM 1 " + firstLine[1]);
										writer.Write(animName + " 0 " + firstLine[1]);
										for (int i = 0; i < int.Parse(firstLine[1]); ++i)
											writer.Write("\n" + reader.ReadLine());
										break;
									default:
										break;
								}
								break;
							case AnimationType.MultiAnimation:
								firstLine = reader.ReadLine().Split(" ");
								int animationNumber = int.Parse(firstLine[1]);
								int spriteNumber = int.Parse(firstLine[2]);
								switch (comboBox.SelectedIndex)
								{
									case 0: //Animation
										float animationTime = 0f;
										for (int i = 0; i < animationNumber; ++i)
										{
											string[] animationLine = reader.ReadLine().Split(" ");
											animationTime += float.Parse(animationLine[1]);
										}
										writer.Write("ANIM " + spriteNumber + " " + animationTime.ToString());
										for (int i = 0; i < spriteNumber; ++i)
											writer.Write("\n" + reader.ReadLine());
										break;
									case 1: //TimedAnimation
										animationTime = 0f;
										for (int i = 0; i < animationNumber; ++i)
										{
											string[] animationLine = reader.ReadLine().Split(" ");
											animationTime += float.Parse(animationLine[1]);
										}
										writer.Write("TIMED_ANIM " + spriteNumber);
										for (int i = 0; i < spriteNumber; ++i)
											writer.Write("\n" + reader.ReadLine() + " " + animationTime / spriteNumber);
										break;
									case 2: //MultiAnimation
										writer.Write(reader.ReadToEnd());
										break;
									case 3: //MultiTimedAnimation
										animationTime = 0f;
										writer.Write("MULTI_TIMED_ANIM " + animationNumber + " " + spriteNumber);
										for (int i = 0; i < animationNumber; ++i)
										{
											string[] animationLine = reader.ReadLine().Split(" ");
											animationTime += float.Parse(animationLine[1]);
											writer.Write("\n" + animationLine[0] + " " + animationLine[2] + " " + animationLine[3]);
										}
										for (int i = 0; i < spriteNumber; ++i)
											writer.Write("\n" + reader.ReadLine() + " " + animationTime / spriteNumber);
										break;
									default:
										break;
								}
								break;
							case AnimationType.MultiTimedAnimation:
								firstLine = reader.ReadLine().Split(" ");
								animationNumber = int.Parse(firstLine[1]);
								spriteNumber = int.Parse(firstLine[2]);
								switch (comboBox.SelectedIndex)
								{
									case 0: //Animation
										for (int i = 0; i < animationNumber; ++i)
											reader.ReadLine();
										float animationTime = 0f;
										string[] spritesNames = new string[spriteNumber];
										for (int i = 0; i < spritesNames.Length; ++i)
										{
											string[] spriteLine = reader.ReadLine().Split(" ");
											spritesNames[i] = spriteLine[0];
											animationTime += float.Parse(spriteLine[1]);
										}
										writer.Write("ANIM " + spriteNumber + " " + animationTime);
										foreach (string spriteName in spritesNames)
											writer.Write("\n" + spriteName);
										break;
									case 1: //TimedAnimation
										for (int i = 0; i < animationNumber; ++i)
											reader.ReadLine();

										writer.Write("TIMED_ANIM " + spriteNumber);
										for (int i = 0; i < spriteNumber; ++i)
											writer.Write("\n" + reader.ReadLine());
										break;
									case 2: //MultiAnimation
										string[] animationsLine = new string[animationNumber];
										spritesNames = new string[spriteNumber];
										animationTime = 0f;
										for (int i = 0; i < animationNumber; ++i)
											animationsLine[i] = reader.ReadLine();

										for (int i = 0; i < spriteNumber; ++i)
										{
											string[] spriteLine = reader.ReadLine().Split(" ");
											spritesNames[i] = spriteLine[0];
											animationTime += float.Parse(spriteLine[1]);
										}

										writer.Write("MULTI_ANIM " + animationNumber + " " + spriteNumber);
										foreach (string animation in animationsLine)
										{
											string[] animationInfos = animation.Split(" ");
											writer.Write("\n" + animationInfos[0] + " " + animationTime / animationNumber);
											writer.Write(" " + animationInfos[1] + " " + animationInfos[2]);
										}
										foreach (string sprite in spritesNames)
											writer.Write("\n" + sprite);
										break;
									case 3: //MultiTimedAnimation
										writer.Write(reader.ReadToEnd());
										break;
									default:
										break;
								}
								break;
							case AnimationType.None:
							default:
								break;
						}
						MessageBox.Show("Conversion done");
					}
				}
			}
		}

		Form m_parent;
		bool m_fileSelected = false;
		AnimationType m_animationType = AnimationType.None;
	}
}

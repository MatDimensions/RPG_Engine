using Engine;
using Game;
using SFML.Graphics;
using SFML.System;
using System.Reflection;

namespace EntityConfigEditor
{
	public partial class EntityConfigEditor : Form
	{
		public EntityConfigEditor()
		{
			SpriteUtility.Init();
			ShaderUtility.Init();
			Engine.Debug.Init();

			InitializeComponent();

			panel.AutoScroll = true;
			panel.VerticalScroll.Enabled = true;
			panel.VerticalScroll.Visible = true;

			openFileDialog.DefaultExt = ".entityConfig";
			openFileDialog.Multiselect = false;
			openFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "/../../../../../../../x64/Datas/";
			openFileDialog.RestoreDirectory = false;
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = "EntityConfig file (*.entityConfig)|*.entityConfig";

			saveFileDialog.DefaultExt = ".entityConfig";
			saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "/../../../../../../../x64/Datas/";
			saveFileDialog.RestoreDirectory = false;
			saveFileDialog.CheckFileExists = false;
			saveFileDialog.Filter = "EntityConfig file (*.entityConfig)|*.entityConfig";
			AddEntityConfigs();

			ChangeEntityConfigSelected(this, null);
		}

		public List<EntityConfig> EntityConfigs { get => m_entityConfigs; }
		public int SelectedConfig { get => typeSelected; set => typeSelected = value; }

		~EntityConfigEditor()
		{
			if (currentEntityConfigFile != null)
			{
				currentEntityConfigFile.Close();
				currentEntityConfigFile.Dispose();
			}
		}

		private void ChangeEntityConfigSelected(object sender, EventArgs e)
		{
			SelectionEntityConfigForm newForm = new(this);

			newForm.ShowDialog();
		}

		private void CreateNewEntityConfig(object sender, EventArgs e)
		{
			currentEntityConfig = (EntityConfig)Activator.CreateInstance(m_entityConfigs[typeSelected].GetType());

			DisplayConfig();
		}

		private void LoadEntityConfig(object? sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;

			currentEntityConfig = m_entityConfigs[typeSelected];
			currentEntityConfig.LoadFromFile(openFileDialog.FileName);

			DisplayConfig();
		}

		private void SaveEntityConfig(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() != DialogResult.OK || currentEntityConfig == null)
				return;

			saveFields?.Invoke();

			currentEntityConfig.SaveOnFile(saveFileDialog.FileName);
		}

		private void DisplayConfig()
		{
			//clear all
			panel.Controls.Clear();
			saveFields = null;

			int index = -1;
			foreach (FieldInfo componentConfig in currentEntityConfig.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
			{
				++index;
				Label componentConfigLabel = new Label();
				componentConfigLabel.AutoSize = true;
				componentConfigLabel.Text = componentConfig.Name;
				componentConfigLabel.Location = new Point(10, 25 * index);
				panel.Controls.Add(componentConfigLabel);

				foreach (FieldInfo field in componentConfig.FieldType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
				{
					++index;
					Label fieldLabel = new Label();
					fieldLabel.Size = new Size(110, 20);
					fieldLabel.Text = field.Name;
					fieldLabel.Location = new Point(40, 25 * index);
					panel.Controls.Add(fieldLabel);

					if (field.FieldType.IsAssignableTo(typeof(float)))
					{
						TextBox box = new TextBox();
						box.Size = new Size(100, 20);
						box.Location = new Point(150, 25 * index);
						box.Text = field.GetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig)).ToString();
						saveFields += () =>
						{
							field.SetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig), float.Parse(box.Text));
						};
						panel.Controls.Add(box);
					}
					else if (field.FieldType.IsAssignableTo(typeof(int)))
					{
						NumericUpDown box = new NumericUpDown();
						box.Size = new Size(100, 20);
						box.Location = new Point(150, 25 * index);
						box.Value = (decimal)((int)field.GetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig)));
						saveFields += () =>
						{
							field.SetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig), (int)box.Value);
						};
						panel.Controls.Add(box);
					}
					else if (field.FieldType.IsAssignableTo(typeof(bool)))
					{
						CheckBox box = new CheckBox();
						box.Size = new Size(20, 20);
						box.Location = new Point(150, 25 * index);
						box.Checked = (bool)field.GetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig));
						saveFields += () =>
						{
							field.SetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig), box.Checked);
						};
						panel.Controls.Add(box);
					}
					else if (field.FieldType.IsAssignableTo(typeof(string)))
					{
						TextBox box = new TextBox();
						box.Size = new Size(200, 20);
						box.Location = new Point(150, 25 * index);
						box.Text = (string)field.GetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig));
						saveFields += () =>
						{
							field.SetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig), box.Text);
						};
						panel.Controls.Add(box);
					}
					else if (field.FieldType.IsAssignableTo(typeof(Vector2f)))
					{
						TextBox xBox = new TextBox();
						xBox.Size = new Size(100, 20);
						xBox.Location = new Point(150, 25 * index);
						xBox.Text = ((Vector2f)field.GetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig))).X.ToString();
						saveFields += () =>
						{
							Vector2f vector = (Vector2f)field.GetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig));
							vector.X = float.Parse(xBox.Text);
							field.SetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig), vector);
						};
						panel.Controls.Add(xBox);

						TextBox yBox = new TextBox();
						yBox.Size = new Size(100, 20);
						yBox.Location = new Point(260, 25 * index);
						yBox.Text = ((Vector2f)field.GetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig))).Y.ToString();
						saveFields += () =>
						{
							Vector2f vector = (Vector2f)field.GetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig));
							vector.Y = float.Parse(yBox.Text);
							field.SetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig), vector);
						};
						panel.Controls.Add(yBox);
					}
					else if (field.FieldType.IsAssignableTo(typeof(Sprite)))
					{
						TextBox box = new TextBox();
						box.Size = new Size(200, 20);
						box.Location = new Point(150, 25 * index);
						box.Text = SpriteUtility.GetSpriteName((Sprite)field.GetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig)));
						saveFields += () =>
						{
							field.SetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig), SpriteUtility.GetSprite(box.Text));
						};
						panel.Controls.Add(box);
					}
					else if (field.FieldType.IsAssignableTo(typeof(Shader)))
					{
						TextBox box = new TextBox();
						box.Size = new Size(200, 20);
						box.Location = new Point(150, 25 * index);
						box.Text = ShaderUtility.GetShaderName((Shader)field.GetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig)));
						saveFields += () =>
						{
							field.SetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig), ShaderUtility.GetShader(box.Text));
						};
						panel.Controls.Add(box);
					}
					else
					{
						TextBox fieldValue = new TextBox();
						fieldValue.Size = new Size(100, 20);
						fieldValue.Text = "Unsuported";
						fieldValue.Location = new Point(150, 25 * index);
						panel.Controls.Add(fieldValue);
					}
				}
			}
		}

		private void AddEntityConfigs()
		{
			m_entityConfigs.Add(new DebugEntityConfig());
			m_entityConfigs.Add(new AnimatedDebugEnityConfig());
			m_entityConfigs.Add(new CollisionDebugEntityConfig());
		}

		private FileStream currentEntityConfigFile;
		private EntityConfig currentEntityConfig;
		private int typeSelected = 0;
		private List<EntityConfig> m_entityConfigs = new List<EntityConfig>();
		private Action saveFields;

	}
}

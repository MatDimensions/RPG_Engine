using Engine;
using SFML.Graphics;
using SFML.System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting;

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

			/*scrollBar.Value = panel.VerticalScroll.Value;
			scrollBar.Minimum = panel.VerticalScroll.Minimum;
			scrollBar.Maximum = panel.VerticalScroll.Maximum;
			scrollBar.Enabled = true;*/

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
			saveFileDialog.CheckFileExists = true;
			saveFileDialog.Filter = "EntityConfig file (*.entityConfig)|*.entityConfig";
			AddEntityConfigs();
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

			//TextBox textBox = new();
			//textBox.Location = new Point(20, 30);
			//textBox.TextChanged += (sender, e) => { /*textBox.Text;*/ };
			//si problems d'overlapp : textBox.Location = new Point(x, y); incrémente mon this.y et prendre celui-là

			//panel.Controls.Add(textBox);
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
					else if (field.FieldType.IsAssignableTo(typeof(ICollider)))
					{
						TextBox box = new TextBox();
						box.Size = new Size(250, 20);
						box.Location = new Point(150, 25 * index);
						ICollider collider = (ICollider)field.GetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig));
						box.Text = collider == null ? "null" : collider.GetType().UnderlyingSystemType.FullName;
						saveFields += () =>
						{
							string typeName = box.Text;
							ObjectHandle? oh = Activator.CreateInstance("EnginePhysic", typeName);
							ICollider collider = typeName == "null" ? null : (ICollider)oh.Unwrap();
							field.SetValue(currentEntityConfig.GetType().GetField(componentConfig.Name).GetValue(currentEntityConfig), collider);
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

		private FileStream currentEntityConfigFile;
		private EntityConfig currentEntityConfig;
		private int typeSelected = 0;
		private List<EntityConfig> m_entityConfigs = new List<EntityConfig>();
		private Action saveFields;

	}
}

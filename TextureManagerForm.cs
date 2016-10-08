using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Drawing.Imaging;

namespace FragmentFun
{
	public partial class TextureManagerForm : Form
	{
		bool mGLControlsLoaded = false;
		GLControl mChannelSelected = null;
		string[][] mFileNames = new string[MainView.NUM_TEXTURES][];
		bool[] mIsMipmapped = new bool[MainView.NUM_TEXTURES];
		bool mIsChannelChanging = false;

		public TextureManagerForm()
		{
			InitializeComponent();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);

			if (e.CloseReason == CloseReason.WindowsShutDown) return;

			// We don't want to dispose.
			e.Cancel = true;

			Hide();
		}

		private int MapMinFilterToBox(int filter)
		{
			switch (filter)
			{
				case (int)TextureMinFilter.Nearest:
					return 0;
				case (int)TextureMinFilter.Linear:
					return 1;
				case (int)TextureMinFilter.NearestMipmapNearest:
					return 2;
				case (int)TextureMinFilter.LinearMipmapNearest:
					return 3;
				case (int)TextureMinFilter.NearestMipmapLinear:
					return 4;
				case (int)TextureMinFilter.LinearMipmapLinear:
					return 5;
				default:
					return -1;
			}
		}

		private int MapBoxToMinFilter(int selection)
		{
			switch (selection)
			{
				case 0:
					return (int)TextureMinFilter.Nearest;
				case 1:
					return (int)TextureMinFilter.Linear;
				case 2:
					return (int)TextureMinFilter.NearestMipmapNearest;
				case 3:
					return (int)TextureMinFilter.LinearMipmapNearest;
				case 4:
					return (int)TextureMinFilter.NearestMipmapLinear;
				case 5:
					return (int)TextureMinFilter.LinearMipmapLinear;
				default:
					return (int)TextureMinFilter.Linear;
			}
		}

		private int MapBoxToTexWrap(int selection)
		{
			switch (selection)
			{
				case 0:
					return (int)TextureWrapMode.Clamp;
				case 1:
					return (int)TextureWrapMode.Repeat;
				case 2:
					return (int)TextureWrapMode.ClampToBorder;
				case 3:
					return (int)TextureWrapMode.ClampToEdge;
				case 4:
					return (int)TextureWrapMode.MirroredRepeat;
				default:
					return (int)TextureWrapMode.Clamp;
			}
		}

		private int MapTexWrapToBox(int texWrap)
		{
			switch (texWrap)
			{
				case (int)TextureWrapMode.Clamp:
					return 0;
				case (int)TextureWrapMode.Repeat:
					return 1;
				case (int)TextureWrapMode.ClampToBorder:
					return 2;
				case (int)TextureWrapMode.ClampToEdge:
					return 3;
				case (int)TextureWrapMode.MirroredRepeat:
					return 4;
				default:
					return -1;
			}
		}

		private void glControl_Load(object sender, EventArgs e)
		{
			mGLControlsLoaded = true;

			mChannelSelected = glControl1;

			OpenTK.GLControl currentControl = (OpenTK.GLControl)sender;

			GL.Enable(EnableCap.Texture2D);
			GL.Enable(EnableCap.TextureCubeMap);
		}

		private void glControl_Paint(object sender, EventArgs e)
		{
			if (!mGLControlsLoaded)
				return;

			OpenTK.GLControl currentControl = (OpenTK.GLControl)sender;
			currentControl.MakeCurrent();

			GL.ActiveTexture(TextureUnit.Texture0);
			GL.BindTexture(MainView.mTextureTypes[currentControl.TabIndex], MainView.mTextureObjects[currentControl.TabIndex]);

			GL.CallList(MainView.mListForQuad);

			GL.BindTexture(MainView.mTextureTypes[currentControl.TabIndex], 0);

			currentControl.SwapBuffers();
		}

		private void glControl_Resize(object sender, EventArgs e)
		{
			OpenTK.GLControl currentControl = (OpenTK.GLControl)sender;

			currentControl.Invalidate();
		}

		private void UpdateOptions(int channel)
		{
			mIsChannelChanging = true;

			fileName.Text = "";
			if (mFileNames[channel] != null)
			{
				for (int i = 0; i < mFileNames[channel].Length; i++)
				{
					fileName.Text += '\"' + mFileNames[channel][i] + "\" ";
				}
			}

			if (fileName.Text == "")
			{
				fileName.Text = "Filename";
			}

			TextureTarget texTarget = MainView.mTextureTypes[channel];
			GL.BindTexture(texTarget, MainView.mTextureObjects[channel]);

			int param;
			GL.GetTexParameter(texTarget, GetTextureParameter.TextureMinFilter, out param);
			minFilterBox.SelectedIndex = MapMinFilterToBox(param);

			GL.GetTexParameter(texTarget, GetTextureParameter.TextureWrapS, out param);
			texWrapSBox.SelectedIndex = MapTexWrapToBox(param);

			GL.GetTexParameter(texTarget, GetTextureParameter.TextureWrapT, out param);
			texWrapTBox.SelectedIndex = MapTexWrapToBox(param);

			GL.GetTexParameter(texTarget, GetTextureParameter.TextureWrapR, out param);
			texWrapRBox.SelectedIndex = MapTexWrapToBox(param);

			GL.BindTexture(texTarget, 0);

			mipMapCheckBox.Checked = mIsMipmapped[channel];
			mipMapCheckBox.Enabled = !mipMapCheckBox.Checked;

			mIsChannelChanging = false;
		}

		private void glControl_OnClick(object sender, EventArgs e)
		{
			OpenTK.GLControl currentControl = (OpenTK.GLControl)sender;
			mChannelSelected = currentControl;
			UpdateOptions(currentControl.TabIndex);
		}

		private void fileName_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if (openFileDialog1.FileNames.Length == 6)
				{
					MessageBox.Show("6 images choosen, so I will generate a cubemap of these images.");
				}
				else if (openFileDialog1.FileNames.Length != 1)
				{
					MessageBox.Show("You can only choose one or six images(Cubemap).");
					return;
				}

				mFileNames[mChannelSelected.TabIndex] = new string[openFileDialog1.FileNames.Length];
				for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
				{
					mFileNames[mChannelSelected.TabIndex][i] = System.IO.Path.GetFileName(openFileDialog1.FileNames[i]);
				}

				GL.DeleteTexture(MainView.mTextureObjects[mChannelSelected.TabIndex]);
				MainView.mTextureObjects[mChannelSelected.TabIndex] = GL.GenTexture();

				if (openFileDialog1.FileNames.Length == 1)
				{
					GL.BindTexture(TextureTarget.Texture2D, MainView.mTextureObjects[mChannelSelected.TabIndex]);

					Bitmap bitmap = new Bitmap(openFileDialog1.FileName);
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
					BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
														ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

					GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
								  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

					bitmap.UnlockBits(bmpData);

					GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
					GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

					GL.BindTexture(TextureTarget.Texture2D, 0);
					MainView.SetSamplerType(TextureTarget.Texture2D, mChannelSelected.TabIndex);
				}
				else
				{
					GL.BindTexture(TextureTarget.TextureCubeMap, MainView.mTextureObjects[mChannelSelected.TabIndex]);

					GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
					GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
					GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
					GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
					GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, (int)TextureWrapMode.ClampToEdge);

					//Positive x face
					Bitmap bitmap = new Bitmap(openFileDialog1.FileNames[0]);
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
					BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
														ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

					GL.TexImage2D(TextureTarget.TextureCubeMapPositiveX, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
								  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

					bitmap.UnlockBits(bmpData);

					//Negative x face
					bitmap = new Bitmap(openFileDialog1.FileNames[1]);
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
					bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
														ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

					GL.TexImage2D(TextureTarget.TextureCubeMapNegativeX, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
								  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

					bitmap.UnlockBits(bmpData);

					//Positive y face
					bitmap = new Bitmap(openFileDialog1.FileNames[2]);
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
					bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
														ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

					GL.TexImage2D(TextureTarget.TextureCubeMapPositiveY, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
								  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

					bitmap.UnlockBits(bmpData);

					//Negative y face
					bitmap = new Bitmap(openFileDialog1.FileNames[3]);
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
					bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
														ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

					GL.TexImage2D(TextureTarget.TextureCubeMapNegativeY, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
								  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

					bitmap.UnlockBits(bmpData);

					//Positive z face
					bitmap = new Bitmap(openFileDialog1.FileNames[4]);
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
					bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
														ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

					GL.TexImage2D(TextureTarget.TextureCubeMapPositiveZ, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
								  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

					bitmap.UnlockBits(bmpData);

					//Negative z face
					bitmap = new Bitmap(openFileDialog1.FileNames[5]);
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
					bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
														ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

					GL.TexImage2D(TextureTarget.TextureCubeMapNegativeZ, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
								  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

					bitmap.UnlockBits(bmpData);

					GL.BindTexture(TextureTarget.TextureCubeMap, 0);
					MainView.SetSamplerType(TextureTarget.TextureCubeMap, mChannelSelected.TabIndex);
				}

				mIsMipmapped[mChannelSelected.TabIndex] = false;
				UpdateOptions(mChannelSelected.TabIndex);
				mChannelSelected.Invalidate();
			}
		}

		private void mipMapCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (!mIsChannelChanging)
			{
				GL.BindTexture(MainView.mTextureTypes[mChannelSelected.TabIndex], MainView.mTextureObjects[mChannelSelected.TabIndex]);

				GL.Hint(HintTarget.GenerateMipmapHint, HintMode.Nicest);
				GL.GenerateMipmap((GenerateMipmapTarget)MainView.mTextureTypes[mChannelSelected.TabIndex]);

				GL.BindTexture(MainView.mTextureTypes[mChannelSelected.TabIndex], 0);

				mIsMipmapped[mChannelSelected.TabIndex] = true;
				mipMapCheckBox.Enabled = false;
				mChannelSelected.Invalidate();
			}
		}

		private void minFilterBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!mIsChannelChanging)
			{
				GL.BindTexture(MainView.mTextureTypes[mChannelSelected.TabIndex], MainView.mTextureObjects[mChannelSelected.TabIndex]);

				GL.TexParameter(MainView.mTextureTypes[mChannelSelected.TabIndex],
								TextureParameterName.TextureMinFilter, MapBoxToMinFilter(minFilterBox.SelectedIndex));

				GL.BindTexture(MainView.mTextureTypes[mChannelSelected.TabIndex], 0);
				mChannelSelected.Invalidate();
			}
		}

		private void texWrapSBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!mIsChannelChanging)
			{
				GL.BindTexture(MainView.mTextureTypes[mChannelSelected.TabIndex], MainView.mTextureObjects[mChannelSelected.TabIndex]);

				GL.TexParameter(MainView.mTextureTypes[mChannelSelected.TabIndex],
								TextureParameterName.TextureWrapS, MapBoxToTexWrap(texWrapSBox.SelectedIndex));

				GL.BindTexture(MainView.mTextureTypes[mChannelSelected.TabIndex], 0);
				mChannelSelected.Invalidate();
			}
		}

		private void texWrapTBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!mIsChannelChanging)
			{
				GL.BindTexture(MainView.mTextureTypes[mChannelSelected.TabIndex], MainView.mTextureObjects[mChannelSelected.TabIndex]);

				GL.TexParameter(MainView.mTextureTypes[mChannelSelected.TabIndex],
								TextureParameterName.TextureWrapT, MapBoxToTexWrap(texWrapTBox.SelectedIndex));

				GL.BindTexture(MainView.mTextureTypes[mChannelSelected.TabIndex], 0);
				mChannelSelected.Invalidate();
			}
		}

		private void texWrapRBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!mIsChannelChanging)
			{
				GL.BindTexture(MainView.mTextureTypes[mChannelSelected.TabIndex], MainView.mTextureObjects[mChannelSelected.TabIndex]);

				GL.TexParameter(MainView.mTextureTypes[mChannelSelected.TabIndex],
								TextureParameterName.TextureWrapR, MapBoxToTexWrap(texWrapRBox.SelectedIndex));

				GL.BindTexture(MainView.mTextureTypes[mChannelSelected.TabIndex], 0);
				mChannelSelected.Invalidate();
			}
		}
	}
}

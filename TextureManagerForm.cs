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

        public TextureManagerForm()
        {
            InitializeComponent();
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            mGLControlsLoaded = true;

            OpenTK.GLControl currentControl = (OpenTK.GLControl)sender;

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.TextureCubeMap);   
        }

        private void glControl_Paint(object sender, EventArgs e)
        {
            if(!mGLControlsLoaded)
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

        private void glControl_OnClick(object sender, EventArgs e)
        {
            OpenTK.GLControl currentControl = (OpenTK.GLControl)sender;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileNames.Length == 6)
                {
                    MessageBox.Show("You choose 6 images, so I will generate a cubemap of these images.");
                }
                else if (openFileDialog1.FileNames.Length != 1)
                {
                    MessageBox.Show("You can only choose one or six images(Cubemap).");
                    return;
                }

                GL.DeleteTexture(MainView.mTextureObjects[currentControl.TabIndex]);
                MainView.mTextureObjects[currentControl.TabIndex] = GL.GenTexture();

                if (openFileDialog1.FileNames.Length == 1)
                {
                    GL.BindTexture(TextureTarget.Texture2D, MainView.mTextureObjects[currentControl.TabIndex]);

                    Bitmap bitmap = new Bitmap(openFileDialog1.FileName);
                    BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
                                  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

                    bitmap.UnlockBits(bmpData);

                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

                    GL.BindTexture(TextureTarget.Texture2D, 0);
                    MainView.SetSamplerType(TextureTarget.Texture2D, currentControl.TabIndex);
                }
                else
                {
                    GL.BindTexture(TextureTarget.TextureCubeMap, MainView.mTextureObjects[currentControl.TabIndex]);

                    GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                    GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                    GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
                    GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
                    GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, (int)TextureWrapMode.ClampToEdge);

                    //Positive x face
                    Bitmap bitmap = new Bitmap(openFileDialog1.FileNames[0]);
                    BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    GL.TexImage2D(TextureTarget.TextureCubeMapPositiveX, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
                                  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

                    bitmap.UnlockBits(bmpData);

                    //Negative x face
                    bitmap = new Bitmap(openFileDialog1.FileNames[1]);
                    bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    GL.TexImage2D(TextureTarget.TextureCubeMapNegativeX, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
                                  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

                    bitmap.UnlockBits(bmpData);

                    //Positive y face
                    bitmap = new Bitmap(openFileDialog1.FileNames[2]);
                    bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    GL.TexImage2D(TextureTarget.TextureCubeMapPositiveY, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
                                  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

                    bitmap.UnlockBits(bmpData);

                    //Negative y face
                    bitmap = new Bitmap(openFileDialog1.FileNames[3]);
                    bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    GL.TexImage2D(TextureTarget.TextureCubeMapNegativeY, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
                                  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

                    bitmap.UnlockBits(bmpData);

                    //Positive z face
                    bitmap = new Bitmap(openFileDialog1.FileNames[4]);
                    bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    GL.TexImage2D(TextureTarget.TextureCubeMapPositiveZ, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
                                  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

                    bitmap.UnlockBits(bmpData);

                    //Negative z face
                    bitmap = new Bitmap(openFileDialog1.FileNames[5]);
                    bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    GL.TexImage2D(TextureTarget.TextureCubeMapNegativeZ, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height,
                                  0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

                    bitmap.UnlockBits(bmpData);

                    GL.BindTexture(TextureTarget.TextureCubeMap, 0);
                    MainView.SetSamplerType(TextureTarget.TextureCubeMap, currentControl.TabIndex);
                }

                currentControl.Invalidate();
            }
        }
    }
}

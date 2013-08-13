using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;

namespace FragmentFun
{
    public delegate void FlushConsoleDelegate();
    public delegate void WriteToConsoleDelegate(string strOut);

    public partial class MainView : Form
    {
        public static int NUM_TEXTURES = 5;
        
        public static int mListForQuad;
        public static int[] mTextureObjects = new int[NUM_TEXTURES];
        public static TextureTarget[] mTextureTypes = new TextureTarget[NUM_TEXTURES];

        const string mVertexSource = @"#version 130
in vec3 position;
void main()
{
    gl_Position = vec4(position, 1.0);
}";

        string mFragmentSource = "void main()\n" +
                                 "{\n" +
                                 "\tvec2 uv = gl_FragCoord.xy / iResolution.xy;\n" +
                                 "\tgl_FragColor = vec4(uv, 0.5, 1.0);\n" +
                                 "}";

        static string fragmentUniforms = "uniform vec2 iResolution;\n" +
                                  "uniform float iGlobalTime;" +
                                  "uniform sampler2D iChannel0;" +
                                  "uniform sampler2D iChannel1;" +
                                  "uniform sampler2D iChannel2;" +
                                  "uniform sampler2D iChannel3;" +
                                  "uniform sampler2D iChannel4;";

        enum FragmentUniforms
        {
            RESOLUTION = 0,
            GLOBALTIME,
            CHANNEL0,
            CHANNEL1,
            CHANNEL2,
            CHANNEL3,
            CHANNEL4,
            TOTAL
        };

        Thread compilerThread;
        TextureManagerForm mTexManagerForm = null;
        Stopwatch mStopWatch = new Stopwatch();
        Stopwatch mFPSStopWatch = new Stopwatch();
        string mCopyOfFragmentShaderEdit;
        int mFrameCounter;
        double mFrameTimeAccum;
        double mAverageFrameTime;
        int []mUniformLocations = new int[(int)FragmentUniforms.TOTAL];
        int mVertexShader, mFragmentShader, mProgram;
        bool mGLControlLoaded = false;
        bool mIsPaused = false;

        public MainView()
        {
            InitializeComponent();
        }

        public static void SetSamplerType(TextureTarget target, int channel)
        {
            mTextureTypes[channel] = target;

            string samplerType = "";
            string strChannel = "iChannel" + channel.ToString("0");
            if (target == TextureTarget.Texture2D)
            {
                samplerType = "sampler2D";
            }
            else if (target == TextureTarget.TextureCubeMap)
            {
                samplerType = "samplerCube";
            }
            else
            {
                return;
            }

            int channelIndex = fragmentUniforms.IndexOf(strChannel);
            int replaceLoc = fragmentUniforms.IndexOf("sampler", channelIndex - 17);
            fragmentUniforms = fragmentUniforms.Remove(replaceLoc, channelIndex - replaceLoc);
            fragmentUniforms = fragmentUniforms.Insert(replaceLoc, samplerType + " ");
        }

        private void FreeGLObjects()
        {
            GL.DeleteLists(mListForQuad, 1);
        }

        private void WriteToConsole(string strOut)
        {
            if (console.InvokeRequired)
            {
                BeginInvoke(new WriteToConsoleDelegate(WriteToConsole), new object[]{strOut});
            }
            else
            {
                console.Text += strOut;
            }
        }

        private bool CompileShader(int shader, string shaderSource)
        {
            GL.ShaderSource(shader, shaderSource);
            GL.CompileShader(shader);

            int isCompiled;
            GL.GetShader(shader, ShaderParameter.CompileStatus, out isCompiled);
            if (isCompiled == 0)
            {
                WriteToConsole(GL.GetShaderInfoLog(shader));
                return false;
            }

            return true;
        }

        private bool CompileFragmentShader(string fragmentSource)
        {
            fragmentSource = fragmentSource.Insert(0, "#version 130\n" + fragmentUniforms);
            return CompileShader(mFragmentShader, fragmentSource);
        }

        private void LinkProgram()
        {
            GL.LinkProgram(mProgram);

            mUniformLocations[(int)FragmentUniforms.RESOLUTION] = GL.GetUniformLocation(mProgram, "iResolution");
            mUniformLocations[(int)FragmentUniforms.GLOBALTIME] = GL.GetUniformLocation(mProgram, "iGlobalTime");
            mUniformLocations[(int)FragmentUniforms.CHANNEL0] = GL.GetUniformLocation(mProgram, "iChannel0");
            mUniformLocations[(int)FragmentUniforms.CHANNEL1] = GL.GetUniformLocation(mProgram, "iChannel1");
            mUniformLocations[(int)FragmentUniforms.CHANNEL2] = GL.GetUniformLocation(mProgram, "iChannel2");
            mUniformLocations[(int)FragmentUniforms.CHANNEL3] = GL.GetUniformLocation(mProgram, "iChannel3");
            mUniformLocations[(int)FragmentUniforms.CHANNEL4] = GL.GetUniformLocation(mProgram, "iChannel4");
        }

        void AppIdle(object sender, EventArgs e)
        {
            if (!mIsPaused)
            {
                mFPSStopWatch.Stop();
                double milliseconds = mFPSStopWatch.Elapsed.TotalMilliseconds;
                mFPSStopWatch.Restart();
                CalculateFPS(milliseconds);

                glControl1.Invalidate();
            }
        }

        private void CalculateFPS(double milliseconds)
        {
            ++mFrameCounter;
            mFrameTimeAccum += milliseconds;
            if (mFrameTimeAccum > 1000.0)
            {
                mAverageFrameTime = (mFrameTimeAccum / (double)mFrameCounter) / 1000.0;
                fpsLabel.Text = "FPS: " + mFrameCounter;
                mFrameTimeAccum -= 1000.0;
                mFrameCounter = 0;
            }
        }

        private void Render()
        {
            GL.UseProgram(mProgram);
            GL.Uniform2(mUniformLocations[(int)FragmentUniforms.RESOLUTION], new Vector2((float)glControl1.Width, (float)glControl1.Height));
            GL.Uniform1(mUniformLocations[(int)FragmentUniforms.GLOBALTIME], (float)mStopWatch.Elapsed.TotalSeconds);
            GL.Uniform1(mUniformLocations[(int)FragmentUniforms.CHANNEL0], 0);
            GL.Uniform1(mUniformLocations[(int)FragmentUniforms.CHANNEL1], 1);
            GL.Uniform1(mUniformLocations[(int)FragmentUniforms.CHANNEL2], 2);
            GL.Uniform1(mUniformLocations[(int)FragmentUniforms.CHANNEL3], 3);
            GL.Uniform1(mUniformLocations[(int)FragmentUniforms.CHANNEL4], 4);

            for (int i = 0; i < NUM_TEXTURES; i++)
            {
                GL.ActiveTexture(TextureUnit.Texture0 + i);
                GL.BindTexture(mTextureTypes[i], mTextureObjects[i]);
            }

            GL.CallList(mListForQuad);

            GL.UseProgram(0);
            GL.BindTexture(TextureTarget.Texture2D, 0);

            glControl1.SwapBuffers();

            globalTimeTextBox.Text = mStopWatch.Elapsed.TotalSeconds.ToString("0.00");
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            mGLControlLoaded = true;

            mListForQuad = GL.GenLists(1);
            GL.NewList(mListForQuad, ListMode.Compile);
                GL.Begin(BeginMode.Triangles);
                    GL.TexCoord2(0, 0); GL.Vertex3(-1.0f, -1.0f, 0.0f);
                    GL.TexCoord2(1, 0); GL.Vertex3(1.0f, -1.0f, 0.0f);
                    GL.TexCoord2(1, 1); GL.Vertex3(1.0f, 1.0f, 0.0f);

                    GL.TexCoord2(1, 1); GL.Vertex3(1.0f, 1.0f, 0.0f);
                    GL.TexCoord2(0, 1); GL.Vertex3(-1.0f, 1.0f, 0.0f);
                    GL.TexCoord2(0, 0); GL.Vertex3(-1.0f, -1.0f, 0.0f);
                GL.End();
            GL.EndList();

            mVertexShader = GL.CreateShader(ShaderType.VertexShader);
            CompileShader(mVertexShader, mVertexSource);

            mFragmentShader = GL.CreateShader(ShaderType.FragmentShader);

            mProgram = GL.CreateProgram();
            GL.AttachShader(mProgram, mVertexShader);
            GL.AttachShader(mProgram, mFragmentShader);

            fragmentSourceEdit.Text = mFragmentSource;

            Application.Idle += AppIdle;
            mStopWatch.Start();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!mGLControlLoaded || (compilerThread != null && compilerThread.IsAlive))
                return;

            glControl1.MakeCurrent();

            Render();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            glControl1.Invalidate();
        }

        private void CompileFragmentShaderThread()
        {
            glControl1.MakeCurrent();

            if (CompileFragmentShader(mCopyOfFragmentShaderEdit))
            {
                BeginInvoke(new FlushConsoleDelegate(FlushConsole));
            }

            LinkProgram();

            glControl1.Context.MakeCurrent(null);
        }

        private void FlushConsole()
        {
            //Flush console.
            console.Text = "";
        }

        private void fragmentSourceEdit_TextChanged(object sender, ScintillaNET.TextModifiedEventArgs e)
        {
            if (compilerThread != null)
            {
                compilerThread.Join();
            }

            try
            {
                glControl1.Context.MakeCurrent(null);
            }
            catch
            { }

            mCopyOfFragmentShaderEdit = (string)fragmentSourceEdit.Text.Clone();
            compilerThread = new Thread(new ThreadStart(CompileFragmentShaderThread));
            compilerThread.IsBackground = true;
            compilerThread.Start();
        }

        private void openShaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.FileName = Path.GetFileName(openFileDialog1.FileName);
                saveFileDialog1.FilterIndex = openFileDialog1.FilterIndex;

                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                fragmentSourceEdit.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != "")
            {
                System.IO.StreamReader sr = new
                    System.IO.StreamReader(openFileDialog1.FileName);
                fragmentSourceEdit.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void saveShaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sr = new
                   System.IO.StreamWriter(saveFileDialog1.FileName);
                sr.Write(fragmentSourceEdit.Text);
                sr.Close();
            }
        }

        private void resetGlobalTimerButton_Click(object sender, EventArgs e)
        {
            mStopWatch.Restart();
            mIsPaused = false;
        }

        private void startPauseButton_Click(object sender, EventArgs e)
        {
            if (mIsPaused)
            {
                mStopWatch.Start();
            }
            else
            {
                mStopWatch.Stop();
            }

            mIsPaused = !mIsPaused;
        }

        private void textureManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mTexManagerForm == null || mTexManagerForm.IsDisposed)
            {
                mTexManagerForm = new TextureManagerForm();
            }

            mTexManagerForm.Show();
            mTexManagerForm.Focus();
        }

        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
               refreshToolStripMenuItem_Click(sender, new EventArgs());
            }
        }
    }
}

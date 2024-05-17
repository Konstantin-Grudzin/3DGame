using StbImageSharp;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenGl.Graphics;
using OpenTK.Compute.OpenCL;
using System.Drawing;

namespace OpenGl
{
    internal class Game : GameWindow
    {
        int Height;
        int Width;

        float PlayerSpeed = 0.005f;
        static int numberOfPlayers = 4+1;
        List<GameObject> gameObjects = new List<GameObject>();
        GameObject background;


        ShaderProgram program;

        public Game(int width, int height) : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            this.CenterWindow(new Vector2i(width, height));
            Height = height;
            Width = width;
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
            this.Width = e.Width;
            this.Height = e.Height;
        }


        protected override void OnLoad()
        {
            base.OnLoad();
            Random rnd= new Random();
            numberOfPlayers = rnd.Next(2, 5) + 4;

            gameObjects.Add(new GameObject(0, "5674.png"));
            gameObjects[0].MakePlayer();
            for(int i=1;i<numberOfPlayers;i++) 
            {
                gameObjects.Add(new GameObject(0, GenPng()));
            }

            background = new GameObject(1, "back.png");


            program = new ShaderProgram("Default.vert", "Default.frag");

            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
            background.Delete();
            for(int i=0;i<gameObjects.Count;++i)
                gameObjects[i].Delete();
        }

        int Timer = 0;
        float yRot = 0;
        float xRot = 0;
        float zRot = 0;
        float bright = 1f;
        int enemyKilled = 0;
        float yRot1 = 0;
        float deltay = 0.0001f;
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.ClearColor(0.5f, 0.6f, 0.3f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            float diff = CountAlive() <= 3 ? 0.0025f : 0; ;
            PlayerSpeed = 0.0025f + diff;
            int cAlive = CountAlive() - 1;
            string text = "Enemies left: " + cAlive.ToString()+"  Enemy Killed: "+enemyKilled.ToString();
            Title = text;
            // --- KeyBoard Traking ---

            Vector3 Pmove = new Vector3(0, 0, 0);
            if (IsKeyDown(Keys.W))
            {
                Pmove.Y = -PlayerSpeed;
            }
            if (IsKeyDown(Keys.S))
            {
                Pmove.Y = PlayerSpeed;
            }
            if (IsKeyDown(Keys.D))
            {
                Pmove.X = -PlayerSpeed;
            }
            if (IsKeyDown(Keys.A))
            {
                Pmove.X = PlayerSpeed;
            }

            // --- End of KeyBoard Traking ---

            // transformation matrices
            Matrix4 model = Matrix4.Identity;
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(60f), Width / Height, 0.1f, 100.0f);

            int modelLocation = GL.GetUniformLocation(program.ID, "model");
            int projectionLocation = GL.GetUniformLocation(program.ID, "projection");
            int brightLocation = GL.GetUniformLocation(program.ID, "brightness");

            GL.UniformMatrix4(modelLocation, true, ref model);
            GL.UniformMatrix4(projectionLocation, true, ref projection);
            GL.Uniform1(brightLocation, bright);

            // --- Background ---
            model = Matrix4.Identity;
            model *= Matrix4.CreateTranslation(background.position + background.getSize());
            background.ChangePosition(Pmove);
            GL.UniformMatrix4(modelLocation, true, ref model);
            background.Render(program);
            // --- Background ---


            for (int i = 0; i < gameObjects.Count; ++i)//
            {
                if (!gameObjects[i].isAlive()) continue;
                for (int j = 0; j < gameObjects.Count; ++j)
                {
                    if (i == j || !gameObjects[j].isAlive()) continue;
                    int result = gameObjects[i].Intersection(gameObjects[j]);
                    if ( result == 1)
                        break;
                    if (i == 0 && result == 2)
                        enemyKilled++;
                }
                model = Matrix4.Identity;
                model *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(30));

                //--- Povorot ---
                model *= Matrix4.CreateRotationY(yRot1);
                if (yRot1 > 0.75f)
                    deltay *= -1;
                if(yRot1 < -0.75f)
                    deltay *= -1;
                yRot1 += deltay;
                //---   END   ---

                if (IsKeyDown(Keys.Escape))
                {
                    model *= Matrix4.CreateRotationX(xRot);
                    model *= Matrix4.CreateRotationY(yRot);
                    model *= Matrix4.CreateRotationZ(zRot);
                    yRot += 0.0001f;
                    xRot += 0.0002f;
                    zRot += 0.0003f;
                    
                }
                else
                {
                    yRot = 0;
                    xRot = 0;
                    zRot = 0;
                }

                model *= Matrix4.CreateTranslation(gameObjects[i].position + gameObjects[i].getSize());
                GL.UniformMatrix4(modelLocation, true, ref model);
                GL.UniformMatrix4(projectionLocation, true, ref projection);
                gameObjects[i].Render(program);
                if (i != 0)
                {

                    gameObjects[i].ChangePosition(Pmove);
                }
            }

            // --- Random moving ---
            Timer++;
            if (Timer > 10 * 60)
            {
                Timer = 0;
                for (int i = 1; i < gameObjects.Count; ++i)//
                {
                    gameObjects[i].ChangeTypeOfPosition();
                }

            }
            // --- Random moving ---

            if(CountAlive()<=2)
            {
                Random rnd=new Random();
                int addPlayers = rnd.Next(2, 5);
                for (int i = 0; i < addPlayers; ++i)
                {
                    
                    gameObjects.Add(new GameObject(0, GenPng()));
                    numberOfPlayers++;
                }
            }

            if (!gameObjects[0].isAlive())
            {
                Console.WriteLine("You lose");
                this.Close();
            }
            if(enemyKilled>= 8)
            {
                Console.WriteLine("You win");
                this.Close();
            }

            Context.SwapBuffers();



            base.OnRenderFrame(args);


        }
        public int CountAlive()
        {
            int count = 0;
            for (int i = 0; i < gameObjects.Count; ++i)//
            {
                count += gameObjects[i].isAlive() ? 1 : 0;
            }
            return count;
        }

        public string GenPng()
        {
            Random rnd=new Random();
            int type = rnd.Next(0, 5);
            if (type == 0)
                return "enemy.png";
            else if (type == 1)
                return "makson.png";
            else if (type == 2)
                return "gorynych.png";
            else
                return "lenin.png";
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }


    }

    
}

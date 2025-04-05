using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

using static PhysicsSim.Globals;
using static PhysicsSim.MathLib;

namespace PhysicsSim;

public class Renderer : GameWindow
{
    private Shader Shader;

    private EntityCircle Circle;
    
    public Renderer(int width, int height, string title) : 
        base(GameWindowSettings.Default, new NativeWindowSettings() { 
            Size = (width, height), Title = title 
        })
    {
        CenterWindow();
        UpdateFrequency = 30;
    }

    protected override void OnLoad()
    {
        base.OnLoad();

        ENTITIES.Add(new EntityCircle(new Vector2(0.0f, 0.0f), 0.15f));
        ENTITIES.Add(new EntityCircle(new Vector2(-0.5f, 0.5f), 0.25f));
        ENTITIES.Add(new EntityCircle(new Vector2(0.5f, -0.5f), 0.15f));

        //Shaders
        string circleVertexPath = Path.Combine(Directory.GetCurrentDirectory(), "Shaders/Circle.vert");
        string circleFragmentPath = Path.Combine(Directory.GetCurrentDirectory(), "Shaders/Circle.frag");
        Shader = new Shader(circleVertexPath, circleFragmentPath);

        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
    }

    protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
    {
        base.OnFramebufferResize(e);

        GL.Viewport(0, 0, e.Width, e.Height);
        WINDOW_ASPECT = (float)WINDOW_WIDTH / WINDOW_HEIGHT;
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);
        HandleInput();
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {   
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit);

        GL.UseProgram(Shader.ShaderHandle);

        for (int i = 0; i < ENTITIES.Count; i++)
        {
            GL.BindVertexArray(ENTITIES[i].Mesh.VAO);
            GL.EnableVertexAttribArray(0);

            var transform = CreateTransformationMatrix(ENTITIES[i].Position, ENTITIES[i].ScaleFactor, ENTITIES[i].RotZ);
            Shader.SetMatrix3("transform", transform);

            GL.DrawArrays(PrimitiveType.TriangleFan, 0, ENTITIES[i].Mesh.VertexCount);

            GL.DisableVertexAttribArray(0);
            GL.BindVertexArray(0);
        }

        SwapBuffers();
    }

    protected override void OnUnload()
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.BindVertexArray(0);
        GL.UseProgram(0);

        GL.DeleteProgram(Shader.ShaderHandle);

        for (int i = 0; i < ENTITIES.Count; i++)
        {
            ENTITIES[i].Dispose();
        }
        Shader.Dispose();
        base.OnUnload();
    }

    private void HandleInput()
    {
        if (KeyboardState.IsKeyDown(Keys.Escape)) Close();

        if (MouseState.IsButtonPressed(MouseButton.Left))
        {
            
        }
    }
}

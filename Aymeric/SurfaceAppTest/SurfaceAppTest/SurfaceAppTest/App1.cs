using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Surface;
using Microsoft.Surface.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace SurfaceAppTest
{
    /// <summary>
    /// This is the main type for your application.
    /// </summary>
    public class App1 : Microsoft.Xna.Framework.Game
    {
       
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private TouchTarget touchTarget;
        private Color backgroundColor = new Color(81, 81, 81);
        private bool applicationLoadCompleteSignalled;

        private UserOrientation currentOrientation = UserOrientation.Bottom;
        private Matrix screenTransform = Matrix.Identity;

        private int screenWidth;
        private int screenHeight;

        private Texture2D bignou; // palet
        private Texture2D raquetteGauche; //raquette1
        private Texture2D raquetteDroite; //raquette2
        
        private Vector2 BignouPosition;
        private Vector2 BignouDep;

        private Vector2 raquetteGauchePosition;
        private Vector2 raquetteGaucheDep;

        private Vector2 raquetteDroitePosition;
        private Vector2 raquetteDroiteDep;




        /// <summary>
        /// The target receiving all surface input for the application.
        /// </summary>
        protected TouchTarget TouchTarget
        {
            get { return touchTarget; }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public App1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        #region Initialization

        /// <summary>
        /// Moves and sizes the window to cover the input surface.
        /// </summary>
        private void SetWindowOnSurface()
        {
            System.Diagnostics.Debug.Assert(Window != null && Window.Handle != IntPtr.Zero,
                "Window initialization must be complete before SetWindowOnSurface is called");
            if (Window == null || Window.Handle == IntPtr.Zero)
                return;

            // Get the window sized right.
            Program.InitializeWindow(Window);
            // Set the graphics device buffers.
            graphics.PreferredBackBufferWidth = Program.WindowSize.Width;
            graphics.PreferredBackBufferHeight = Program.WindowSize.Height;
            graphics.ApplyChanges();
            // Make sure the window is in the right location.
            Program.PositionWindow();
        }

        private void evtRaquetteDroite(object sender, EventArgs e){
            
        }

        private void evtRaquetteGauche(object sender, EventArgs e){

        }

        /// <summary>
        /// Initializes the surface input system. This should be called after any window
        /// initialization is done, and should only be called once.
        /// </summary>
        private void InitializeSurfaceInput()
        {
            System.Diagnostics.Debug.Assert(Window != null && Window.Handle != IntPtr.Zero,
                "Window initialization must be complete before InitializeSurfaceInput is called");
            if (Window == null || Window.Handle == IntPtr.Zero)
                return;
            System.Diagnostics.Debug.Assert(touchTarget == null,
                "Surface input already initialized");
            if (touchTarget != null)
                return;

            // Create a target for surface input.
            touchTarget = new TouchTarget(Window.Handle, EventThreadChoice.OnBackgroundThread);
            touchTarget.EnableInput();

            touchTarget.TouchMove += new EventHandler<TouchEventArgs>(evtRaquetteDroite);
        }

        #endregion

        #region Overridden Game Methods

        /// <summary>
        /// Allows the app to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            IsMouseVisible = true; // easier for debugging not to "lose" mouse
            SetWindowOnSurface();
            InitializeSurfaceInput();

            // Set the application's orientation based on the orientation at launch
            currentOrientation = ApplicationServices.InitialOrientation;

            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;

            // Setup the UI to transform if the UI is rotated.
            // Create a rotation matrix to orient the screen so it is viewed correctly
            // when the user orientation is 180 degress different.
            Matrix inverted = Matrix.CreateRotationZ(MathHelper.ToRadians(180)) *
                       Matrix.CreateTranslation(graphics.GraphicsDevice.Viewport.Width,
                                                 graphics.GraphicsDevice.Viewport.Height,
                                                 0);

            if (currentOrientation == UserOrientation.Top)
            {
                screenTransform = inverted;
            }

            screenWidth = Window.ClientBounds.Width;
            screenHeight = Window.ClientBounds.Height;

            BignouPosition = Vector2.Zero;
            BignouDep = Vector2.One;

            raquetteGauchePosition = new Vector2(0,0);
            raquetteGaucheDep = new Vector2(0,1);

            raquetteDroitePosition = new Vector2(screenWidth - 140, screenHeight-455);
            raquetteDroiteDep = new Vector2(0, 1);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per app and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your application content here
            bignou = Content.Load<Texture2D>("paletGame");
            raquetteGauche = Content.Load<Texture2D>("raquette1");
            raquetteDroite = Content.Load<Texture2D>("raquette2");
            
        }

        /// <summary>
        /// UnloadContent will be called once per app and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the app to run logic such as updating the world,
        /// checking for collisions, gathering input and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (ApplicationServices.WindowAvailability != WindowAvailability.Unavailable)
            {
                if (ApplicationServices.WindowAvailability == WindowAvailability.Interactive)
                {
                    // TODO: Process touches, 
                    // use the following code to get the state of all current touch points.
                    // ReadOnlyTouchPointCollection touches = touchTarget.GetState();
                }

                // TODO: Add your update logic here
                BignouPosition += BignouDep;
                raquetteGauchePosition += raquetteGaucheDep;
                raquetteDroitePosition += raquetteDroiteDep;

                if((BignouDep.X < 0 && BignouPosition.X <= 0) || (BignouDep.X > 0 && BignouPosition.X + bignou.Width >= screenWidth)){
                    BignouDep.X = -BignouDep.X;
                }
                if((BignouDep.Y < 0 && BignouPosition.Y <= 0) || (BignouDep.Y > 0 && BignouPosition.Y + bignou.Height >= screenHeight))
                {
                    BignouDep.Y = -BignouDep.Y;
                }
                if((raquetteGaucheDep.Y < 0 && raquetteGauchePosition.Y <= 0) || (raquetteGaucheDep.Y > 0 && raquetteGauchePosition.Y + raquetteGauche.Height >= screenHeight))
                {
                    raquetteGaucheDep.Y = -raquetteGaucheDep.Y;
                }
                if ((raquetteDroiteDep.Y < 0 && raquetteDroitePosition.Y <= 0) || (raquetteDroiteDep.Y > 0 && raquetteDroitePosition.Y + raquetteDroite.Height >= screenHeight))
                {
                    raquetteDroiteDep.Y = -raquetteDroiteDep.Y;
                }
                
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the app should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (!applicationLoadCompleteSignalled)
            {
                // Dismiss the loading screen now that we are starting to draw
                ApplicationServices.SignalApplicationLoadComplete();
                applicationLoadCompleteSignalled = true;
            }

            //TODO: Rotate the UI based on the value of screenTransform here if desired

            GraphicsDevice.Clear(backgroundColor);

            //TODO: Add your drawing code here

            spriteBatch.Begin();
            spriteBatch.Draw(raquetteGauche, raquetteGauchePosition, Color.White);
            spriteBatch.Draw(raquetteDroite, raquetteDroitePosition, Color.White);
            spriteBatch.Draw(bignou, BignouPosition, Color.White);
            
            spriteBatch.End();

            //TODO: Avoid any expensive logic if application is neither active nor previewed

            base.Draw(gameTime);
        }

        #endregion

        #region Application Event Handlers

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: Enable audio, animations here

            //TODO: Optionally enable raw image here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: Optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: Disable audio, animations here

            //TODO: Disable raw image if it's enabled
        }

        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Release managed resources.
                IDisposable graphicsDispose = graphics as IDisposable;
                if (graphicsDispose != null)
                {
                    graphicsDispose.Dispose();
                }
                if (touchTarget != null)
                {
                    touchTarget.Dispose();
                    touchTarget = null;
                }
            }

            // Release unmanaged Resources.

            // Set large objects to null to facilitate garbage collection.

            base.Dispose(disposing);
        }

        #endregion
    }
}
